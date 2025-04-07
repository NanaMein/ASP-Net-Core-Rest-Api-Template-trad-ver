namespace RestApiTemplate.Api.DTOs
{
    public class TemplateModelDtoPostResponse
    {
        public string Name { get; set; }
        public DateOnly DateOnlyCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
