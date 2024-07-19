using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

public class AdditionNode : BinaryNode
{
    public AdditionNode(INode left, INode right) : base(left, right)
    {
    }
}