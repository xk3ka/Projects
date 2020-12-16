using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation03
{
    public class Plane
    {
        private string Map { get; set; }

        private Engine Engine { get; set; }

        private List<Chassis> Chassis { get; set; }

        private List<Wing> Wings { get; set; }

        public Plane(Engine engine, List<Chassis> chassis, List<Wing> wings)
        {
            Engine = engine;
            Chassis = chassis;
            Wings = wings;
        }

        public string Fly()
        {
            return "Летим по рейсу: " + Map;
        }

        public void SetRoute(string map)
        {
            Map = map;
        }

        public string GetRoute()
        {
            return Map;
        }

        public void SetNewChassis(List<Chassis> chassis)
        {
            Chassis[1] = chassis[0];
            Chassis[2] = chassis[1];
        }

        public string GetInfoAboutPlane()
        {
            return "Двигатель: " + Engine.GetInfo() +
                    "\nЛевое крыло: " + Wings[0].GetInfo() +
                    "\nПравое крыло: " + Wings[1].GetInfo() +
                    "\nПереднее шасси: " + Chassis[0].GetInfo() +
                    "\nЛевое заднее шасси: " + Chassis[1].GetInfo() +
                    "\nПравое заднее шасси: " + Chassis[2].GetInfo();
        }
    }
}
