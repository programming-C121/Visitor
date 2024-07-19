using BaseVisitor.Interfaces;
using Example.VisitorImplementations;
using Visitor.ASTNodes;

IExpression expression = new MultiplicationExpression(
    new AdditionExpression(
        new NumberExpression(5),
        new NumberExpression(3)
    ),
    new NumberExpression(2)
);

var formatVisitor = new FormatVisitor();
var formatResult = formatVisitor.Visit(expression);
Console.WriteLine(formatResult);

Console.WriteLine("=======================================================");

var evaluationVisitor = new EvaluationVisitor();
var evaluationResult = evaluationVisitor.Visit(expression);
Console.WriteLine($"Resultado: {evaluationResult}");