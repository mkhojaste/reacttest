using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly DataContext _context;
        public SchedulerController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("take")]
        public async Task<ActionResult<short>> GetTurn()
        {
            var label = _context.Turns.Max(t => t.Label);

            if(DateTime.Now.Day > _context.Turns.Max(t => t.ExportTime.Day)){
                label = 0;
            }
            var item = new Turn()
            {
                Id = 0,
                Label = ++label,
                Gender = Gender.Male,
                ExportTime = DateTime.Now,
                IsActive = true
            };
            var a = _context.Turns.Add(item);
            var success = (await _context.SaveChangesAsync() > 0);
            return Ok(item.Label);
        }
        [HttpGet("next")]
        public async  Task<ActionResult<Turn>> ReciptNext() {
            var label =  _context.Turns.Where(t=>(t.ExportTime.Date == DateTime.Now.Date && t.CallOffset == null)).Min(t => t.Label);
            var current = _context.Turns.FirstOrDefault(t => t.Label == label && t.CallOffset == null);
            current.CallOffset = DateTime.Now -current.ExportTime; 
            await _context.SaveChangesAsync();
            return Ok(current);
        }
    }

}