using Joker.Application.OrderManage;
using Joker.Code;
using Joker.Code.Excel;
using Joker.Domain.Entity.OrderManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Joker.Web.Areas.OrderManage.Controllers
{
    public class OrderController : ControllerBase
    {
        private OrderApp orderApp = new OrderApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = orderApp.GetList(pagination, keyword),
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
            var data = orderApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(OrderEntity orderEntity, string keyValue)
        {
            orderApp.SubmitForm(orderEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            orderApp.DeleteForm(keyValue);
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
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("OrderAmount");
            log.Info("获取订单数据--Start");
            List<OrderEntity> dataList = orderApp.GetList();
            log.Info("获取订单数据--End");
            foreach (var item in dataList)
            {
                DataRow dr = dt.NewRow();
                dr["ID"]= item.F_Id;
                dr["OrderNo"] = item.F_OrderNo;
                dr["OrderAmount"] = item.F_OrderAmount;
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
            npoiexel.ToExcel(dt, "订单数据", "Sheet1", destDir + fileName);
            return Content("/ExcelTemp/" + fileDir + "/" + fileName);
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }
    }
}
