﻿using System.Collections.Generic;
using AtlusScriptLib.Common.IO;
using System.Runtime.InteropServices;

namespace AtlusScriptLib
{
    public struct MessageScriptBinaryHeader
    {
        public const int SIZE = 32;
        public const byte FILE_TYPE = 7;
        public static byte[] MAGIC_V1 = new byte[] { (byte)'M', (byte)'S', (byte)'G', (byte)'1' };
        public static byte[] MAGIC_V1_BE = new byte[] { (byte)'1', (byte)'G', (byte)'S', (byte)'M' };

        // 00
        public byte FileType;

        // 01
        public bool IsCompressed;

        // 02
        public short UserId;

        // 04
        public int FileSize;

        // 08
        public byte[] Magic;

        // 0C
        public int Field0C;

        // 10
        public AddressValuePair<byte[]> RelocationTable;

        // 14
        public int RelocationTableSize;

        // 18
        public int MessageCount;

        // 1C
        public bool IsRelocated;

        // 1E
        public short Field1E;
    }

    public struct MessageScriptBinaryMessageHeader
    {
        public const int SIZE = 8;

        // 00
        public MessageScriptBinaryMessageType MessageType;

        // 04
        public AddressValuePair<object> Message;
    }

    public struct MessageScriptBinarySpeakerTableHeader
    {
        public const int SIZE = 10;

        // 00
        public AddressValuePair<AddressValuePair<List<byte>>[]> SpeakerNameArray;

        // 04
        public int SpeakerCount;

        // 08
        public int Field08;

        // 0C
        public int Field0C;
    }

    // Variable length
    public struct MessageScriptBinaryDialogueMessage
    {
        public const int IDENTIFIER_LENGTH = 24;

        // 0x00 
        public string Identifier;

        // 0x18
        public short LineCount;

        // 0x1A
        public short SpeakerId;

        // 0x1C
        public int[] LineStartAddresses;

        // 0x1C + LineCount * 4
        public int TextBufferSize;

        // 0x1C + LineCount * 4 + 4
        public byte[] TextBuffer;
    }

    // Variable length
    public struct MessageScriptBinarySelectionMessage
    {
        public const int IDENTIFIER_LENGTH = 24;

        // 0x00
        public string Identifier;

        // 0x18
        public short Field18;

        // 0x1A
        public short OptionCount;

        // 0x1C
        public short Field1C;

        // 0x1E
        public short Field1E;

        // 0x20
        public int[] OptionStartAddresses;

        // 0x20 + OptionCount * 4
        public int TextBufferSize;

        // 0x20 + OptionCount * 4 + 4
        public byte[] TextBuffer;
    }
}
