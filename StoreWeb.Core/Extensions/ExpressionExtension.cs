﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Core.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T,bool>> True<T>() { return p => true; }
        public static Expression<Func<T,bool>> False<T>() { return f => false; }
        public static Expression<T>Or<T>(this Expression<T> left, Expression<T> right)
        {
            return MakeBinary(left, right, Expression.OrElse);
        }
        public static Expression<T>And<T>(this Expression<T> left, Expression<T> right)
        {
            return MakeBinary(left, right, Expression.AndAlso);
        }
        private static Expression<T>  MakeBinary<T>(this Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> func)
        {
            return MakeBinary((LambdaExpression)left, right, func) as Expression<T>;
        }
        private static LambdaExpression MakeBinary(this LambdaExpression left,LambdaExpression right, Func<Expression, Expression, Expression> func)
        {
            var data = Combinate(right.Parameters, left.Parameters).ToArray();
            right = ParameterReplace.Replace(right, data) as LambdaExpression;
            return Expression.Lambda(func(left.Body, right.Body), left.Parameters.ToArray());
        }

        private static IEnumerable<KeyValuePair<T, T>> Combinate<T>(IEnumerable<T> left, IEnumerable<T> right)
        {
            var a = left.GetEnumerator();
            var b = right.GetEnumerator();
            while (a.MoveNext() && b.MoveNext())
                yield return new KeyValuePair<T, T>(a.Current, b.Current);
        }
    }
    internal sealed class ParameterReplace : ExpressionVisitor
    {
        public static Expression Replace(Expression e,IEnumerable<KeyValuePair<ParameterExpression,ParameterExpression>> paramList)
        {
            var item = new ParameterReplace(paramList);
            return item.Visit(e);
        }
        private readonly Dictionary<ParameterExpression, ParameterExpression> _parameters;
        public ParameterReplace(IEnumerable<KeyValuePair<ParameterExpression,ParameterExpression>> paramList)
        {
            _parameters = paramList.ToDictionary(p => p.Key, p => p.Value, new ParameterEquality());
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression result;
            if (_parameters.TryGetValue(p, out result))
                return result;
            return base.VisitParameter(p);
        }
        private class ParameterEquality : IEqualityComparer<ParameterExpression>
        {
            public bool Equals(ParameterExpression x, ParameterExpression y)
            {
                if (x == null || y == null)
                    return false;
                return x.Type == y.Type;
            }

            public int GetHashCode(ParameterExpression obj)
            {
                if (obj == null)
                    return 0;
                return obj.Type.GetHashCode();
            }
        }
    }
}
