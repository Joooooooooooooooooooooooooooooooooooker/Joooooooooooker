
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-04-26 00:18:31 by joker
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
    /// TPDIApp
    /// </summary>	
    public class TPDIApp
    {
        private ITPDIRepository service = new TPDIRepository();

        public List<TPDIEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public TPDIEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(TPDIEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(TPDIEntity entity, string keyValue)
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

        public List<TPDIEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<TPDIEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Id.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }

        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
    }
}