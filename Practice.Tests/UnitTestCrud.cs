using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Models;
using Practice.Unit;
using Repository.GenericRepository;

namespace Practice.Tests
{
    [TestClass]
    public class UnitTestCrud
    {
        [TestMethod]
        public void Delete()
        {
            IGenericRepository<SysUser> user = new GenericRepository<SysUser>();
            //user.Delete(4);
            if (user.Submit() == -1)
                Assert.Fail();
        }


        [TestMethod]
        public void Insert()
        {
            IGenericRepository<SysUser> user = new GenericRepository<SysUser>();
            user.Insert(new SysUser()
            {
                Uid = "test",
                Psd = "111111"
            });

            if (user.Submit() == -1)
                Assert.Fail();
        }

        [TestMethod]
        public void Get()
        {
            IGenericRepository<SysUser> sysUser = new GenericRepository<SysUser>();
            //var user = sysUser.Get(u => u.ID == 1);
            //var user1 = sysUser.GetById(2);
        }
    }
}
