using core_h.w.Models;
using System.Collections.Generic;
using System.Linq;

namespace core_h.w.interface
{
    public interface IMissionService
    {
        private List<mission> missions=new List<mission>;

        public List<mission> GetAll();
        public mission Get(int id);

        public void Add(mission mission);

        public bool Update(int id,mission newMission);

        public bool Delete(int id);
    }
}