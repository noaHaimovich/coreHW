using core_h.w.Models;
using System.Collections.Generic;
using System.Linq;

namespace core_h.w.Controllers
{
    public static class MissionService
    {
        private static List<mission> missions=new List<mission>
        {
            new mission {Id=1, Name="Noa",Description="wash the floor"},
            new mission {Id=2, Name="Michal",Description="do home work"},
        };

        public static List<mission> GetAll()=>missions;
        public static mission Get(int id)
        {
            return missions.FirstOrDefault(m=>m.Id==id);
        }

        public static void Add(mission mission)
        {
            mission.Id=missions.Max(m=>m.Id)+1;
            missions.Add(mission);
        }

        public static bool Update(int id,mission newMission)
        {
            if(newMission.Id!=id)
                return false;
            var mission=missions.FirstOrDefault(m=>m.Id==id);
            mission.Name=newMission.Name;
            mission.Description=newMission.Description;
            return true;
        }

        public static bool Delete(int id)
        {
            var mission = missions.FirstOrDefault(m => m.Id == id);
            if (mission == null)
                return false;
            missions.Remove(mission);
            return true;
        }
    }
}