using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TodoListAPI.Controllers
{
    [Authorize]
    [AuthorizeForScopes(ScopeKeySection = "MyAPI2:Scopes")]
    [ApiController]
    [Route("api/[controller]")]
    public class DownStreamController : ControllerBase
    {
        private IDownstreamWebApi _downstreamWebApi;

        public DownStreamController(IDownstreamWebApi downstreamWebApi)
        {
            _downstreamWebApi = downstreamWebApi;
        }

        [HttpGet]
        public async Task<ActionResult> Details()
        {
            HttpResponseMessage value = null;
            //try
            //{
                 value = await _downstreamWebApi.CallWebApiForAppAsync(
                    "MyAPI2",
                    options =>
                    {
                        //options.BaseUrl = "https://localhost:44352/";
                        options.HttpMethod = HttpMethod.Get;
                        options.RelativePath = $"api/todolist2/getAllTasks2";
                    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //}
            return Ok(value);

        }


    }
}
