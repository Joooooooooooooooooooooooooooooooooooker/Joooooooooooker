/*******************************************************************************
 * Copyright © 2017 Joooooooooooker 版权所有
 * Author: Joooooooooooker
 * Description: Joooooooooooker
 * Website：Joooooooooooker
*********************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace Joker.Code
{
    public static class TopoView
    {
        public static string TopoViewToJson(this List<TopoViewModel> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(TopoViewJson(data, "0"));
            sb.Append("]");
            return sb.ToString();
        }
        private static string TopoViewJson(List<TopoViewModel> data, string parentId)
        {
            StringBuilder sb = new StringBuilder();
            var ChildNodeList = data.FindAll(t => t.parentId == parentId);            
            foreach (TopoViewModel entity in ChildNodeList)
            {                
                string strJson = entity.ToJson();
                sb.Append(strJson);
                sb.Append(TopoViewJson(data, entity.id));
            }
            return sb.ToString().Replace("}{", "},{");
        }
    }
}
