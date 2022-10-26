using Application.Groups;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GroupController : BaseApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

         [HttpPost]
        public async Task<ActionResult> CreateGroup(Group group)
        {
            return Ok(await Mediator.Send(new Create.Command{Group = group}));
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> EditGroup(Guid id,Group group)
        {
            group.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Group = group}));
        }
    }
}