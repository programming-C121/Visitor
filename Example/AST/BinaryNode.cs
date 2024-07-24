using BaseVisitor.Interfaces;

namespace Example.AST;

public abstract class BinaryNode(INode left, INode right) : INode
{
    public INode Left { get; } = left;
    public INode Right { get; } = right;
}