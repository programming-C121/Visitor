using BaseVisitor.Interfaces;

namespace Example.AST;

public class DivisionNode : BinaryNode
{
    public DivisionNode(INode left, INode right) : base(left, right)
    {
    }
}