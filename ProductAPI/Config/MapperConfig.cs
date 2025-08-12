using AutoMapper;
using ProductAPI.DTO;
using ProductAPI.Models;

namespace ProductAPI.Config;

public class MapperConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductDTO>();
            cfg.CreateMap<ProductDTO, Product>();
        });

        return config;
    }
}