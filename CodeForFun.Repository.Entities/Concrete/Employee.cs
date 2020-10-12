using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeForFun.Repository.Entities.Concrete
{
    [Table("Employee")]
    public class coEmployee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName{ get; set; }
        
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
