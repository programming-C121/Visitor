using BaseVisitor.Interfaces;

namespace Example.AST;

public class ProgramNode : INode
{
    public List<INode> Statements { get;}
    
    public ProgramNode(List<INode> statements)
    {
        Statements = statements;
    }
}