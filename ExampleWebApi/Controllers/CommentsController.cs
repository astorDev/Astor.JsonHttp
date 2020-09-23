using System;
using ExampleWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Controllers
{
    [ApiController]
    [Route("comments")]
    public class CommentsController : Controller
    {
        [HttpPost]
        public IActionResult CreateComment(CommentCandidate candidate)
        {
            switch (candidate.Result)
            {
                case CommentCandidate.Success:
                    return this.Ok(new Comment
                    {
                        From = "POST",
                        PassedResult = candidate.Result
                    });
                case CommentCandidate.BadRequest:
                    return this.BadRequest();
                case CommentCandidate.InternalServiceError:
                    throw new NotImplementedException();
                default:
                    throw new InvalidOperationException();
            }
        }

        [HttpPut]
        public Comment PutComment(CommentCandidate candidate)
        {
            return new Comment
            {
                From = "PUT",
                PassedResult = candidate.Result
            };
        }

        [HttpPatch]
        public Comment PatchComment(CommentCandidate candidate)
        {
            return new Comment
            {
                From = "PATCH",
                PassedResult = candidate.Result
            };
        }
    }
}