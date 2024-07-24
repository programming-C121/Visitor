using BaseVisitor.Interfaces;

namespace Example.AST;

public class VariableDeclarationNode(string name, INode value) : INode
{
    public string Name { get; } = name;
    public INode Value { get; } = value;
}