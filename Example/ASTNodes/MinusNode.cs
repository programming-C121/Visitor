using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

public class MinusNode: BinaryNode
{
    public MinusNode(INode left, INode right) : base(left, right)
    {
    }
}