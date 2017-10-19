//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from d:\users\smart\documents\visual studio 2017\Projects\AtlusScriptToolchain\Source\AtlusScriptLib\FlowScriptLanguage\Compiler\Parser\Grammar\FlowScript.g4 by ANTLR 4.6.4

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AtlusScriptLib.FlowScriptLanguage.Compiler.Parser.Grammar {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="FlowScriptParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.4")]
[System.CLSCompliant(false)]
public interface IFlowScriptListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>logicalOrExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicalOrExpression([NotNull] FlowScriptParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>logicalOrExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicalOrExpression([NotNull] FlowScriptParser.LogicalOrExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>equalityExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEqualityExpression([NotNull] FlowScriptParser.EqualityExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>equalityExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEqualityExpression([NotNull] FlowScriptParser.EqualityExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>assignmentExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignmentExpression([NotNull] FlowScriptParser.AssignmentExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assignmentExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignmentExpression([NotNull] FlowScriptParser.AssignmentExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>castExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCastExpression([NotNull] FlowScriptParser.CastExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>castExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCastExpression([NotNull] FlowScriptParser.CastExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>relationalExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationalExpression([NotNull] FlowScriptParser.RelationalExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>relationalExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationalExpression([NotNull] FlowScriptParser.RelationalExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>additionExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdditionExpression([NotNull] FlowScriptParser.AdditionExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>additionExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdditionExpression([NotNull] FlowScriptParser.AdditionExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>compoundExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompoundExpression([NotNull] FlowScriptParser.CompoundExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>compoundExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompoundExpression([NotNull] FlowScriptParser.CompoundExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>nullExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullExpression([NotNull] FlowScriptParser.NullExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>nullExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullExpression([NotNull] FlowScriptParser.NullExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>unaryPrefixExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryPrefixExpression([NotNull] FlowScriptParser.UnaryPrefixExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unaryPrefixExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryPrefixExpression([NotNull] FlowScriptParser.UnaryPrefixExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>logicalAndExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicalAndExpression([NotNull] FlowScriptParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>logicalAndExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicalAndExpression([NotNull] FlowScriptParser.LogicalAndExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>multiplicationExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplicationExpression([NotNull] FlowScriptParser.MultiplicationExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplicationExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplicationExpression([NotNull] FlowScriptParser.MultiplicationExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>callExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCallExpression([NotNull] FlowScriptParser.CallExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>callExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCallExpression([NotNull] FlowScriptParser.CallExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>primaryExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimaryExpression([NotNull] FlowScriptParser.PrimaryExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>primaryExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimaryExpression([NotNull] FlowScriptParser.PrimaryExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>unaryPostfixExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryPostfixExpression([NotNull] FlowScriptParser.UnaryPostfixExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unaryPostfixExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryPostfixExpression([NotNull] FlowScriptParser.UnaryPostfixExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierExpression([NotNull] FlowScriptParser.IdentifierExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierExpression([NotNull] FlowScriptParser.IdentifierExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantExpression([NotNull] FlowScriptParser.ConstantExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="FlowScriptParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantExpression([NotNull] FlowScriptParser.ConstantExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.compilationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompilationUnit([NotNull] FlowScriptParser.CompilationUnitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.compilationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompilationUnit([NotNull] FlowScriptParser.CompilationUnitContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.importStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImportStatement([NotNull] FlowScriptParser.ImportStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.importStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImportStatement([NotNull] FlowScriptParser.ImportStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] FlowScriptParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] FlowScriptParser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.nullStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullStatement([NotNull] FlowScriptParser.NullStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.nullStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullStatement([NotNull] FlowScriptParser.NullStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompoundStatement([NotNull] FlowScriptParser.CompoundStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompoundStatement([NotNull] FlowScriptParser.CompoundStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.declarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclarationStatement([NotNull] FlowScriptParser.DeclarationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.declarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclarationStatement([NotNull] FlowScriptParser.DeclarationStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.functionDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionDeclarationStatement([NotNull] FlowScriptParser.FunctionDeclarationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.functionDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionDeclarationStatement([NotNull] FlowScriptParser.FunctionDeclarationStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.procedureDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProcedureDeclarationStatement([NotNull] FlowScriptParser.ProcedureDeclarationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.procedureDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProcedureDeclarationStatement([NotNull] FlowScriptParser.ProcedureDeclarationStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.variableDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableDeclarationStatement([NotNull] FlowScriptParser.VariableDeclarationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.variableDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableDeclarationStatement([NotNull] FlowScriptParser.VariableDeclarationStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.labelDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabelDeclarationStatement([NotNull] FlowScriptParser.LabelDeclarationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.labelDeclarationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabelDeclarationStatement([NotNull] FlowScriptParser.LabelDeclarationStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.variableModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableModifier([NotNull] FlowScriptParser.VariableModifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.variableModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableModifier([NotNull] FlowScriptParser.VariableModifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterList([NotNull] FlowScriptParser.ParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterList([NotNull] FlowScriptParser.ParameterListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] FlowScriptParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] FlowScriptParser.ParameterContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionList([NotNull] FlowScriptParser.ExpressionListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionList([NotNull] FlowScriptParser.ExpressionListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] FlowScriptParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] FlowScriptParser.ExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimary([NotNull] FlowScriptParser.PrimaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimary([NotNull] FlowScriptParser.PrimaryContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] FlowScriptParser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] FlowScriptParser.ConstantContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] FlowScriptParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] FlowScriptParser.IfStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForStatement([NotNull] FlowScriptParser.ForStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForStatement([NotNull] FlowScriptParser.ForStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileStatement([NotNull] FlowScriptParser.WhileStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileStatement([NotNull] FlowScriptParser.WhileStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.breakStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBreakStatement([NotNull] FlowScriptParser.BreakStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.breakStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBreakStatement([NotNull] FlowScriptParser.BreakStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.continueStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterContinueStatement([NotNull] FlowScriptParser.ContinueStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.continueStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitContinueStatement([NotNull] FlowScriptParser.ContinueStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnStatement([NotNull] FlowScriptParser.ReturnStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnStatement([NotNull] FlowScriptParser.ReturnStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.gotoStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGotoStatement([NotNull] FlowScriptParser.GotoStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.gotoStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGotoStatement([NotNull] FlowScriptParser.GotoStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.switchStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSwitchStatement([NotNull] FlowScriptParser.SwitchStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.switchStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSwitchStatement([NotNull] FlowScriptParser.SwitchStatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="FlowScriptParser.switchLabel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSwitchLabel([NotNull] FlowScriptParser.SwitchLabelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FlowScriptParser.switchLabel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSwitchLabel([NotNull] FlowScriptParser.SwitchLabelContext context);
}
} // namespace AtlusScriptLib.FlowScriptLanguage.Compiler.Parser.Grammar
