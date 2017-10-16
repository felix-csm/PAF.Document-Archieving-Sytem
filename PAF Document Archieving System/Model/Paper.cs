using PAF.DAS.Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Model
{
    public enum DocumentType
    {
        CommandantsPaper,
        PositionPaper,
        CaseStudy
    }
    public class Paper
    {
        [Required(ErrorMessage = "ID is required.")]
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Document Type is required.")]
        public DocumentType DocType { get; set; }
        [Required(ErrorMessage = "Year Submitted is required.")]
        public string YearSubmitted { get; set; }       
        public string Remarks { get; set; }

        public Paper()
        { }
        public Paper(string title, string author, DocumentType docType, string yearSubmitted, string remarks)
        {
            Title = title;
            Author = author;
            DocType = docType;
            YearSubmitted = yearSubmitted;
            Remarks = remarks;
        }
    }
}
