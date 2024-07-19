using BaseVisitor.Interfaces;

namespace Example.AST;

public class SubtractionNode : ArithmeticBinaryNode
{
    public SubtractionNode(INode left, INode right) : base(left, right)
    {
    }
}