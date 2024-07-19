using BaseVisitor.Interfaces;

namespace Example.ASTNodes;

public class VariableDeclarationNode : INode
{
    public string Name { get; }
    public INode Value { get; }

    public VariableDeclarationNode(string name, INode value)
    {
        Name = name;
        Value = value;
    }
}