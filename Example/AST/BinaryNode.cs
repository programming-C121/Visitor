using BaseVisitor.Interfaces;

namespace Example.AST;

public abstract class BinaryNode : INode
{
    public INode Left { get; }
    public INode Right { get; }

    public BinaryNode(INode left, INode right)
    {
        Left = left;
        Right = right;
    }
}