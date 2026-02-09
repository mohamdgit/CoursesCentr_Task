using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSystem.Shared.ErrorToReturn
{
    public class ValidationError
    {
        public string feild { get; set; }
        public IEnumerable<string> errors { get; set; }

    }
}
