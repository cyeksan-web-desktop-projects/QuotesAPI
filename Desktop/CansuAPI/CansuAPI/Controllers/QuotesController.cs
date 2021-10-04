using CansuAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserDataAccess;

namespace CansuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        public List<Quote> quotes = new List<Quote>();

        [HttpGet]
        public ActionResult<QuotesResult> GetAllList()
        {
            using (MVVMDemoEntities entities = new MVVMDemoEntities())
            {
                quotes = entities.Quotes.ToList();
            };

            var quotesResult = new QuotesResult();
            if (quotes!= null)
            {
                quotesResult.IsSuccess = true;
                quotesResult.Quotes = quotes;
                return quotesResult;
            }
            else {
                quotesResult.IsSuccess = false;
                quotesResult.Quotes = null;
                Response.StatusCode = (int)HttpStatusCode.NoContent;
                return quotesResult;
            }
            

        }
    }
}
