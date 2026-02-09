using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.abstraction.ICentreService;
using TrainingSystem.data.Contracts.IUOWPattern;
using TrainingSystem.Service.CenterService;

namespace TrainingSystem.abstraction.IServiceProviderPattern.ServiceProviderPattern
{
    public class Servicemanager(IUOW unitofWork, IMapper map) : IServicemanager
    {
        private readonly Lazy<IStudentService> LazyStudentService = new Lazy<IStudentService>(() => new StudentService( unitofWork, map));
        public IStudentService StudentService => LazyStudentService.Value;
    }
}
