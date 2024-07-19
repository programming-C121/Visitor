using BaseVisitor.Interfaces;

namespace Example.AST;

public class AdditionNode : BinaryNode
{
    public AdditionNode(INode left, INode right) : base(left, right)
    {
    }
}