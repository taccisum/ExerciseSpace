using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Model.Entity;

namespace Model.Models
{
    [Table("tac.UserRole")]
    public class SysUserRole : DTO
    {
        public int SysUserID { get; set; }
        public int SysRoleId { get; set; }

        public virtual SysUser SysUser { get; set; }
        public virtual SysRole SysRole { get; set; }

    }
}