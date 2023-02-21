using core_h.w.Models;
using core_h.w.Interface;
using System.Collections.Generic;
using System.Linq;

namespace core_h.w.Services
{
    public class MissionService :IMissionService
    {
        private List<mission> missions=new List<mission>
        {
            new mission {Id=1, Name="Noa",Description="wash the floor"},
            new mission {Id=2, Name="Michal",Description="do home work"},
        };

        public List<mission> GetAll()=>missions;
        public mission Get(int id)
        {
            return missions.FirstOrDefault(m=>m.Id==id);
        }

        public void Add(mission mission)
        {
            mission.Id=missions.Max(m=>m.Id)+1;
            missions.Add(mission);
        }

        public bool Update(int id,mission newMission)
        {
            if(newMission.Id!=id)
                return false;
            var mission=missions.FirstOrDefault(m=>m.Id==id);
            mission.Name=newMission.Name;
            mission.Description=newMission.Description;
            return true;
        }

        public bool Delete(int id)
        {
            var mission = missions.FirstOrDefault(m => m.Id == id);
            if (mission == null)
                return false;
            missions.Remove(mission);
            return true;
        }
    }
}