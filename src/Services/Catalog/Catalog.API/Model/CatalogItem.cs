using Catalog.API.Infrastructure.Exceptions;
using System;

namespace Microsoft.eShopOnContainers.Services.Catalog.API.Model
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Units { get; set; }

        public string PictureUri { get; set; }

        public int CatalogTypeId { get; set; }

        public CatalogType CatalogType { get; set; }

        public int CatalogBrandId { get; set; }

        public CatalogBrand CatalogBrand { get; set; }

        public CatalogItem() { }  
        
        public void AddStock(int quantity)
        {
            Units += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (Units == 0)
            {
                throw new CatalogDomainException($"Empty stock, product item {Name} is sold out");
            }

            Units -= quantity;
        }
    }
}
