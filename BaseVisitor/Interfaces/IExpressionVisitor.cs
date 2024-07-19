namespace BaseVisitor.Interfaces;

public interface IExpressionVisitor<out TResult>
{
    TResult? Visit(IExpression expression, params object[] additionalParams);
}