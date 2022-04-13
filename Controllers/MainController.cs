using DungeonsAndDragonsWeb.Models.Database;
using DungeonsAndDragonsWeb.Models.Resources;
using DungeonsAndDragonsWeb.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
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
    }

    public abstract class Prova
    {

    }
}
