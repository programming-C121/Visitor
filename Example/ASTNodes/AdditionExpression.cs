using BaseVisitor.Interfaces;

namespace Visitor.ASTNodes;

public class AdditionExpression : IExpression
{
    public IExpression Left { get; }
    public IExpression Right { get; }

    public AdditionExpression(IExpression left, IExpression right)
    {
        Left = left;
        Right = right;
    }
}