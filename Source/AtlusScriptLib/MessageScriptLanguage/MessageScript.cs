﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AtlusScriptLib.Common.Text.Encodings;
using AtlusScriptLib.MessageScriptLanguage.BinaryModel;

namespace AtlusScriptLib.MessageScriptLanguage
{
    /// <summary>
    /// This class represents a mutable message script that is designed to abstract away the format implementation details.
    /// </summary>
    public class MessageScript
    {
        // TODO: maybe move the parsing functions to a seperate class
        /// <summary>
        /// Creates a <see cref="MessageScript"/> from a <see cref="MessageScriptBinary"/>.
        /// </summary>
        public static MessageScript FromBinary( MessageScriptBinary binary, Encoding encoding = null )
        {
            if ( binary == null )
                throw new ArgumentNullException( nameof( binary ) );

            if ( binary.WindowHeaders == null )
                throw new ArgumentNullException( nameof( binary ) );

            // Create new script instance & set user id, format version
            var instance = new MessageScript()
            {
                Id = binary.Header.UserId,
                FormatVersion = (MessageScriptFormatVersion)binary.FormatVersion,
                Encoding = encoding,
            };

            // Convert the binary messages to their counterpart
            foreach ( var messageHeader in binary.WindowHeaders )
            {
                IMessageScriptWindow message;
                IReadOnlyList<int> lineStartAddresses;
                IReadOnlyList<byte> buffer;
                int lineCount;

                switch ( messageHeader.WindowType )
                {
                    case MessageScriptBinaryWindowType.Dialogue:
                        {
                            var binaryMessage = ( MessageScriptBinaryDialogueWindow )messageHeader.Window.Value;
                            lineStartAddresses = binaryMessage.LineStartAddresses;
                            buffer = binaryMessage.TextBuffer;
                            lineCount = binaryMessage.LineCount;

                            if ( binaryMessage.SpeakerId == 0xFFFF )
                            {
                                message = new MessageScriptDialogWindow( binaryMessage.Identifier );
                            }
                            else if ( ( binaryMessage.SpeakerId & 0x8000 ) == 0x8000 )
                            {
                                Trace.WriteLine( binaryMessage.SpeakerId.ToString( "X4" ) );

                                message = new MessageScriptDialogWindow( binaryMessage.Identifier, new MessageScriptVariableSpeaker( binaryMessage.SpeakerId & 0x0FFF ) );
                            }
                            else
                            {
                                if ( binary.SpeakerTableHeader.SpeakerNameArray.Value == null )
                                    throw new InvalidDataException( "Speaker name array is null while being referenced" );

                                MessageScriptLine speakerName = null;
                                if ( binaryMessage.SpeakerId < binary.SpeakerTableHeader.SpeakerCount )
                                {
                                    speakerName = ParseSpeakerLine( binary.SpeakerTableHeader.SpeakerNameArray
                                        .Value[binaryMessage.SpeakerId].Value, encoding == null ? Encoding.ASCII : encoding );
                                }

                                message = new MessageScriptDialogWindow( binaryMessage.Identifier, new MessageScriptNamedSpeaker( speakerName ) );
                            }
                        }
                        break;

                    case MessageScriptBinaryWindowType.Selection:
                        {
                            var binaryMessage = ( MessageScriptBinarySelectionWindow )messageHeader.Window.Value;
                            lineStartAddresses = binaryMessage.OptionStartAddresses;
                            buffer = binaryMessage.TextBuffer;
                            lineCount = binaryMessage.OptionCount;

                            message = new MessageScriptSelectionWindow( ( string )binaryMessage.Identifier.Clone() );
                        }
                        break;

                    default:
                        throw new InvalidDataException( "Unknown message type" );
                }

                if ( lineCount != 0 )
                {
                    // Parse the line data
                    ParseLines( message, lineStartAddresses, buffer, encoding == null ? Encoding.ASCII : encoding );
                }

                // Add it to the message list
                instance.Windows.Add( message );
            }

            return instance;
        }

        /// <summary>
        /// Deserializes and creates a <see cref="MessageScript"/> from a file.
        /// </summary>
        public static MessageScript FromFile( string path, Encoding encoding = null )
        {
            if ( path == null )
                throw new ArgumentNullException( nameof( path ) );

            var binary = MessageScriptBinary.FromFile( path );

            return FromBinary( binary, encoding );
        }

        /// <summary>
        /// Deserializes and creates a <see cref="MessageScript"/> from a stream.
        /// </summary>
        public static MessageScript FromStream( Stream stream, Encoding encoding = null, bool leaveOpen = false )
        {
            if ( stream == null )
                throw new ArgumentNullException( nameof( stream ) );

            var binary = MessageScriptBinary.FromStream( stream, leaveOpen );

            return FromBinary( binary, encoding );
        }

