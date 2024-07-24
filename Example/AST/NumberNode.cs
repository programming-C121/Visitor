using BaseVisitor.Interfaces;

namespace Example.AST;

public class NumberNode(int value) : INode
{
    public int Value { get; } = value;
}