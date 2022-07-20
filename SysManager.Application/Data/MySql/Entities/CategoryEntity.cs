﻿using SysManager.Application.Contracts.Category.Request;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("category")]
    public class CategoryEntity
    {
        public CategoryEntity(CategoryPostRequest request)
        {
            this.Id = Guid.NewGuid();
            this.Name = request.Name;
            this.Active = request.Active;
        }

        public CategoryEntity() 
        { 
        }

        public CategoryEntity(CategoryPutRequest request)
        {
            this.Id = request.Id;
            this.Name = request.Name;
            this.Active = request.Active;
        }

        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
