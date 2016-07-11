using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerException;
using HelperUnit.Extend;
using HelperUnit.Units;
using IBLL;
using IBLL.UserManager;
using Model.Entity;
using Model.Models;

namespace BLL.UserManager
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        public Guid LoginVerify(SysUser info)
        {
            var md5Psd = info.Psd.ToMD5();
            var users = RepositoryFactory.At<SysUser>();
            var user = users.Get(u => u.Uid == info.Uid && u.Psd == md5Psd).FirstOrDefault();

            return user != null ? user.ID : Guid.Empty;
        }

        public Guid LoginVerify(string uid, string psd)
        {
            return LoginVerify(new SysUser()
            {
                Uid = uid,
                Psd = psd
            });
        }

        public SysUser Register(SysUser user)
        {
            RepositoryFactory.At<SysUser>().Insert(user);
            if (RepositoryFactory.At<SysUser>().Submit() != -1)
            {
                return user;
            }
            return null;
        }

        public SysUser Register(string uid, string psd)
        {
            return Register(new SysUser()
            {
                Uid = uid,
                Psd = psd
            });
        }

        public Guid GenerateAutoLoginToken()
        {
            return Guid.NewGuid();
        }

        public SysUser GetById(Guid id)
        {
            return RepositoryFactory.At<SysUser>().GetEntryByPrimaryKey(id);
        }

    }
}
