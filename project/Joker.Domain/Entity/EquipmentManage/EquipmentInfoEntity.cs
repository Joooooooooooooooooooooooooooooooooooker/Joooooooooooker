
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-02-27 11:30:18 by joker
//    对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using System;

namespace Joker.Domain.Entity.EquipmentManage
{
    /// <summary>
    /// EquipmentInfoEntity
    /// </summary>	
    public class EquipmentInfoEntity : IEntity<EquipmentInfoEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }
        public string F_EquipmentNo { get; set; }
        public string F_EquipmentDesc { get; set; }
        public string F_EquipmentLevel { get; set; }
        public string F_EquipmentNode { get; set; }
        public string F_EquipmentParentsNode { get; set; }
        public string F_EquipmentStatus { get; set; }
        public bool? F_DeleteMark { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }

    }
}