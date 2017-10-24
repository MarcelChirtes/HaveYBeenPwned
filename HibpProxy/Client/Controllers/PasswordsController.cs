using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HibpProxy.Model;
using Microsoft.AspNetCore.Mvc;

namespace HibpProxy.Controllers
{

    [Route("api/v2/")]
    public class PasteController : Controller
    {
        /// <summary>
        /// Getting all pastes for an account
        /// </summary>
        /// <remarks>
        /// The API takes a single parameter which is the email address to be searched for. Unlike searching for breaches, usernames that are not email addresses cannot be searched for. The email is not case sensitive and will be trimmed of leading or trailing white spaces. The email should always be URL encoded.
        /// </remarks>
        /// <response code="200">Ok — everything worked and there's a string array of pwned sites for the account</response>
        /// <response code="400">Bad request — the account does not comply with an acceptable format (i.e. it's an empty string)</response>
        /// <response code="403">Forbidden — no user agent has been specified in the request</response>
        /// <response code="404">Not found — the account could not be found and has therefore not been pwned</response>
        /// <response code="429">Too many requests — the rate limit has been exceeded</response>
        /// <param name="account">Valid email address</param>
        [HttpGet("pasteaccount/{account}")]
        [ProducesResponseType(typeof(List<PasteResponse>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 429)]
        public List<PasteResponse> GetPasteAccount(string account) => new List<PasteResponse> { new PasteResponse() };



    }
}
