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
    public class EquipmentInfoController : ControllerBase
    {
        private EquipmentInfoApp equipmentApp = new EquipmentInfoApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = equipmentApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = equipmentApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(EquipmentInfoEntity orderEntity, string keyValue)
        {
            equipmentApp.SubmitForm(orderEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            equipmentApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult ExportExcel(string keyword)
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            var log = LogFactory.GetLogger(type);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("设备编码");
            dt.Columns.Add("设备描述");
            dt.Columns.Add("设备级层");
            dt.Columns.Add("设备状态");
            dt.Columns.Add("设备节点");
            dt.Columns.Add("设备父节点");
            log.Info("获取设备信息--Start");
            List<EquipmentInfoEntity> dataList = equipmentApp.GetList();
            log.Info("获取设备信息--End");
            foreach (var item in dataList)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.F_Id;
                dr["设备编码"] = item.F_EquipmentNo;
                dr["设备描述"] = item.F_EquipmentDesc;
                dr["设备级层"] = item.F_EquipmentLevel;
                dr["设备状态"] = item.F_EquipmentStatus;
                dr["设备节点"] = item.F_EquipmentNode;
                dr["设备父节点"] = item.F_EquipmentParentsNode;
                dt.Rows.Add(dr);
            }
            NPOIExcel npoiexel = new NPOIExcel();
            string fileDir = DateTime.Now.ToString("yyyyMMdd");
            string fileName = "G" + Guid.NewGuid().ToString("N") + ".xls";
            string destDir = Server.MapPath(@"/ExcelTemp") + "\\" + fileDir + "\\";
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            npoiexel.ToExcel(dt, "设备信息", "Sheet1", destDir + fileName);
            return Content("/ExcelTemp/" + fileDir + "/" + fileName);
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }
    }
}
