using DungeonsAndDragonsWeb.Models.Database;
using DungeonsAndDragonsWeb.Models.Resources;
using DungeonsAndDragonsWeb.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace DungeonsAndDragonsWeb.Controllers
{
    [ApiController]
    [Route("MainController")]
    public class MainController : ControllerBase
    {
        public const string sKey = "SESSION";
        static bool first = true;
        public static IndexVM ivm;

        readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            Init();
            _logger = logger;
        }

        public void Init()
        {
            if (first)
            {
                first = false;

                if (!ImageHandler.Exists(typeof(Ability))) ImageHandler.Init(typeof(Ability));
                if (!ImageHandler.Exists(typeof(Character))) ImageHandler.Init(typeof(Character));
                if (!ImageHandler.Exists(typeof(Item))) ImageHandler.Init(typeof(Item));
            }
        }

        [HttpPost("Login")]
        public User? Login([FromBody] User u)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(sKey)))
            {
                if (string.IsNullOrEmpty(u.Email)) return null;
                else if (DatabaseDelegator.CheckPassword(u))
                {
                    string c = GenerateSessionCode();
                    DatabaseDelegator.SetSession(u, c);
                    HttpContext.Session.SetString(sKey, c);
                    return u;
                }
                else return null;
            }
            else return DatabaseDelegator.GetUser(DatabaseDelegator.GetSessionUser(HttpContext.Session.GetString(sKey)));
        }

        [HttpPost("Sha256")]
        public SimpleQuestion Sha256([FromBody] SimpleQuestion text) => new SimpleQuestion(ToSha256(text.text));

        string GenerateSessionCode()
        {
            string chars = "0123456789abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUWXYZ";
            string code = "";
            Random rnd = new Random();
            while (code.Length < 64) code += chars[rnd.Next(0, chars.Length)];
            return code;
        }

        static public string ToSha256(string text)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
