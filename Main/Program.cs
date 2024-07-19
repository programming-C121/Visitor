using BaseVisitor.Interfaces;
using Example.AST;
using Example.VisitorImplementations;

INode node = new MultiplicationNode(
    new AdditionNode(
        new NumberNode(5),
        new NumberNode(3)
    ),
    new NumberNode(2)
);

var formatVisitor = new FormatVisitor();
var formatResult = formatVisitor.VisitCore(node);
Console.WriteLine(formatResult);

Console.WriteLine("=======================================================");

var evaluationVisitor = new EvaluationVisitor();
var evaluationResult = evaluationVisitor.VisitCore(node);
Console.WriteLine($"Resultado: {evaluationResult}");