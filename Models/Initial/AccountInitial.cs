using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Model.Context;
using Model.Models;

namespace Model.Initial
{
    public class AccountInitial : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var users = new List<SysUser>()
            {
                new SysUser()
                {
                    ID = new Guid(),
                    Uid = "tac",
                    Psd = "123456"
                },
                new SysUser()
                {
                    ID = new Guid(),
                    Uid = "anit",
                    Psd = "123456"
                }
            };


            users.ForEach(u => context.SysUsers.Add(u));
            context.SaveChanges();


        }
    }
}