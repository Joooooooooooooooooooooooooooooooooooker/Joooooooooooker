using System.Web.Mvc;

namespace Joker.Web.Areas.EquipmentManage
{
    public class EquipmentManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EquipmentManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "Joker.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
