namespace BaseVisitor.Interfaces;

public interface IVisitor<out TResult>
{
    TResult? VisitBase(INode node, params object[] additionalParams);
}