
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-04-26 00:14:43 by joker
//    对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using Joker.Domain.Entity.EquipmentManage;
using System.Data.Entity.ModelConfiguration;

namespace Joker.Mapping.EquipmentManage
{
    /// <summary>
    /// DTPIMap
    /// </summary>	
    public class DTPIMap : EntityTypeConfiguration<DTPIEntity>
    {
        public DTPIMap()
        {
            this.ToTable("C_DTPI");
            this.HasKey(t => t.F_Id);
        }
    }
}