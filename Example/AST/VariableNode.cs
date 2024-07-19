using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

public class VariableNode : INode
{
    public string Name { get; }

    public VariableNode(string name)
    {
        Name = name;
    }
}