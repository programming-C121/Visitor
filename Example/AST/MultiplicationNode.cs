using BaseVisitor.Interfaces;

namespace Example.AST;

public class MultiplicationNode : ArithmeticBinaryNode
{
    public MultiplicationNode(INode left, INode right) : base(left, right)
    {
    }
}