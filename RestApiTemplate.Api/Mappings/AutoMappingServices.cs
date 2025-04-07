using AutoMapper;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Mappings
{
    public class AutoMappingServices:Profile
    {
        public AutoMappingServices()
        {
            CreateMap<TemplateModel, TemplateModel>();
        }
    }
}
