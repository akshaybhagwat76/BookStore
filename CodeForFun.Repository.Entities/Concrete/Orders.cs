using CodeForFun.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeForFun.Repository.Entities.Concrete
{
    [Table("Orders")]
    public class Orders : IEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsOrderSent { get; set; } = false;
        public int BookId { get; set; }
        public virtual Books Books { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
