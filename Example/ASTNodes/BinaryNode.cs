using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

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