using BaseVisitor;
using Example.AST;

namespace Example.Visitors;

/// <summary>
/// Visitor that performs semantic checks on the abstract syntax tree (AST).
/// Ensures that the types and declarations within the AST are valid.
/// </summary>
public class SemanticCheckVisitor : VisitorBase<SemanticResult>
{
    // Dictionary to store variable names and their corresponding types
    private readonly Dictionary<string, Type> _variables = new();

    public SemanticResult Visit(NumberNode node)
    {
        // Numbers are always valid and of type int
        return SemanticResult.Success(typeof(int));
    }

    public SemanticResult Visit(ArithmeticBinaryNode node)
    {
        // Perform semantic check on left and right child nodes
        var leftResult = VisitBase(node.Left);
        var rightResult = VisitBase(node.Right);

        // If there's an error in either child node, propagate that error
        if (leftResult?.Error != null) return leftResult;
        if (rightResult?.Error != null) return rightResult;

        // Verify that both operands are of type int
        if (leftResult?.Type != typeof(int) || rightResult?.Type != typeof(int))
        {
            // If either is not int, return a semantic error
            return SemanticResult.Failure("Arithmetic operands must be integers");
        }

        // If both operands are int, the operation is valid and the result will be int
        return SemanticResult.Success(typeof(int));
    }

    public SemanticResult Visit(ProgramNode node)
    {
        SemanticResult? lastResult = null;

        // Iterate over all statements in the program abd return the last result
        foreach (var result in node.Statements.Select(statement => VisitBase(statement)))
        {
            if (result?.Error != null)
            {
                return result; // Propagate the error
            }

            lastResult = result;
        }

        // Returns the result of the last statement
        return lastResult ?? SemanticResult.Failure("Cannot identify program type");
    }

    public SemanticResult Visit(VariableDeclarationNode node)
    {
        // Perform semantic check on the value of the variable
        var valueResult = VisitBase(node.Value);
        if (valueResult?.Error != null)
        {
            return valueResult; // Propagate the error
        }

        // Check if the variable is already declared
        if (_variables.ContainsKey(node.Name))
        {
            return SemanticResult.Failure($"Variable '{node.Name}' is already declared");
        }

        // Add the variable to the dictionary with its type
        _variables[node.Name] = valueResult!.Type;
        return SemanticResult.Success(valueResult.Type); // Declaration doesn't have a specific return type
    }

    public SemanticResult Visit(VariableNode node)
    {
        // Check if the variable is declared
        return !_variables.TryGetValue(node.Name, out var type)
            ? SemanticResult.Failure($"Variable '{node.Name}' is not declared")
            : SemanticResult.Success(type);
    }
}