using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class Leader : Engineer
    {
        public override string Name { get; set; }

        public override int Age { get; set; }

        public override int Experience { get; set; }

        public override int CountOfProjects { get; set; }

        public override int BusinessTripStatus { get; set; }

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

        private string GenerateDateTrip()
        {
            Random rnd = new Random();
            int v1 = rnd.Next(1, 15);
            int v2 = rnd.Next(1, 12);
            int v3 = 2020;
            return $"Был в командировке с {v1}.{v2}.{v3} до {v1}.{GenerateMouthAndYear(v2, v3)}.";
        }

        private string GenerateMouthAndYear(int v1, int v2)
        {
            Random rnd = new Random();
            v1 += rnd.Next(1, 5);
            if (v1 > 12)
            {
                v1 -= 12;
                v2++;
            }
            return $"{v1}.{v2}";
        }

        public string GetInfo(int index)
        {
            string text = "Информация о сотруднике:" +
                            "\r\nФИО: " + Name +
                            "\r\nВозраст: " + Age +
                            "\r\nДолжность: Руководитель" +
                            "\r\nОпыт работы: " + Experience +
                            "\r\nКоличество выполненых проектов: " + CountOfProjects +
                            "\r\n" + CalculateAnnualIncome() +
                            "\r\n" + CheckVacationStatus() +
                            "\r\n" +
                            "\r\nИнформация о командировке: ";
            switch (BusinessTripStatus)
            {
                case 0:
                    text += "\r\n Сотрудник не был в командировке";
                    break;
                case 1:
                    text += "\r\n Сотрудник в командировке";
                    break;
                case 2:
                    text += "\r\n Сотрудник вернулся из командировки"+
                        "\r\n" + BusinessTripDate;
                    break;
            }
            return text;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
