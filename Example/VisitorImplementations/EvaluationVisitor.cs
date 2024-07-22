using BaseVisitor;
using BaseVisitor.Interfaces;
using Example.AST;

namespace Example.VisitorImplementations;

/// <summary>
/// Visitor that evaluates the abstract syntax tree (AST) and computes the result of the expressions.
/// </summary>
public class EvaluationVisitor : VisitorBase<object>
{
    // Dictionary to store variable names and their corresponding AST nodes
    private Dictionary<string, INode> _variables = new();

    /// <summary>
    /// Evaluates a number node by returning its value.
    /// </summary>
    public object Visit(NumberNode node)
    {
        return node.Value;
    }

    /// <summary>
    /// Evaluates an addition node by adding the values of its left and right children.
    /// </summary>
    public object? Visit(AdditionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt + rightInt;
        }

        return null;
    }

    /// <summary>
    /// Evaluates a multiplication node by multiplying the values of its left and right children.
    /// </summary>
    public object? Visit(MultiplicationNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt * rightInt;
        }

        return null;
    }

    /// <summary>
    /// Evaluates a subtraction node by subtracting the right child's value from the left child's value.
    /// </summary>
    public object? Visit(SubtractionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt - rightInt;
        }

        return null;
    }

    /// <summary>
    /// Evaluates a division node by dividing the left child's value by the right child's value.
    /// </summary>
    public object? Visit(DivisionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt / rightInt;
        }

        return null;
    }

    /// <summary>
    /// Evaluates a variable node by looking up its value in the variables dictionary.
    /// </summary>
    public object? Visit(VariableNode node)
    {
        return VisitBase(_variables[node.Name]);
    }

    /// <summary>
    /// Evaluates a variable declaration node by storing the variable in the dictionary and returning its value.
    /// </summary>
    public object? Visit(VariableDeclarationNode node)
    {
        var value = VisitBase(node.Value);
        _variables[node.Name] = node.Value;
        return value;
    }

    /// <summary>
    /// Evaluates a program node by evaluating all its statements in order.
    /// </summary>
    public object? Visit(ProgramNode node)
    {
        object? lastResult = null;
        foreach (var statement in node.Statements)
        {
            lastResult = VisitBase(statement);
        }
        return lastResult; // Returns the result of the last statement
    }
}
