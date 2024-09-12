using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    //private readonly Expression<Func<T, bool>>? criteria;
    protected BaseSpecification() : this(null){}
    // public BaseSpecification(Expression<Func<T,bool>>? criteria)
    // {
    //     this.criteria = Criteria;   
    // }
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy {get; private set;}

    public Expression<Func<T, object>>? OrderByDescending {get; private set;}

    public bool IsDestinc {get; private set;}

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    protected void ApplyDistinct()
    {
        IsDestinc = true;
    }
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria) : BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null!){}
    public Expression<Func<T, TResult>>? Select {get; private set;}

    protected void AddSelct(Expression<Func<T, TResult>> selectexpression)
    {
        Select = selectexpression;
    }
}
