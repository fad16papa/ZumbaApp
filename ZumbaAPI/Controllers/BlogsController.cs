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

        [HttpPost]
        public async Task<ActionResult<Unit>> Register(CreateBlog.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}