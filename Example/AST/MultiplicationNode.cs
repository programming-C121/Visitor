using BaseVisitor.Interfaces;

namespace Example.AST;

public class MultiplicationNode : BinaryNode
{
    public MultiplicationNode(INode left, INode right) : base(left, right)
    {
    }
}