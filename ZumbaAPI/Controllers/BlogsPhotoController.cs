using System;
using System.Threading.Tasks;
using Application.BlogsPhoto;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ZumbaAPI.Controllers
{
    public class BlogsPhotoController : BaseController
    {
        [HttpPost("{id}")]
        public async Task<ActionResult<BlogPhoto>> Add([FromForm] AddBlogPhoto.Command command, Guid id)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }
    }
}