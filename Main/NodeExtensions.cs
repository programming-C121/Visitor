using BaseVisitor.Interfaces;
using Example.Visitors;

namespace Test;

public static class NodeExtensions
{
    /// <summary>
    /// Executes the node processing, performing semantic checks and evaluation.
    /// </summary>
    /// <param name="node">The node to be processed, implementing the <see cref="INode"/> interface.</param>
    /// <param name="debug">
    /// A boolean flag indicating whether to output debug information.
    /// If set to true, additional details about the processing will be printed to the console.
    /// </param>
    public static void Execute(this INode node, bool debug = false)
    {
        if (debug)
        {
            PrintFormattedAst(node);
        }

        if (CheckSemanticValidity(node, debug))
        {
            EvaluateNode(node, debug);
        }
    }

    private static void PrintFormattedAst(INode node)
    {
        var formatVisitor = new FormatVisitor();
        var formattedAst = formatVisitor.VisitBase(node);
        Console.WriteLine(formattedAst);
        PrintSeparator();
    }

    private static bool CheckSemanticValidity(INode node, bool debug)
    {
        var semanticCheckVisitor = new SemanticCheckVisitor();
        var semanticCheckResult = semanticCheckVisitor.VisitBase(node);

        if (semanticCheckResult == null)
        {
            throw new InvalidOperationException("Unexpected error: The result of the semantic check is null.");
        }

        if (!semanticCheckResult.IsSuccess)
        {
            Console.WriteLine($"Semantic check failed: {semanticCheckResult.Error}");
            return false;
        }

        if (debug)
        {
            Console.WriteLine($"Semantic check successful. Type: {semanticCheckResult.Type.Name}");
            PrintSeparator();
        }

        return true;
    }

    private static void EvaluateNode(INode node, bool debug)
    {
        var evaluationVisitor = new EvaluationVisitor();
        var evaluationResult = evaluationVisitor.VisitBase(node);

        if (debug)
        {
            Console.WriteLine($"Evaluation result: {evaluationResult ?? "Null"}");
            PrintSeparator();
        }
    }

    private static void PrintSeparator()
    {
        Console.WriteLine(new string('=', 70));
    }
}