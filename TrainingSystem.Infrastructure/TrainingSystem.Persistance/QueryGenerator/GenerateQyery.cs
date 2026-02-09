using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;
using TrainingSystem.data.Contracts.Ispecification;

namespace TrainingSystem.Persistance.QueryGenerator
{
    public static class GenerateQyery
    {
        public static IQueryable<Entity> GenerateQueries<Entity, key>(IQueryable<Entity> basequery, Ispecification<Entity, key> spec)
            where Entity : BaseClass<key>
        {
            var query = basequery;
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            if (spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);

           

            if (spec.Includes is not null )
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
           
            return query;
        }
    }
}
