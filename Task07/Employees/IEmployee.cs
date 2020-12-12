using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public interface IEmployee
    {
        string Name { get; set; }

        string InBusinessTrip();

        string ReturnFromBusinessTrip();
    }
}
