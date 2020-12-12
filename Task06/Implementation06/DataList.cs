using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation06
{
    public class DataList
    {
        private List<Leader> Example = new List<Leader> {new Leader("Калинин Вадим Сергеевич",18,0,0),
            new Leader("Калинин Артем Владимирович",24,2,4), 
            new Leader("Патока Никита Дмитриевич",37,8,23) };

        public List<Leader> Leaders { get; set; }
        
        public DataList()
        {
            Leaders = new List<Leader>();
        }

        public List<Leader> GetList() => Leaders;

        public void LoadExample()
        {
            Leaders = null;
            Leaders = Example;
        }

        public void AddEmployee(Leader leader)
        {
            Leaders.Add(leader);
        }

        public void RemoveEmployee(Leader leader)
        {
            Leaders.Remove(leader);

        }

        public void InBusinessTrip(int index)
        {
            Leaders[index].BusinessTripStatus = 1;
            Leaders[index].Vacation = Leaders[index].CheckVacationStatus();
        }

        public void ReturnFromBusinessTrip(int index)
        {

            Leaders[index].BusinessTripStatus = 2;
            Leaders[index].BusinessTripDate = GenerateDateTrip();
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
