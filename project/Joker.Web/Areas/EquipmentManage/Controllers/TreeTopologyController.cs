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
using System.Text;
using System.Web.Mvc;


namespace Joker.Web.Areas.EquipmentManage.Controllers
{
    public class TreeTopologyController : ControllerBase
    {
        private DTPIApp dtpiApp = new DTPIApp();

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetDeviceToPoInfo()
        {
            string strResult = string.Empty;
            var data1 = dtpiApp.GetList();
            var topoList = new List<TopoViewModel>();
            foreach (DTPIEntity item in data1)
            {
                TopoViewModel topoModel = new TopoViewModel();
                topoModel.id = item.F_Id;
                topoModel.parentId = item.F_Data1;
                topoModel.nodeDesc = item.F_Data2;
                topoModel.nodeSeq = item.F_Data3;
                topoModel.areaId = item.F_Data4;
                topoModel.areaDesc = item.F_Data5;
                topoModel.deviceId = item.F_Data6;
                topoModel.deviceDesc = item.F_Data7;
                topoModel.isOnLine = item.F_Data8;
                topoList.Add(topoModel);
            }
            strResult = topoList.TopoViewToJson();
            return Content(strResult);
        }

    }
}
