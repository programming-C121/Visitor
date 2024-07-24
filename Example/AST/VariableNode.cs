using BaseVisitor.Interfaces;

namespace Example.AST;

public class VariableNode(string name) : INode
{
    public string Name { get; } = name;
}