using CodeForFun.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeForFun.Repository.Entities.Concrete
{
    [Table("Books")]
    public class Books:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }

        public decimal? Price { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
