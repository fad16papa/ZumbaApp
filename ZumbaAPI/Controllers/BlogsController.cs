using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Blogs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ZumbaAPI.Controllers
{
    public class BlogsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Blog>>> List()
        {
            return await Mediator.Send(new ListBlog.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Details(Guid id)
        {
            return await Mediator.Send(new DetailsBlog.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateBlog.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, EditBlog.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteBlog.Command { Id = id });
        }
    }
}