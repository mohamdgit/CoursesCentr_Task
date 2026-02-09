using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;
using TrainingSystem.data.Contracts.Ispecification;

namespace TrainingSystem.data.Contracts.IGenericReposatory
{
    public interface IGenericReposatory<T, key> where T : BaseClass<key>
    {
        
       IQueryable<T> GetAllSpecification(Ispecification<T, key> spec);
        public Task<IEnumerable<T>>  GetAllAsync();
        Task AddEntityAsync(T entity);
        void Update(T new_T);
        void Delete(key id);
        Task<T> GetByIdAsync(key Id);

    }
}
