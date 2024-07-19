using BaseVisitor.Interfaces;

namespace Visitor.ASTNodes;

public class MultiplicationExpression : IExpression
{
    public IExpression Left { get; }
    public IExpression Right { get; }

    public MultiplicationExpression(IExpression left, IExpression right)
    {
        Left = left;
        Right = right;
    }
}