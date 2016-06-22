using System;
using Model.Models;

namespace IBLL.UserManager
{
    public interface IUserBusiness
    {
        Guid LoginVerify(SysUser info);

        Guid LoginVerify(string uid, string psd);

        Guid GenerateAutoLoginToken();

        SysUser GetById(Guid id);
    }
}
