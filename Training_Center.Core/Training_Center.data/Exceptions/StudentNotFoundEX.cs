using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSystem.data.Exceptions
{
    public sealed class StudentNotFoundEX(int id) : NotfoundEx($" No Student with {id} Found!!")
    {
    }
}
