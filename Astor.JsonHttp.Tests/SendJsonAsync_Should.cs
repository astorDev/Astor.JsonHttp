using System.Net.Http;
using System.Threading.Tasks;
using ExampleWebApi;
using ExampleWebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Astor.JsonHttp.Tests
{
    [TestClass]
    public class SendJsonAsync_Should
    {
        [TestMethod]
        public async Task ReturnResultFromExpectedMethod()
        {
            var client = new WebApplicationFactory<Startup>().CreateClient();

            var postResponse = await client.SendJsonAsync("comments", HttpMethod.Post, new CommentCandidate
            {
                Result = CommentCandidate.Success
            });

            var putResponse = await client.SendJsonAsync("comments", HttpMethod.Put, new CommentCandidate
            {
                Result = CommentCandidate.Success
            });
            
            Assert.AreEqual("POST", (await postResponse.Content.ReadJsonAsync<Comment>()).From);
            Assert.AreEqual("PUT", (await putResponse.Content.ReadJsonAsync<Comment>()).From);
        }
    }
}