using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sharpener.Core 
{
    public static class ExpressionExtension
    {
        public static string GetMemberName(this Expression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var callExpression = expression as MethodCallExpression;
            if (callExpression != null) return callExpression.Method.Name;

            var memberExpression = expression as MemberExpression;
            if (memberExpression != null) return memberExpression.Member.Name;

            var parameterExpression = expression as ParameterExpression;
            if (parameterExpression != null) return parameterExpression.Name;

            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null) return GetMemberName(unaryExpression.Operand);

            return null;
        }

        public static T GetValueOfParameter<T>(this Expression parameter) where T : class
        {
            return GetValueOfParameter(parameter) as T;
        }

        public static object GetValueOfParameter(this Expression parameter)
        {
            var lambda = Expression.Lambda(parameter);
            var compiledExpression = lambda.Compile();
            var value = compiledExpression.DynamicInvoke();
            return value;
        }

        public static IDictionary<string, object> GetTypedFunctionInputValues<TSource, TResult>(this Expression<Func<TSource, TResult>> method)
        {
            var dict = new Dictionary<string, object>();

            var methodCall = method.Body as MethodCallExpression;
            if (methodCall != null)
            {
                var actualParams = methodCall.Arguments;
                dict = actualParams.ToDictionary(x => x.GetMemberName(), x => x.GetValueOfParameter());
            }

            return dict;
        }

        public static IEnumerable<object> GetFunctionInputValues<TSource, TResult>(this Expression<Func<TSource, TResult>> method)
        {
            return GetTypedFunctionInputValues(method).Values;
        }


    }
}
