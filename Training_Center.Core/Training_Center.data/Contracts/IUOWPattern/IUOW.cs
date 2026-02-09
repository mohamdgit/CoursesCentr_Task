using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models;
using TrainingSystem.data.Contracts.IGenericReposatory;

namespace TrainingSystem.data.Contracts.IUOWPattern
{
    public interface IUOW
    {
        public IGenericReposatory<T, key> GenerateRepo<T, key>() where T : BaseClass<key>;
        public Task<int> SaveChanges();
    }
}
