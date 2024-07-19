using BaseVisitor.Interfaces;

namespace BaseVisitor;

/// <summary>
/// Base class for expression visitors that implements the discovery logic with support for additional parameters.
/// </summary>
public abstract class ExpressionVisitorBase<TResult> : IExpressionVisitor<TResult>
{
    /// <summary>
    /// Visits an expression by dynamically invoking the appropriate Visit method with additional parameters.
    /// </summary>
    /// <typeparam name="TResult">The return type of the Visit method.</typeparam>
    /// <param name="expression">The expression to visit.</param>
    /// <param name="additionalParams">Additional parameters to pass to the Visit method.</param>
    /// <returns>The result of the Visit method.</returns>
    public TResult? Visit(IExpression expression, params object[] additionalParams)
    {
        // Combine the expression type with the types of additional parameters
        var parameterTypes = new[] { expression.GetType() }
            .Concat(additionalParams.Select(p => p.GetType()))
            .ToArray();

        // Find a Visit method in this class that matches the parameter types
        var method = GetType().GetMethod("Visit", parameterTypes);

        if (method != null)
        {
            // If a matching Visit method is found, invoke it with the expression and additional parameters
            var parameters = new[] { expression }.Concat(additionalParams).ToArray();
            return (TResult?)method.Invoke(this, parameters);
        }

        // If no matching Visit method is found, throw an exception
        throw new NotSupportedException($"No Visit method found for {expression.GetType().Name} with the given additional parameters");
    }
}