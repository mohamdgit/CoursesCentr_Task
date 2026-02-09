using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.abstraction.ICentreService;

namespace TrainingSystem.abstraction.IServiceProviderPattern
{
    public interface IServicemanager
    {
        public IStudentService StudentService { get; }

    }
}