        private static void ParseLines( IMessageScriptWindow message, IReadOnlyList<int> lineStartAddresses, IReadOnlyList<byte> buffer, Encoding encoding )
        {
            if ( lineStartAddresses.Count == 0 || buffer.Count == 0 )
                return;

            // The addresses are not relative to the start of the buffer
            // so we rebase the addresses first
            int lineStartAddressBase = lineStartAddresses[0];
            int[] rebasedLineStartAddresses = new int[lineStartAddresses.Count];

            for ( int i = 0; i < lineStartAddresses.Count; i++ )
                rebasedLineStartAddresses[i] = lineStartAddresses[i] - lineStartAddressBase;

            for ( int lineIndex = 0; lineIndex < rebasedLineStartAddresses.Length; lineIndex++ )
            {
                // Initialize a new line
                var line = new MessageScriptLine();

                // Now that the line start addresses have been rebased, we can use them as indices into the buffer
                int bufferIndex = rebasedLineStartAddresses[lineIndex];

                // Calculate the line end index
                int lineEndIndex = ( lineIndex + 1 ) != rebasedLineStartAddresses.Length ? rebasedLineStartAddresses[lineIndex + 1] : buffer.Count;

                // Loop over the buffer until we find a 0 byte or have reached the end index
                while ( bufferIndex < lineEndIndex )
                {
                    if ( !TryParseTokens( buffer, ref bufferIndex, out var tokens, encoding ) )
                        break;

                    line.Tokens.AddRange( tokens );
                }

                // Add line to list of lines
                message.Lines.Add( line );
            }
        }

        private static MessageScriptLine ParseSpeakerLine( IReadOnlyList<byte> bytes, Encoding encoding )
        {
            var line = new MessageScriptLine();

            int bufferIndex = 0;

            while ( bufferIndex < bytes.Count )
            {
                if ( !TryParseTokens( bytes, ref bufferIndex, out var tokens, encoding ) )
                    break;

                line.Tokens.AddRange( tokens );
            }

            return line;
        }

        private static bool TryParseTokens( IReadOnlyList<byte> buffer, ref int bufferIndex, out List<IMessageScriptLineToken> tokens, Encoding encoding )
        {
            byte b = buffer[bufferIndex++];
            tokens = new List<IMessageScriptLineToken>();

            // Check if the current byte signifies a function
            if ( b == 0 )
            {
                tokens = null;
                return false;
            }
            else if ( b == MessageScriptNewLineToken.Value )
            {
                tokens.Add( new MessageScriptNewLineToken() );
            }
            else if ( ( b & 0xF0 ) == 0xF0 )
            {
                tokens.Add( ParseFunctionToken( b, buffer, ref bufferIndex ) );
            }
            else
            {
                tokens.AddRange( ParseTextTokens( b, buffer, ref bufferIndex, encoding ) );
            }

            return true;
        }

        private static MessageScriptCodePointToken ParseCharacterCodeToken( byte b, IReadOnlyList<byte> buffer, ref int bufferIndex )
        {
            return new MessageScriptCodePointToken( b, buffer[bufferIndex++] );
        }

        private static MessageScriptFunctionToken ParseFunctionToken( byte b, IReadOnlyList<byte> buffer, ref int bufferIndex )
        {
            int functionId = ( b << 8 ) | buffer[bufferIndex++];
            int functionTableIndex = ( functionId & 0xE0 ) >> 5;
            int functionIndex = ( functionId & 0x1F );
            int functionArgumentByteCount = ( ( ( functionId >> 8 ) & 0xF ) - 1 ) * 2;
            short[] functionArguments = new short[functionArgumentByteCount / 2];

            for ( int i = 0; i < functionArguments.Length; i++ )
            {
                byte firstByte = ( byte )( buffer[bufferIndex++] - 1 );
                byte secondByte = 0;
                byte secondByteAux = buffer[bufferIndex++];

                //if (secondByteAux != 0xFF)
                {
                    secondByte = ( byte )( secondByteAux - 1 );
                }

                functionArguments[i] = ( short )( ( firstByte & ~0xFF00 ) | ( ( secondByte << 8 ) & 0xFF00 ) );
            }

            return new MessageScriptFunctionToken( functionTableIndex, functionIndex, functionArguments );
        }

