using SysManager.Application.Contracts.Products.Request;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysManager.Application.Data.MySql.Entities
{
    [Table("product")]
    public class ProductsEntity
    {
        public ProductsEntity(ProductsPostRequest request)
        {
            this.Id            = Guid.NewGuid();
            this.ProductCode   = request.ProductCode;
            this.Name          = request.Name;
            this.ProductTypeId = request.ProductTypeId;
            this.CategoryId    = request.CategoryId;
            this.UnityId       = request.UnityId;
            this.CostPrice     = request.CostPrice;
            this.Percentage    = request.Percentage;
            this.Price         = request.Price;
            this.Active        = request.Active;
        }
        public ProductsEntity() 
        { 
        }
        public ProductsEntity(ProductsPutRequest request)
        {
            this.Id            = request.Id;
            this.ProductCode   = request.ProductCode;
            this.Name          = request.Name;
            this.ProductTypeId = request.ProductTypeId;
            this.CategoryId    = request.CategoryId;
            this.UnityId       = request.UnityId;
            this.CostPrice     = request.CostPrice;
            this.Percentage    = request.Percentage;
            this.Price         = request.Price;
            this.Active        = request.Active;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("productcode")]
        public string ProductCode { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("producttypeid")]
        public string ProductTypeId { get; set; }
        [Column("categoryid")]
        public string CategoryId { get; set; }
        [Column("unityid")]
        public string UnityId { get; set; }
        [Column("costprice")]
        public decimal CostPrice { get; set; }
        [Column("percentage")]
        public decimal Percentage { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("active")]
        public bool Active { get; set; }
    }
}
