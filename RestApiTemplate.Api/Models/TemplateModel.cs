using System.ComponentModel.DataAnnotations;

namespace RestApiTemplate.Api.Models
{
    public class TemplateModel
    {
        [Required]
        [Key]
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public DateOnly DateOnlyCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}
