using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Apartment;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApartmentController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult> GetApartments([FromQuery] PagingParams param)
        {
            return HandleResult(await Mediator.Send(new Application.Apartment.List.Query { Params = param }));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditApartments(Guid id , ApartmentDTO apartment)
        {
            apartment.Id = id;
            return HandleResult(await Mediator.Send(new Application.Apartment.Edit.Command { Apartment = apartment }));
        }

    }
}