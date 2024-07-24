using BaseVisitor.Interfaces;

namespace Example.AST;

public class ProgramNode(List<INode> statements) : INode
{
    public List<INode> Statements { get; } = statements;
}