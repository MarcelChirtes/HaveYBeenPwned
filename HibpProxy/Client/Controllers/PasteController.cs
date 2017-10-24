using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HibpProxy.Model;
using Microsoft.AspNetCore.Mvc;

namespace HibpProxy.Controllers
{

    [Route("api/v2/")]
    public class PasswordsController : Controller
    {
        /// <summary>
        /// Pwned Passwords
        /// </summary>
        /// <remarks>
        /// Pwned Passwords are hundreds of millions of passwords which have previously been exposed in data breaches. The service is detailed in the blog post titled Introducing 306 Million Freely Downloadable Pwned Passwords where two models are described. The first is a downloadable the list of passwords which can be obtained via the Pwned Passwords page then integrated directly into third party systems. The second is to query HIBP directly either via the aforementioned page or the API documented here.
        /// </remarks>
        /// <response code="200">Ok — the password was found in the Pwned Passwords repository</response>
        /// <response code="404">Not found — the password was not found in the Pwned Passwords repository</response>
        /// <param name="password">Password</param>
        /// <param name="originalPasswordIsAHash">Searches for a password which was originally a SHA1 hash, causing it to be hashed again before being compared to the Pwned Password repository.</param>
        [HttpGet("pwnedpassword/{password}")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 404)]
        public StatusCodeResult GetPasteAccount(string password, string originalPasswordIsAHash) => Ok();



    }
}
