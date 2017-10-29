using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.DAS.Service.Model
{
    public enum DocumentType
    {
        None = 0,
        CommandantsPaper =1,
        PositionPaper =2,
        CaseStudy =3
    }

    [Table("Paper")]
    public class Paper
    {        
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Document Type is required.")]
        public DocumentType DocumentType { get; set; }
        [Required(ErrorMessage = "Year Submitted is required.")]
        public string YearSubmitted { get; set; }
        public string Remarks { get; set; }
    }
}
