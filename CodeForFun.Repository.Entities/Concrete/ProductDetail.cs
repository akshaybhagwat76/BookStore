﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeForFun.Core.Entities;
using CodeForFun.Repository.Entities.Concrete.CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.Entities.Concrete
{
    public partial class ProductDetail : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Product.ProductDetail))]
        public virtual Product IdNavigation { get; set; }
    }
}