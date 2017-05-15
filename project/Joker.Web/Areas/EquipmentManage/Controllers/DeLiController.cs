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
    public class DeLiController : ControllerBase
    {
        private DeLiApp deliApp = new DeLiApp();
        private TPSRApp tpsrApp = new TPSRApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = deliApp.GetList(pagination, keyword),
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
            var data = deliApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DeLiEntity entity, string keyValue)
        {
            deliApp.SubmitForm(entity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            deliApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetNodeTreeSelectJson()
        {
            var data = tpsrApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (TPSREntity item in data)
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
            dt.Columns.Add("装置编号");
            dt.Columns.Add("装置COM");
            dt.Columns.Add("装置地址");
            dt.Columns.Add("装置类型");
            dt.Columns.Add("装置描述");
            dt.Columns.Add("节点");
            dt.Columns.Add("预留1");
            dt.Columns.Add("预留2");
            dt.Columns.Add("预留3");
            dt.Columns.Add("预留4");
            dt.Columns.Add("预留5");
            dt.Columns.Add("是否在线");
            dt.Columns.Add("创建时间");
            dt.Columns.Add("创建用户");
            dt.Columns.Add("最后更新时间");
            dt.Columns.Add("最后更新用户");
            dt.Columns.Add("删除时间");
            dt.Columns.Add("删除用户");
            dt.Columns.Add("删除标识");
            log.Info("获取区域信息--Start");
            List<DeLiEntity> dataList = deliApp.GetList();
            log.Info("获取区域信息--End");
            foreach (var item in dataList)
            {
                DataRow dr = dt.NewRow();
                dr["装置编号"] = item.F_Id;
                dr["装置COM"] = item.F_Data1;
                dr["装置地址"] = item.F_Data2;
                dr["装置类型"] = item.F_Data3;
                dr["装置描述"] = item.F_Data4;
                dr["节点"] = item.F_Data5;
                dr["预留1"] = item.F_Data6;
                dr["预留2"] = item.F_Data7;
                dr["预留3"] = item.F_Data8;
                dr["预留4"] = item.F_Data9;
                dr["预留5"] = item.F_Data10;
                dr["是否在线"] = item.F_Data11;
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
            npoiexel.ToExcel(dt, "装置信息", "Sheet1", destDir + fileName);
            return Content("/ExcelTemp/" + fileDir + "/" + fileName);
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

    }
}
