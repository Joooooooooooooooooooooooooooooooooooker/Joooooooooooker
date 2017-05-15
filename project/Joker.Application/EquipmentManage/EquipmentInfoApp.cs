
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-02-27 11:30:27 by joker
//    对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Joker.Domain.Entity.EquipmentManage;
using Joker.Domain.IRepository.EquipmentManage;
using Joker.Repository.EquipmentManage;
using Joker.Code;
using System.Data;

namespace Joker.Application.EquipmentManage
{
    /// <summary>
    /// EquipmentInfoApp
    /// </summary>	
    public class EquipmentInfoApp
    {
        private IEquipmentInfoRepository service = new EquipmentInfoRepository();

        public List<EquipmentInfoEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public EquipmentInfoEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(EquipmentInfoEntity entity)
        {
            service.Delete(entity);
        }

        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }

        public void SubmitForm(EquipmentInfoEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {
                entity.Create();
                service.Insert(entity);
            }
        }

        public List<EquipmentInfoEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<EquipmentInfoEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_EquipmentNo.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }

        public DataTable GetDistinctEquipmentLevel() 
        {
            DataTable dt = this.GetList().ToJson().ToTable();
            DataView dv = dt.DefaultView;
            dv.Sort = "F_EquipmentLevel ASC";
            dt = dv.ToTable(true, new string[] { "F_EquipmentLevel"});
            return dt;
        }

        public void UpdateForm(EquipmentInfoEntity entity)
        {
            service.Update(entity);
        }
    }
}