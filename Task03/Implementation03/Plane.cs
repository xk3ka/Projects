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

        private Chassis ChassisS { get; set; }

        private Chassis ChassisBL { get; set; }

        private Chassis ChassisBR { get; set; }

        private Wing WingLeft { get; set; }

        private Wing WingRight { get; set; }

        public Plane(Engine engine,Chassis chassisS, Chassis chassis, Wing wing)
        {
            Engine = engine;
            ChassisS = chassisS;
            ChassisBL = chassis;
            ChassisBR = chassis;
            WingLeft = wing;
            WingRight = wing;
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

        public void SetNewChassis(Chassis Chassis)
        {
            ChassisBL = Chassis;
            ChassisBR = Chassis;
        }

        public string GetInfoAboutPlane()
        {
            return "Двигатель: " + Engine.GetInfo() +
                    "\nЛевое крыло: " + WingLeft.GetInfo() +
                    "\nПравое крыло: " + WingRight.GetInfo() +
                    "\nПереднее шасси: " + ChassisS.GetInfo() +
                    "\nЛевое заднее шасси: " + ChassisBL.GetInfo() +
                    "\nПравое заднее шасси: " + ChassisBR.GetInfo();
        }
    }
}
