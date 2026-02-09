using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;
using TrainingSystem.data.Contracts.IGenericReposatory;
using TrainingSystem.data.Contracts.IUOWPattern;
using TrainingSystem.Persistance.Context;

namespace TrainingSystem.Persistance.UOWPattern
{
    public class UOW:IUOW
    {
        private readonly ApplicationDBContext context;

        public UOW(ApplicationDBContext context)
        {
            this.context = context;
        }

      

        public IGenericReposatory<T, key> GenerateRepo<T, key>() where T : BaseClass<key>
        {
            Dictionary<Type, object> repos = [];
            var entity = typeof(T);
            if (repos.ContainsKey(entity))
            {
                return (IGenericReposatory<T, key>)repos[entity];
            }
            else
            {
                var repo_of_entity = new GenericReposatory.GenericReposatory<T, key>(context);
                repos.Add(entity, repo_of_entity);
                return repo_of_entity;
               
            }

        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
