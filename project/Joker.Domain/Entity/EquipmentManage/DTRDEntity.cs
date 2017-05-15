
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-04-21 00:25:39 by joker
//    对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joker.Domain.Entity.EquipmentManage
{
    /// <summary>
    /// DTRDEntity
    /// </summary>	
    public class DTRDEntity : IEntity<DTRDEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int F_No { get; set; }
        public string F_Id { get; set; }
        public string F_Data1 { get; set; }
        public string F_Data2 { get; set; }
        public string F_Data3 { get; set; }
        public string F_Data4 { get; set; }
        public string F_Data5 { get; set; }
        public string F_Data6 { get; set; }
        public string F_Data7 { get; set; }
        public string F_Data8 { get; set; }
        public string F_Data9 { get; set; }
        public string F_Data10 { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
        public bool? F_DeleteMark { get; set; }

    }
}