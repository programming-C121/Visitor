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

var semanticCheckVisitor = new SemanticCheckVisitor();
var semanticCheckResult = semanticCheckVisitor.VisitCore(node);
if (semanticCheckResult == null)
{
    Console.WriteLine("Algo ha salido mal");
}
else if (semanticCheckResult.IsSuccess)
{
    Console.WriteLine($"Resultado del chequeo semántico: Success, Tipo: {semanticCheckResult.Type.Name}");
}
else
{
    Console.WriteLine($"Resultado del chequeo semántico: Failure, Error: {semanticCheckResult.Error}");
}

Console.WriteLine("=======================================================");

var evaluationVisitor = new EvaluationVisitor();
var evaluationResult = evaluationVisitor.VisitCore(node);
Console.WriteLine($"Resultado de la evaluación: {evaluationResult}");