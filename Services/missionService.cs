using core_h.w.Models;
using core_h.w.Interface;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace core_h.w.Services
{
    public class MissionService :IMissionService
    {
        private List<mission> missions {get;}
        private IWebHostEnvironment  webHost;
        private string filePath;
        public MissionService(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "Mission.json");
            //this.filePath = webHost.ContentRootPath+@"/Data/Mission.json";
            using (var jsonFile = File.OpenText(filePath))
            {
                missions = JsonSerializer.Deserialize<List<mission>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        private void saveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(missions));
        }

        public List<mission> GetAll()=>missions;
        public mission Get(int id)
        {
            return missions.FirstOrDefault(m=>m.Id==id);
        }

        public void Add(mission mission)
        {
            mission.Id=missions.Max(m=>m.Id)+1;
            missions.Add(mission);
            saveToFile();
        }

        public bool Update(int id,mission newMission)
        {
            if(newMission.Id!=id)
                return false;
            var mission=missions.FirstOrDefault(m=>m.Id==id);
            if(mission==null)
                return false;
            mission.Name=newMission.Name;
            mission.Done=newMission.Done;
            saveToFile();
            return true;
        }

        public bool Delete(int id)
        {
            var mission = missions.FirstOrDefault(m => m.Id == id);
            if (mission == null)
                return false;
            missions.Remove(mission);
            saveToFile();
            return true;
        }
    }
}