using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Model.Models
{
    [Table("tac.Role")]
    public class SysRole : DTO
    {
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }

        public virtual ICollection<SysUserRole> SysUserRole { get; set; }
    }
}