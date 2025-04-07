using RestApiTemplate.Api.Repositories;

namespace RestApiTemplate.Api.Services
{
    public class TemplateService:ITemplateService
    {
        private readonly ITemplateRepository repository;

        public TemplateService(ITemplateRepository repository)
        {
            this.repository = repository;
        }
    }
}
