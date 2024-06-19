using Domain.Entities.Base;


namespace Domain.Entities
{
    public class Products : BaseAuditableEntity, ICommands
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Summary { get; set; }
        public ProductType Producttype { get; set; }
        public ProductBrand productBrand { get; set; }
    }
}
