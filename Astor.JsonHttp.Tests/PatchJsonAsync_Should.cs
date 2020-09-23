using System.Threading.Tasks;
using ExampleWebApi;
using ExampleWebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Astor.JsonHttp.Tests
{
    [TestClass]
    public class PatchJsonAsync_Should
    {
        [TestMethod]
        public async Task CallExpectedMethod()
        {
            var client = new WebApplicationFactory<Startup>().CreateClient();

            var response = await client.PatchJsonAsync("comments", new CommentCandidate
            {
                Result = "any"
            });
            
            Assert.AreEqual("PATCH", (await response.Content.ReadJsonAsync<Comment>()).From);
        }
    }
}