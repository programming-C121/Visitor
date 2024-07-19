using BaseVisitor.Interfaces;

namespace Example.AST;

public class VariableNode : INode
{
    public string Name { get; }

    public VariableNode(string name)
    {
        Name = name;
    }
}