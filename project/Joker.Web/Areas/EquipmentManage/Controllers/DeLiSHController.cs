using Joker.Application.EquipmentManage;
using Joker.Code;
using Joker.Code.Excel;
using Joker.Domain.Entity.EquipmentManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Joker.Web.Areas.EquipmentManage.Controllers
{
    public class DeLiSHController : ControllerBase
    {
        //
        // GET: /EquipmentManage/DeLiSH/

        public ActionResult Index()
        {
            return View();
        }

    }
}
