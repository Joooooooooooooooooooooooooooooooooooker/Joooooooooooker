﻿
//------------------------------------------------------------------------------
// Joooooooooooker
//    此代码由T4模板自动生成
//	   生成时间 2017-04-26 00:14:39 by joker
//    对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
// Joooooooooooker
//------------------------------------------------------------------------------
using Joker.Data;
using Joker.Domain.Entity.EquipmentManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joker.Domain.IRepository.EquipmentManage
{
    /// <summary>
    /// DTPIRepository
    /// </summary>	
    public interface IDTPIRepository : IRepositoryBase<DTPIEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(DTPIEntity entity, string keyValue);
    }
}