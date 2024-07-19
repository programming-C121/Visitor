using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

public class NumberNode : INode
{
    public int Value { get; }

    public NumberNode(int value)
    {
        Value = value;
    }
}