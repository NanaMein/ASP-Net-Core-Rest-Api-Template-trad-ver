using RestApiTemplate.Api.Data;

namespace RestApiTemplate.Api.Repositories
{
    public class TemplateRepository:ITemplateRepository
    {
        private readonly TemplateDbContext context;

        public TemplateRepository(TemplateDbContext context)
        {
            this.context = context;
        }
    }
}
