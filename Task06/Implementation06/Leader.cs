using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation06
{
    public class Leader : Engineer
    {
        public override string Name { get; set; }

        public override int Age { get; set; }

        public override int Experience { get; set; }

        public override int CountOfProjects { get; set; }

        public int BusinessTripStatus { get; set; }

        public string BusinessTripDate { get; set; }

        public string Vacation { get; set; }

        public Leader(string name, int age, int experience, int countOfProjects)
        {
            Name = name;
            Age = age;
            Experience = experience;
            CountOfProjects = countOfProjects;
            BusinessTripStatus = 0;
            BusinessTripDate = "";
            Vacation = "";
        }

        public override int ToCalculateWages()
        {
            return (Experience + 1) * (CountOfProjects + 1) * 1000;
        }

        public string CalculateAnnualIncome()
        {
            return $"Годовой доход сотрудника составляет: {ToCalculateWages()*12/1000} тыс. руб.";
        }

        public override bool VacationStatus()
        {
            return BusinessTripStatus == 2 ? true : false;
        }

        public string CheckVacationStatus()
        {
            return VacationStatus() ? $"Сотруднику доступен отпуск." : $"Сотруднику недоступен отпуск.";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
