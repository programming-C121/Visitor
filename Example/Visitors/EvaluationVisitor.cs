using BaseVisitor;
using Example.AST;

namespace Example.Visitors;

/// <summary>
/// Visitor that evaluates the abstract syntax tree (AST) and computes the result of the expressions.
/// </summary>
public class EvaluationVisitor : VisitorBase<object>
{
    // Dictionary to store variable names and their corresponding AST nodes
    private readonly Dictionary<string, object?> _variables = new();

    public object Visit(NumberNode node)
    {
        return node.Value;
    }

    public object? Visit(AdditionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        // Check if both operands are integers before performing addition
        if (left is int leftInt && right is int rightInt)
        {
            return leftInt + rightInt;
        }

        return null; // Return null if the operands are not valid integers
    }

    public object? Visit(MultiplicationNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        // Check if both operands are integers before performing multiplication
        if (left is int leftInt && right is int rightInt)
        {
            return leftInt * rightInt;
        }

        return null; // Return null if the operands are not valid integers
    }

    public object? Visit(SubtractionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        // Check if both operands are integers before performing subtraction
        if (left is int leftInt && right is int rightInt)
        {
            return leftInt - rightInt;
        }

        return null; // Return null if the operands are not valid integers
    }

    public object? Visit(DivisionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        // Check if both operands are integers before performing division
        if (left is int leftInt && right is int rightInt)
        {
            return leftInt / rightInt;
        }

        return null; // Return null if the operands are not valid integers
    }

    public object? Visit(VariableNode node)
    {
        // Retrieve the value of the variable from the dictionary
        return _variables[node.Name];
    }

    public object? Visit(VariableDeclarationNode node)
    {
        // Evaluate the value of the variable and store it in the dictionary
        var value = VisitBase(node.Value);
        _variables[node.Name] = value;
        return value;
    }

    public object? Visit(ProgramNode node)
    {
        object? lastResult = null;

        // Evaluate each statement in the program
        foreach (var statement in node.Statements)
        {
            lastResult = VisitBase(statement);
        }

        return lastResult; // Returns the result of the last statement
    }
}