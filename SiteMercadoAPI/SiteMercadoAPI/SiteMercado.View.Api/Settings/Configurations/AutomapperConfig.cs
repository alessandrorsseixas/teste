using AutoMapper;
using SiteMercado.Domain.Model;
using SiteMercado.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.View.Api.Settings.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
