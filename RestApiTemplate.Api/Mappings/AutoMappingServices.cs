using AutoMapper;
using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Mappings
{
    public class AutoMappingServices:Profile
    {
        public AutoMappingServices()
        {
            CreateMap<TemplateModel, TemplateModel>();
            CreateMap<TemplateModelDtoPostRequest, TemplateModel>().ReverseMap();
            CreateMap<TemplateModelDtoPostResponse, TemplateModel>().ReverseMap();
        }
    }
}
