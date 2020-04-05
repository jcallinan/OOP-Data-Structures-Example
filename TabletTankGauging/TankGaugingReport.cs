using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletTankGauging
{
    public class TankGaugingReport
    {
        public string[] Tanks;
        public string[] Products;
        public string[] Feet;
        public string[] Inches;
        public string[] InchesPart;
        public string[] Temperature;
        public string[] Descriptions;
        public string[] InageOutage;
        public string[] DateTimeDone;
        public string[] TankStatus;
        public bool[] EmergContainmentValve;
        public bool[] HazardConditions;
        public bool[] WaterCheck;
        public bool[] ActionRequired;
        public bool[] InspectionRecord;
        public bool IsAll;
        public int TankCount;
        public string Username;
        public TankGaugingReport(int numberOfTanks)
        {
            Tanks = new string[numberOfTanks];
            Products = new string[numberOfTanks];
            Feet = new string[numberOfTanks];
            Inches = new string[numberOfTanks];
            InchesPart = new string[numberOfTanks];
            Temperature = new string[numberOfTanks];
            Descriptions = new string[numberOfTanks];
            InageOutage = new string[numberOfTanks];
            DateTimeDone = new string[numberOfTanks];
            TankStatus = new string[numberOfTanks];
            EmergContainmentValve = new bool[numberOfTanks];
            HazardConditions = new bool[numberOfTanks];
            WaterCheck = new bool[numberOfTanks];
            ActionRequired = new bool[numberOfTanks];
            InspectionRecord = new bool[numberOfTanks];
            Username = Environment.UserName;


        }
    }
}
