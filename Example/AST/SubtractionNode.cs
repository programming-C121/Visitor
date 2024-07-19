using BaseVisitor.Interfaces;

namespace Example.AST;

public class SubtractionNode : BinaryNode
{
    public SubtractionNode(INode left, INode right) : base(left, right)
    {
    }
}