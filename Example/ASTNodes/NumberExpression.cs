using BaseVisitor.Interfaces;

namespace Visitor.ASTNodes;

public class NumberExpression : IExpression
{
    public int Value { get; }

    public NumberExpression(int value)
    {
        Value = value;
    }
}