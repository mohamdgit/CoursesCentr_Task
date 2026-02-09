using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;

namespace TrainingSystem.data.Contracts.Ispecification
{
    public interface Ispecification<TEntity, Tkey> where TEntity : BaseClass<Tkey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }  
        public Expression<Func<TEntity, object>> OrderBy { get;  }
        public List<Expression<Func<TEntity, object>>> Includes { get;  } 


    }
}
