﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Global.Configs;
using Model.Models;

namespace Model.Context
{
    public class AccountContext : DbContext
    {

        public AccountContext()
            : base(GlobalConfig.DataBase)
        {

        }

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysUserRole> SysUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'  
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded.   
            //Make sure the provider assembly is available to the running application.   
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.  
            var type = typeof (System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }
    }
}