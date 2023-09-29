using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TwitterXScheduler.Controllers.Models;
using DotNetOpenAuth.AspNet.Clients;

namespace TwitterXScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostTweet(PostTweetRequestDto newTweet)
        {
            var client = new TwitterClient("A8NhQhPnjBUtGHclIXma4pDRY",
                "GuuBQzIyUL1I6sRLp6sqhGKtjot5RD5OoZACls7PcZa6ymTSBi",
                "1016346221286391808-GYCHgGSpcEnpNpNJI76Pu1N44M7zlt",
                "WX3mJPMir5DevUxRi7g637gOJ5sBR4y7q37REApFEIBSe"
               );

            var result = await client.Execute.AdvanceRequestAsync(
                BuildTwitterRequest(newTweet, client));

            return Ok(result.Content);
        }

        private static Action<ITwitterRequest> BuildTwitterRequest(
            PostTweetRequestDto newTweet,
            TwitterClient client)
        {

            return (ITwitterRequest request) =>
            {
                var jsonbody = client.Json.Serialize(newTweet);
                var content = new StringContent(jsonbody, Encoding.UTF8, "application/json");

                request.Url = "https://api.twitter.com/2/tweets";
                request.HttpMethod = HttpMethod.Post;
                request.HttpContent = content;
            };
        }
    }
}
