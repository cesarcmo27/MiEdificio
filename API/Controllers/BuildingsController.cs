using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class BuildingsController : BaseApiController
    {
        private readonly DataContext _context;

        public BuildingsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(Guid id)
        {
            return await _context.Buildings.FindAsync(id);
        }


    }
}