        private static List<IMessageScriptLineToken> ParseTextTokens( byte b, IReadOnlyList<byte> buffer, ref int bufferIndex, Encoding encoding )
        {
            var accumulatedText = new List<byte>();
            var charBytes = new byte[2];
            var atlusEncoding = encoding as AtlusEncoding;
            var tokens = new List<IMessageScriptLineToken>();
            byte b2;

            while ( true )
            {
                // Read 2 bytes
                if ( ( b & 0x80 ) == 0x80 )
                {
                    b2 = buffer[bufferIndex++];
                    accumulatedText.Add( b );
                    accumulatedText.Add( b2 );
                }
                else
                {
                    // Read one
                    accumulatedText.Add( b );
                }

                // Check for any condition that would end the sequence of text characters
                if ( bufferIndex == buffer.Count )
                    break;

                b = buffer[bufferIndex];

                if ( b == 0 || b == MessageScriptNewLineToken.Value || ( b & 0xF0 ) == 0xF0 )
                {                 
                    break;
                }

                bufferIndex++;
            }

            var accumulatedTextBuffer = accumulatedText.ToArray();
            var stringBuilder = new StringBuilder();

            for ( int i = 0; i < accumulatedTextBuffer.Length; i++ )
            {
                byte high = accumulatedTextBuffer[i];
                if ( ( high & 0x80 ) == 0x80 )
                {
                    byte low = accumulatedTextBuffer[++i];

                    if ( encoding != null && !encoding.IsSingleByte )
                    {
                        // Get decoded characters
                        charBytes[0] = high;
                        charBytes[1] = low;

                        var chars = encoding.GetChars( charBytes );
                        Debug.Assert( chars.Length == 1 );

                        // Check if it's an unmapped character -> make it a code point
                        char c = encoding.GetChars( charBytes )[0];
                        if ( c == 0 )
                        {
                            // There was some proper text previously, so make sure we add it
                            if ( stringBuilder.Length != 0 )
                            {
                                tokens.Add( new MessageScriptTextToken( stringBuilder.ToString() ) );
                                stringBuilder.Clear();
                            }

                            tokens.Add( new MessageScriptCodePointToken( high, low ) );
                        }
                        else
                        {
                            stringBuilder.Append( c );
                        }
                    }
                    else
                    {
                        tokens.Add( new MessageScriptCodePointToken( high, low ) );
                    }
                }
                else
                {
                    stringBuilder.Append( ( char )high );
                }
            }

            // There was some proper text previously, so make sure we add it
            if ( stringBuilder.Length != 0 )
            {
                tokens.Add( new MessageScriptTextToken( stringBuilder.ToString() ) );
                stringBuilder.Clear();
            }

            return tokens;
        }

        /// <summary>
        /// Gets or sets the user id. Serves as metadata.
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// Gets or sets the format version this script will use in its binary form.
        /// </summary>
        public MessageScriptFormatVersion FormatVersion { get; set; }

        /// <summary>
        /// Gets or sets the encoding used for the text.
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Gets the list of <see cref="IMessageScriptWindow"/> in this script.
        /// </summary>
        public List<IMessageScriptWindow> Windows { get; }

        /// <summary>
        /// Creates a new instance of <see cref="MessageScript"/> initialized with default values.
        /// </summary>
        private MessageScript()
        {
            Id = 0;
            FormatVersion = MessageScriptFormatVersion.Version1;
            Encoding = null;
            Windows = new List<IMessageScriptWindow>();
        }

        /// <summary>
        /// Creates a new instance of <see cref="MessageScript"/> initialized with default values.
        /// </summary>
        public MessageScript( MessageScriptFormatVersion version, Encoding encoding = null )
        {
            Id = 0;
            FormatVersion = version;
            Encoding = encoding;
            Windows = new List<IMessageScriptWindow>();
        }

        /// <summary>
        /// Converts this <see cref="MessageScript"/> instance to a <see cref="MessageScriptBinary"/> instance.
        /// </summary>
        /// <returns></returns>
        public MessageScriptBinary ToBinary()
        {
            var builder = new MessageScriptBinaryBuilder( ( MessageScriptBinaryFormatVersion )FormatVersion );

            builder.SetUserId( Id );
            builder.SetEncoding( Encoding );

            foreach ( var message in Windows )
            {
                switch ( message.Type )
                {
                    case MessageScriptWindowType.Dialogue:
                        builder.AddWindow( ( MessageScriptDialogWindow )message );
                        break;
                    case MessageScriptWindowType.Selection:
                        builder.AddWindow( ( MessageScriptSelectionWindow )message );
                        break;

                    default:
                        throw new NotImplementedException( message.Type.ToString() );
                }
            }

            return builder.Build();
        }

        /// <summary>
        /// Serializes and writes this <see cref="MessageScript"/> instance to the specified file.
        /// </summary>
        /// <param name="path"></param>
        public void ToFile( string path )
        {
            if ( path == null )
                throw new ArgumentNullException( nameof( path ) );

            if ( string.IsNullOrEmpty( path ) )
                throw new ArgumentException( "Value cannot be null or empty.", nameof( path ) );

            using ( var stream = File.Create( path ) )
                ToStream( stream );
        }

        /// <summary>
        /// Serializes and writes this <see cref="MessageScript"/> instance to a stream.
        /// </summary>
        /// <returns></returns>
        public Stream ToStream()
        {
            var stream = new MemoryStream();
            ToStream( stream, true );
            return stream;
        }

        /// <summary>
        /// Serializes and writes this <see cref="MessageScript"/> instance to the specified stream.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="leaveOpen">Whether to stream should be left open or not.</param>
        public void ToStream( Stream stream, bool leaveOpen = false )
        {
            var binary = ToBinary();
            binary.ToStream( stream, leaveOpen );
        }
    }
}
