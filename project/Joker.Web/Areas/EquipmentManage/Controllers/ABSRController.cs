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
    public class ABSRController : ControllerBase
    {
        private ABSRApp absrApp = new ABSRApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = absrApp.GetList(pagination, keyword),
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
            var data = absrApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ABSREntity entity, string keyValue)
        {
            absrApp.SubmitForm(entity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            absrApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetParentIDTreeSelectJson()
        {
            var data = absrApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (ABSREntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_Data2;
                treeModel.parentId = item.F_Data1;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult ExportExcel(string keyword)
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            var log = LogFactory.GetLogger(type);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("区域编码");
            dt.Columns.Add("区域描述");
            dt.Columns.Add("父级编码");
            dt.Columns.Add("创建时间");
            dt.Columns.Add("创建用户");
            dt.Columns.Add("最后更新时间");
            dt.Columns.Add("最后更新用户");
            dt.Columns.Add("删除时间");
            dt.Columns.Add("删除用户");
            dt.Columns.Add("删除标识");
            log.Info("获取区域信息--Start");
            List<ABSREntity> dataList = absrApp.GetList();
            log.Info("获取区域信息--End");
            foreach (var item in dataList)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.F_Id;
                dr["区域编码"] = item.F_Data1;
                dr["区域描述"] = item.F_Data2;
                dr["父级编码"] = item.F_Data3;
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
            npoiexel.ToExcel(dt, "区域信息", "Sheet1", destDir + fileName);
            return Content("/ExcelTemp/" + fileDir + "/" + fileName);
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

    }
}
