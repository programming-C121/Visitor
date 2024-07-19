using BaseVisitor.Interfaces;

namespace Example.AST;

public class DivisionNode : ArithmeticBinaryNode
{
    public DivisionNode(INode left, INode right) : base(left, right)
    {
    }
}