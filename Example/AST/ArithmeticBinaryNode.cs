using BaseVisitor.Interfaces;

namespace Example.AST;

public abstract class ArithmeticBinaryNode : BinaryNode
{
    public ArithmeticBinaryNode(INode left, INode right) : base(left, right)
    {
    }
}