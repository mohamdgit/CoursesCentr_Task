using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;
using TrainingSystem.data.Contracts.Ispecification;

namespace TrainingSystem.Service.SpecificationPattern
{
    public class BaseSpecification<entity, key> : Ispecification<entity, key> where entity : BaseClass<key>
    {
        public BaseSpecification(Expression<Func<entity, bool>> criteria)
        {
            Criteria = criteria;
        }

       
        public Expression<Func<entity, bool>> Criteria { get; private set; }
        public Expression<Func<entity, object>> OrderBy { get; private set; } 
        public List<Expression<Func<entity, object>>> Includes { get; private set; } = new List<Expression<Func<entity, object>>>(); 

        public void Addincludesfunc(Expression<Func<entity, object>> include)
        {
            Includes.Add(include); 
        }

       

        public void OrderByAscFun(Expression<Func<entity, object>> orderBy)
        {
            this.OrderBy = orderBy;
        }

       

    }
}
