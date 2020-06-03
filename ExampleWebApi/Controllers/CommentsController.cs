using System;
using ExampleWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Controllers
{
    [ApiController]
    [Route("comments")]
    public class CommentsController : Controller
    {
        public IActionResult CreateComment(CommentCandidate candidate)
        {
            switch (candidate.Result)
            {
                case CommentCandidate.Success:
                    return this.Ok();
                case CommentCandidate.BadRequest:
                    return this.BadRequest();
                case CommentCandidate.InternalServiceError:
                    throw new NotImplementedException();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}