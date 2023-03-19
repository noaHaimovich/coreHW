using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using core_h.w.Models;
using core_h.w.Interface;

namespace core_h.w.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class missionController : ControllerBase
    {

        private IMissionService MissionService;
        public missionController(IMissionService MissionService)
        {
            this.MissionService=MissionService;
        }

        [HttpGet]
        public IEnumerable<mission> Get()
        {
            return MissionService.GetAll();

        }

        [HttpGet("{id}")]
        public ActionResult<mission> Get(int id)
        {
            var m = MissionService.Get(id);
            if (m == null)
                return NotFound();
             return m;
        }

        [HttpPost]
        public ActionResult Post(mission mission)
        {
            MissionService.Add(mission);

            return CreatedAtAction(nameof(Post), new { id = mission.Id }, mission);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, mission mission)
        {
            if (! MissionService.Update(id, mission))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (! MissionService.Delete(id))
                return NotFound();
            return NoContent();            
        }

    }
}
