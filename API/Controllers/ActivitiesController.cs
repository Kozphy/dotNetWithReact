using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await base.Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/activities/{id}
        public  async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await base.Mediator.Send(new Details.Query()
            {
                Id = id
            });
        }
    }
}