namespace BaseVisitor.Interfaces;

public interface IVisitor<out TResult>
{
    TResult? VisitCore(INode node, params object[] additionalParams);
}