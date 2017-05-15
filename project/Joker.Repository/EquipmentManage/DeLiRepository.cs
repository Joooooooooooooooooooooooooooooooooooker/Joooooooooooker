﻿
//------------------------------------------------------------------------------
// Joooooooooooker
//     此代码由T4模板自动生成
//	   生成时间 2017-04-21 00:11:34 by joker
//     对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using Joker.Data;
using Joker.Domain.Entity.EquipmentManage;
using Joker.Domain.IRepository.EquipmentManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joker.Repository.EquipmentManage
{
    /// <summary>
    /// DeLiRepository
    /// </summary>	
    public class DeLiRepository : RepositoryBase<DeLiEntity>, IDeLiRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<DeLiEntity>(t => t.F_Id == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(DeLiEntity entity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(entity);
                }
                else
                {
                    db.Insert(entity);
                }
                db.Commit();
            }
        }
    }
}