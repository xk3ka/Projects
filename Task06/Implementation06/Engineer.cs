using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation06
{
    public abstract class Engineer : IEmployee
    {
        public abstract string Name { get; set; }

        public abstract int Age { get; set; }

        public abstract int Experience { get; set; }

        public abstract int CountOfProjects { get; set; }

        public string InBusinessTrip()
        {
            return $"'{Name}' отправлен в командировку.";
        }

        public string ReturnFromBusinessTrip()
        {
            return $"'{Name}' вернулся из командировки.";
        }

        public abstract int ToCalculateWages();

        public abstract bool VacationStatus();
    }
}
