﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification()
        {
                
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Orderby { get; private set; }

        public Expression<Func<T, object>> OrderbyDescending { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression) {
            Includes.Add(includeExpression);
            
        } 
        protected void AddOrderby(Expression<Func<T, object>> OrderbyExpression) {
            Orderby = OrderbyExpression;
        }
        protected void AddOrderbyDescending(Expression<Func<T, object>> OrderbyDescendingExpression) {
            OrderbyDescending = OrderbyDescendingExpression;
        }
    
    }
}
