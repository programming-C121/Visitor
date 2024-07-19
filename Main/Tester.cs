using BaseVisitor.Interfaces;
using Example.AST;
using Example.ASTNodes;
using Example.VisitorImplementations;

namespace Test;

public class Tester
{
    public static void AssertEquals<T>(T expected, T actual, string testName)
    {
        if (!expected.Equals(actual))
        {
            Console.WriteLine($"Test Failed: {testName}. Expected: {expected}, Actual: {actual}");
            Environment.Exit(1);
        }
        else
        {
            Console.WriteLine($"Test Passed: {testName}");
        }
    }

    public static void TestEval()
    {
        TestSubtractionVisitor();
        TestDivisionVisitor();
        TestComplexExpressionVisitor();
        TestFormatVisitor();
        TestEvaluationVisitor();
        TestComplexExpressionWithVariablesVisitor();
    }

    static void TestFormatVisitor()
    {
        INode node = new AdditionNode(new NumberNode(1), new NumberNode(2));
        var visitor = new FormatVisitor();
        var result = visitor.VisitCore(node);
        var expected = "AdditionNode\n    Number: 1\n    Number: 2";
        AssertEquals(expected, result, "FormatVisitor Test");
    }

    static void TestEvaluationVisitor()
    {
        INode node = new AdditionNode(new NumberNode(1), new NumberNode(2));
        var visitor = new EvaluationVisitor();
        var result = visitor.VisitCore(node);
        var expected = 3;
        AssertEquals(expected, result, "EvaluationVisitor Test");
    }

    static void TestSubtractionVisitor()
    {
        INode node = new SubtractionNode(new NumberNode(5), new NumberNode(2));
        var visitor = new EvaluationVisitor();
        var result = visitor.VisitCore(node);
        var expected = 3;
        AssertEquals(expected, result, "SubtractionVisitor Test");
    }

    static void TestDivisionVisitor()
    {
        INode node = new DivisionNode(new NumberNode(10), new NumberNode(2));
        var visitor = new EvaluationVisitor();
        var result = visitor.VisitCore(node);
        var expected = 5;
        AssertEquals(expected, result, "DivisionVisitor Test");
    }

    static void TestComplexExpressionVisitor()
    {
        // (5 + 3) * 2 - 4 / 2
        INode node = new SubtractionNode(
            new MultiplicationNode(
                new AdditionNode(new NumberNode(5), new NumberNode(3)),
                new NumberNode(2)),
            new DivisionNode(new NumberNode(4), new NumberNode(2))
        );
        var visitor = new EvaluationVisitor();
        var result = visitor.VisitCore(node);
        var expected = 14;
        AssertEquals(expected, result, "ComplexExpressionVisitor Test");
    }

    static void TestComplexExpressionWithVariablesVisitor()
    {
        // Initialize the EvaluationVisitor
        var visitor = new EvaluationVisitor();

        // Declare variables
        var varX = new VariableDeclarationNode("x", new NumberNode(5));
        var varY = new VariableDeclarationNode("y", new NumberNode(10));

        // (x * 2) + (y / 2) - 3
        INode complexExpression = new SubtractionNode(
            new AdditionNode(
                new MultiplicationNode(new VariableNode("x"), new NumberNode(2)),
                new DivisionNode(new VariableNode("y"), new NumberNode(2))
            ),
            new NumberNode(3)
        );

        // Evaluate variable declarations
        visitor.Visit(varX);
        visitor.Visit(varY);

        // Evaluate the complex expression
        var result = visitor.VisitCore(complexExpression);

        // Expected result calculation: (5 * 2) + (10 / 2) - 3 = 10 + 5 - 3 = 12
        AssertEquals(12, result, "ComplexExpressionWithVariables Test");
    }
}