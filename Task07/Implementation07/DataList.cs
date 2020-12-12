using Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation07
{
    public class DataList
    {
        public List<Leader> Leaders { get; set; }

        public DataList()
        {
            Leaders = new List<Leader>();
        }

        public List<Leader> GetList() => Leaders;

        public void AddEmployee(Leader leader)
        {
            Leaders.Add(leader);
        }

        public void RemoveEmployee(Leader leader)
        {
            Leaders.Remove(leader);

        }

        public string GetInfo(int index)
        {
            string text = "Информация о сотруднике:" +
                            "\r\nФИО: " + Leaders[index].Name +
                            "\r\nВозраст: " + Leaders[index].Age +
                            "\r\nОпыт работы: " + Leaders[index].Experience +
                            "\r\nКоличество выполненых проектов: " + Leaders[index].CountOfProjects +
                            "\r\n" + Leaders[index].CalculateAnnualIncome() +
                            "\r\n" + Leaders[index].CheckVacationStatus() +
                            "\r\n";
            switch (Leaders[index].BusinessTripStatus)
            {
                case 1:
                    text += "\r\nИнформация о командировке:" +
                        "\r\n" + Leaders[index].InBusinessTrip();
                    break;
                case 2:
                    text += "\r\nИнформация о командировке:" +
                        "\r\n" + Leaders[index].ReturnFromBusinessTrip() +
                        "\r\n" + Leaders[index].BusinessTripDate;
                    break;
            }
            return text;
        }

        public string GenerateDateTrip()
        {
            string ResultDate = "";
            Random rnd = new Random();
            int v1 = rnd.Next(1, 15);
            int v2 = rnd.Next(1, 12);
            int v3 = 2020;

            ResultDate = $"Был в командировке с {v1}.{v2}.{v3} до {v1}.{GenerateMouthAndYear(v2, v3)}.";

            return ResultDate;
        }

        public string GenerateMouthAndYear(int v1, int v2)
        {
            string ResultDate = "";
            Random rnd = new Random();
            v1 += rnd.Next(1, 5);
            if (v1 > 12)
            {
                v1 -= 12;
                v2++;
            }
            ResultDate = $"{v1}.{v2}";
            return ResultDate;
        }

    }
}
