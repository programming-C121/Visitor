namespace BaseVisitor.Interfaces;

public interface IVisitor<out TResult>
{
    TResult? Visit(INode node, params object[] additionalParams);
}