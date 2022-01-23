using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using YoutubeToMP3_Login_Backend.Data;
using Microsoft.AspNetCore.Cors;
using YoutubeToMP3_Login_Backend.Models;

namespace YoutubeToMP3_Login_Backend.Controllers
{
    [ApiController]
    [EnableCors]
    public class AccountController : ControllerBase
    {
        private IAccountData _account;

        public AccountController(IAccountData account)
        {
            _account = account;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAccounts()
        {
            return Ok(_account.GetAccounts());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAccount(int id)
        {
            var account = _account.GetAccount(id);

            if (account != null)
            {
                return Ok(account);
            }

            return NotFound($"Account with Id: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAccount(Account account)
        {

            _account.AddAccount(account);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + account.AccountId, account);
        }
    }
}
