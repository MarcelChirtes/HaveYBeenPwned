using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HibpProxy.Model;
using Microsoft.AspNetCore.Mvc;

namespace HibpProxy.Controllers
{

    [Route("api/v2/")]
    public class BreachesController : Controller
    {
        /// <summary>
        /// Getting all breaches for an account
        /// </summary>
        /// <remarks>
        /// The most common use of the API is to return a list of all breaches a particular account has been involved in. The API takes a single parameter which is the account to be searched for. The account is not case sensitive and will be trimmed of leading or trailing white spaces. The account should always be URL encoded.
        /// </remarks>
        /// <response code="200">Ok — everything worked and there's a string array of pwned sites for the account</response>
        /// <response code="400">Bad request — the account does not comply with an acceptable format (i.e. it's an empty string)</response>
        /// <response code="403">Forbidden — no user agent has been specified in the request</response>
        /// <response code="404">Not found — the account could not be found and has therefore not been pwned</response>
        /// <response code="429">Too many requests — the rate limit has been exceeded</response>
        /// <param name="account">Valid email address</param>
        /// <param name="truncateResponse">If true, returns only the name of the breach.</param>
        /// <param name="domain">If true, filters the result set to only breaches against the domain specified. It is possible that one site (and consequently domain), is compromised on multiple occasions.</param>
        /// <param name="includeUnverified">If true, returns breaches that have been flagged as "unverified". By default, only verified breaches are returned web performing a search.</param>
        [HttpGet("breachedaccount/{account}")]
        [ProducesResponseType(typeof(List<BreacheResponse>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 429)]
        public List<BreacheResponse> GetBreachedAccount(string account, bool? truncateResponse, bool? domain, bool? includeUnverified) => new List<BreacheResponse> { new BreacheResponse() };


        /// <summary>
        /// Getting all breached sites in the system
        /// </summary>
        /// <remarks>
        /// A "breach" is an instance of a system having been compromised by an attacker and the data disclosed. For example, Adobe was a breach, Gawker was a breach etc. It is possible to return the details of each of breach in the system which currently stands at 245 breaches.
        /// </remarks>
        /// <response code="200">Ok — everything worked and there's a string array of pwned sites for the account</response>
        /// <response code="400">Bad request — the account does not comply with an acceptable format (i.e. it's an empty string)</response>
        /// <response code="403">Forbidden — no user agent has been specified in the request</response>
        /// <response code="404">Not found — the account could not be found and has therefore not been pwned</response>
        /// <response code="429">Too many requests — the rate limit has been exceeded</response>
        /// <param name="domain">Filters the result set to only breaches against the domain specified. It is possible that one site (and consequently domain), is compromised on multiple occasions.</param>
        [HttpGet("breaches")]
        [ProducesResponseType(typeof(List<BreacheResponse>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 429)]
        public List<BreacheResponse> GetBreaches(string domain) => new List<BreacheResponse> { new BreacheResponse() };

        /// <summary>
        /// Getting a single breached site
        /// </summary>
        /// <remarks>
        /// Sometimes just a single breach is required and this can be retrieved by the breach "name". This is the stable value which may or may not be the same as the breach "title" (which can change). See the breach model below for more info.
        /// </remarks>
        /// <response code="200">Ok — everything worked and there's a string array of pwned sites for the account</response>
        /// <response code="400">Bad request — the breach does not comply with an acceptable format (i.e. it's an empty string)</response>
        /// <response code="403">Forbidden — no user agent has been specified in the request</response>
        /// <response code="404">Not found — the breach could not be found and has therefore not been pwned</response>
        /// <response code="429">Too many requests — the rate limit has been exceeded</response>
        /// <param name="name">Breach "name"</param>
        [HttpGet("breach/{name}")]
        [ProducesResponseType(typeof(BreacheResponse), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 403)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 429)]
        public BreacheResponse GetSiteBreach(string name) => new BreacheResponse();

        /// <summary>
        /// Getting all data classes in the system
        /// </summary>
        /// <remarks>
        /// A "data class" is an attribute of a record compromised in a breach. For example, many breaches expose data classes such as "Email addresses" and "Passwords". The values returned by this service are ordered alphabetically in a string array and will expand over time as new breaches expose previously unseen classes of data.
        /// </remarks>
        /// <response code="200">Ok — return list of Data Class</response>
        /// <response code="429">Too many requests — the rate limit has been exceeded</response>
        [HttpGet("dataclasses")]
        [ProducesResponseType(typeof(List<string>), 200)]
        [ProducesResponseType(typeof(void), 429)]
        public List<string> GetAllDataClassList() => new List<string> { "Account balances", "Age groups", "Ages", "Astrological signs", "Auth tokens", "Avatars", "Bank account numbers", "Banking PINs", "Beauty ratings", "Biometric data", "Browser user agent details", "Buying preferences", "Car ownership statuses", "Career levels", "Charitable donations", "Chat logs", "Credit card CVV", "Credit cards", "Credit status information", "Customer feedback", "Customer interactions", "Dates of birth", "Deceased date", "Deceased statuses", "Device information", "Device usage tracking data", "Drinking habits", "Drug habits", "Eating habits", "Education levels", "Email addresses", "Email messages", "Employers", "Ethnicities", "Family members' names", "Family plans", "Family structure", "Financial investments", "Financial transactions", "Fitness levels", "Genders", "Geographic locations", "Government issued IDs", "Health insurance information", "Historical passwords", "Home ownership statuses", "Homepage URLs", "Income levels", "Instant messenger identities", "IP addresses", "Job titles", "MAC addresses", "Marital statuses", "Names", "Nationalities", "Net worths", "Nicknames", "Parenting plans", "Partial credit card data", "Passport numbers", "Password hints", "Passwords", "Payment histories", "Payment methods", "Personal descriptions", "Personal health data", "Personal interests", "Phone numbers", "Physical addresses", "Physical attributes", "Political donations", "Political views", "Private messages", "Professional skills", "Purchases", "Purchasing habits", "Races", "Recovery email addresses", "Relationship statuses", "Religions", "Reward program balances", "Salutations", "Security questions and answers", "Sexual fetishes", "Sexual orientations", "Smoking habits", "SMS messages", "Social connections", "Spoken languages", "Support tickets", "Survey results", "Time zones", "Travel habits", "User statuses", "User website URLs", "Usernames", "Utility bills", "Vehicle details", "Website activity", "Work habits", "Years of birth", "Years of professional experience" };

    }
}
