using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;
using TrainingSystem.data.Contracts.IGenericReposatory;
using TrainingSystem.data.Contracts.Ispecification;
using TrainingSystem.Persistance.Context;
using TrainingSystem.Persistance.QueryGenerator;

namespace TrainingSystem.Persistance.GenericReposatory
{
    public class GenericReposatory<T, key> : IGenericReposatory<T, key> where T : BaseClass<key>
    {
        private readonly ApplicationDBContext _context;

        public GenericReposatory(ApplicationDBContext Context)
        {
            _context = Context;
        }
      
        public async Task AddEntityAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(key id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity is not null)
            {
                _context.Set<T>().Remove(entity);
            }

        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var res = await _context.Set<T>().ToListAsync();
            ;
            return res;
        }
        public async Task<T?> GetByIdAsync(key Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
          
            return entity;
        }
        public void Update(T new_T)
        {

            _context.Set<T>().Update(new_T);


        }
        public  IQueryable<T> GetAllSpecification(Ispecification<T, key> spec)
        {
            var query = _context.Set<T>();
            var entities = GenerateQyery.GenerateQueries<T, key>(query, spec);
            return  entities;
        }


    }

}
