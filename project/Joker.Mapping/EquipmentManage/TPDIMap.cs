
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-04-26 00:18:35 by joker
//    对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using Joker.Domain.Entity.EquipmentManage;
using System.Data.Entity.ModelConfiguration;

namespace Joker.Mapping.EquipmentManage
{
    /// <summary>
    /// TPDIMap
    /// </summary>	
    public class TPDIMap : EntityTypeConfiguration<TPDIEntity>
    {
        public TPDIMap()
        {
            this.ToTable("C_TPDI");
            this.HasKey(t => t.F_Id);
        }
    }
}