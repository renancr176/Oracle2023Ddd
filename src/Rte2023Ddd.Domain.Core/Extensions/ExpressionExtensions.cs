﻿using System.Linq.Expressions;

namespace Rte2023Ddd.Domain.Core.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> AndAlso<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.AndAlso(
            Expression.Invoke(left, param),
            Expression.Invoke(right, param)
        );
        var lambda = Expression.Lambda<Func<T, bool>>(body, param);
        return lambda;
    }

    public static Expression<Func<T, bool>> OrElse<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.OrElse(
            Expression.Invoke(left, param),
            Expression.Invoke(right, param)
        );
        var lambda = Expression.Lambda<Func<T, bool>>(body, param);
        return lambda;
    }
}