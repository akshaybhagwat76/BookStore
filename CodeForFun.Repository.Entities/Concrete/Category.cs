﻿
// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeForFun.Core.Entities;
using CodeForFun.Repository.Entities.Concrete.CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.Entities.Concrete
{
    [Table("Categories")]
    public partial class Category : IEntity
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [StringLength(36)]
        public string Name { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(Category.InverseParent))]
        public virtual Category Parent { get; set; }
        [InverseProperty(nameof(Category.Parent))]
        public virtual ICollection<Category> InverseParent { get; set; }
        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}