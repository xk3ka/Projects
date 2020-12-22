using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public abstract class Engineer : IEmployee
    {
        public abstract string Name { get; set; }

        public abstract int Age { get; set; }

        public abstract int Experience { get; set; }

        public abstract int CountOfProjects { get; set; }

        public abstract int BusinessTripStatus { get; set; }

        public string InBusinessTrip()
        {
            if (BusinessTripStatus != 0)
            {
                throw new SystemException();
            }
            BusinessTripStatus = 1;
            return $"'{Name}' отправлен в командировку.";
        }

        public string ReturnFromBusinessTrip()
        {
            if (BusinessTripStatus != 1)
            {
                throw new SystemException();
            }
            GenerateDateTrip();
            BusinessTripStatus = 2;
            return $"'{Name}' вернулся из командировки.";
        }

        public abstract void GenerateDateTrip();

        public abstract int ToCalculateWages();

        public abstract bool VacationStatus();

        public abstract string GetInfo();
    }
}
