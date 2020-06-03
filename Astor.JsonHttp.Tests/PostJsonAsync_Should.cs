using System.Net;
using System.Threading.Tasks;
using ExampleWebApi;
using ExampleWebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Astor.JsonHttp.Tests
{
    [TestClass]
    public class PostJsonAsync_Should
    {
        [TestMethod]
        public async Task SendPostMessage_ProcessedByJsonApi()
        {
            var client = new WebApplicationFactory<Startup>().CreateClient();

            var successResponse = await client.PostJsonAsync("comments", new CommentCandidate
            {
                Result = CommentCandidate.Success
            });
            
            var innerErrorResponse = await client.PostJsonAsync("comments", new CommentCandidate
            {
                Result = CommentCandidate.InternalServiceError
            });
            
            var badRequestResponse = await client.PostJsonAsync("comments", new CommentCandidate
            {
                Result = CommentCandidate.BadRequest
            });
            
            var somethingResponse = await client.PostJsonAsync("comments", new CommentCandidate
            {
                Result = "something"
            });
            
            Assert.AreEqual(HttpStatusCode.OK, successResponse.StatusCode);
            Assert.AreEqual(HttpStatusCode.InternalServerError, innerErrorResponse.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, badRequestResponse.StatusCode);
            Assert.AreEqual(HttpStatusCode.InternalServerError, somethingResponse.StatusCode);
        }
    }
}