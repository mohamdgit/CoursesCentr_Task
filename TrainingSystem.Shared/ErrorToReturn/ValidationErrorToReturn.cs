using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSystem.Shared.ErrorToReturn
{
    public class ValidationErrorToReturn
    {

        public int statuscode { get; set; }
        public string Massege { get; set; }
        public IEnumerable<ValidationError>? ValidationError { get; set; }

    }
}
