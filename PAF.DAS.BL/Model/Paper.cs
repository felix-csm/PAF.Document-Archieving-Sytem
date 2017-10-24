using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.DAS.Service.Model
{
    public enum DocumentType
    {
        CommandantsPaper,
        PositionPaper,
        CaseStudy
    }

    [Table("Paper")]
    public class Paper
    {
        [Required(ErrorMessage = "ID is required.")]
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
