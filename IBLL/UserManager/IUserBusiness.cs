using System;
using Model.Entity;

namespace IBLL.UserManager
{
    public interface IUserBusiness
    {
        Guid LoginVerify(SysUser info);

        Guid LoginVerify(string uid, string psd);

        SysUser Register(SysUser user);

        SysUser Register(string uid, string psd);



        Guid GenerateAutoLoginToken();

        SysUser GetById(Guid id);

    }
}
