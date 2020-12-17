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
        public List<Engineer> Engineers { get; set; }

        public DataList()
        {
            Engineers = new List<Engineer>();
        }

        public void AddLeader(Leader eng)
        {
            Engineers.Add(eng);
        }

        public void AddJuniorEngineer(JuniorEngineer eng)
        {
            Engineers.Add(eng);
        }

        public void AddSeniorEngineer(SeniorEngineer eng)
        {
            Engineers.Add(eng);
        }

        public bool Contains(string name)
        {
            foreach (Engineer ListEng in Engineers)
            {
                if (name == ListEng.Name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
