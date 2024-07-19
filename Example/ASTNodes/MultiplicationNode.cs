using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

public class MultiplicationNode : BinaryNode
{
    public MultiplicationNode(INode left, INode right) : base(left, right)
    {
    }
}