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
    public class DTRDController : ControllerBase
    {
        private DTRDApp dtrdApp = new DTRDApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = dtrdApp.GetList(pagination, keyword),
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
            var data = dtrdApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DTRDEntity entity, string keyValue)
        {
            dtrdApp.SubmitForm(entity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            dtrdApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult ExportExcel(string keyword)
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            var log = LogFactory.GetLogger(type);
            DataTable dt = new DataTable();
            dt.Columns.Add("参数编号");
            dt.Columns.Add("装置类型编号");
            dt.Columns.Add("装置描述");
            dt.Columns.Add("分段定义");
            dt.Columns.Add("寄存器地址");
            dt.Columns.Add("寄存器占用数量");
            dt.Columns.Add("寄存器类型");
            dt.Columns.Add("寄存器描述");
            dt.Columns.Add("数据格式");
            dt.Columns.Add("单位/范围");
            dt.Columns.Add("数据格式");
            dt.Columns.Add("备注");
            dt.Columns.Add("创建时间");
            dt.Columns.Add("创建用户");
            dt.Columns.Add("最后更新时间");
            dt.Columns.Add("最后更新用户");
            dt.Columns.Add("删除时间");
            dt.Columns.Add("删除用户");
            dt.Columns.Add("删除标识");
            log.Info("获取区域信息--Start");
            List<DTRDEntity> dataList = dtrdApp.GetList();
            log.Info("获取区域信息--End");
            foreach (var item in dataList)
            {
                DataRow dr = dt.NewRow();
                dr["参数编号"] = item.F_Id;
                dr["装置类型编号"] = item.F_Data1;
                dr["装置描述"] = item.F_Data2;
                dr["分段定义"] = item.F_Data3;
                dr["寄存器地址"] = item.F_Data4;
                dr["寄存器占用数量"] = item.F_Data5;
                dr["寄存器类型"] = item.F_Data6;
                dr["寄存器描述"] = item.F_Data7;
                dr["数据格式"] = item.F_Data8;
                dr["单位/范围"] = item.F_Data9;
                dr["备注"] = item.F_Data10;
                dr["创建时间"] = item.F_CreatorTime;
                dr["创建用户"] = item.F_CreatorUserId;
                dr["最后更新时间"] = item.F_LastModifyTime;
                dr["最后更新用户"] = item.F_LastModifyUserId;
                dr["删除时间"] = item.F_DeleteTime;
                dr["删除用户"] = item.F_DeleteUserId;
                dr["删除标识"] = item.F_DeleteMark;
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
            npoiexel.ToExcel(dt, "装置参数信息", "Sheet1", destDir + fileName);
            return Content("/ExcelTemp/" + fileDir + "/" + fileName);
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

    }
}
