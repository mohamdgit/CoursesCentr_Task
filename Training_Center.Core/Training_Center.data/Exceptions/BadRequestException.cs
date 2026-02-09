using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSystem.data.Exceptions
{
    public class BadRequestException(List<string> Errors) : Exception("Validation Faild")
    {
        public List<string> Errors = Errors;
    }
    
}
