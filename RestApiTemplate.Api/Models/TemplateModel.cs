namespace RestApiTemplate.Api.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOnlyCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
