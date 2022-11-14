using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApartmentController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] Add.Command command)
        {
            Console.WriteLine("llego");
            return HandleResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult> test()
        {
             Console.WriteLine("llego2");
            return Ok("todo bien");
        }

    }
}