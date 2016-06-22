using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Model.Models
{
    [Table("dbo.SysUser")]
    public class SysUser : DTO
    {
        public string Uid { get; set; }
        public string Psd { get; set; }
        public virtual ICollection<SysUserRole> SysUserRole { get; set; }


    }
}