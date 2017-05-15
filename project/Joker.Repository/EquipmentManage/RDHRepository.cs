
//------------------------------------------------------------------------------
// Joooooooooooker
//     此代码由T4模板自动生成
//	   生成时间 2017-04-21 00:27:59 by joker
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
    /// RDHRepository
    /// </summary>	
    public class RDHRepository : RepositoryBase<RDHEntity>, IRDHRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<RDHEntity>(t => t.F_Id == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(RDHEntity entity, string keyValue)
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