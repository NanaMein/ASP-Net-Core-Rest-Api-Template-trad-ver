namespace RestApiTemplate.Api.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
