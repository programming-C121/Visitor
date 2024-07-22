using BaseVisitor.Interfaces;
using Example.VisitorImplementations;

namespace Test
{
    public static class NodeExtensions
    {
        public static void Execute(this INode node, bool debug = false)
        {
            if (debug)
            {
                PrintFormattedAst(node);
            }

            var semanticResult = PerformSemanticCheck(node);
            if (!semanticResult.IsSuccess)
            {
                return;
            }

            EvaluateNode(node);
        }

        private static void PrintFormattedAst(INode node)
        {
            var formatVisitor = new FormatVisitor();
            var formatResult = formatVisitor.VisitBase(node);
            Console.WriteLine(formatResult);
            PrintSeparator();
        }

        private static SemanticResult PerformSemanticCheck(INode node)
        {
            var semanticCheckVisitor = new SemanticCheckVisitor();
            var semanticCheckResult = semanticCheckVisitor.VisitBase(node);

            if (semanticCheckResult == null)
            {
                Console.WriteLine("Error inesperado: El resultado del chequeo semántico es nulo.");
                return SemanticResult.Failure("Resultado nulo");
            }

            if (!semanticCheckResult.IsSuccess)
            {
                Console.WriteLine($"Chequeo semántico fallido: {semanticCheckResult.Error}");
                return semanticCheckResult;
            }

            Console.WriteLine($"Chequeo semántico exitoso. Tipo: {semanticCheckResult.Type.Name}");
            PrintSeparator();
            return semanticCheckResult;
        }

        private static void EvaluateNode(INode node)
        {
            var evaluationVisitor = new EvaluationVisitor();
            var evaluationResult = evaluationVisitor.VisitBase(node);
            Console.WriteLine($"Resultado de la evaluación: {evaluationResult ?? "Nulo"}");
        }

        private static void PrintSeparator()
        {
            Console.WriteLine(new string('=', 70));
        }
    }
}
