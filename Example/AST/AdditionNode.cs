using BaseVisitor.Interfaces;

namespace Example.AST;

public class AdditionNode : ArithmeticBinaryNode
{
    public AdditionNode(INode left, INode right) : base(left, right)
    {
    }
}