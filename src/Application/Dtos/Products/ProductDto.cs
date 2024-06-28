using Application.Common.Mapping;
using Application.Dtos.Common;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products
{
    public class ProductDto : CommandDto , IMapForm<Product>
    {
        public string? Title { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public bool IsDelete { get; set; }
        public string producttype { get; set; } //title
        public string productbrand { get; set; } //title

        public void Mapping (Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(x => x.productbrand, 
                c => c.MapFrom( v => v.productbrand.Title ) );
            profile.CreateMap<Product, ProductDto>()
                .ForMember(x => x.producttype, 
                c => c.MapFrom( v => v.producttype.Title ) );
        }
    }
}
