using Application.Buildings;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class BuildingsController : BaseApiController
    {
      
        [HttpGet]
        public async Task<ActionResult<List<Building>>> GetBuildings()
        {
            return await Mediator.Send(new List.Query());
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(Guid id)
        {
            return Ok();
        }


    }
}