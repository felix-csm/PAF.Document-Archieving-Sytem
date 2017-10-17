using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Model
{
    [Table("PaperArchieve")]
    public class PaperArchieve
    {
        //[Required(ErrorMessage = "ID is required.")]
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "Paper ID is required.")]
        public Guid PaperId { get; set; }
        //[Required(ErrorMessage = "FileName is required.")]
        public string FileName { get; set; }
        //[Required(ErrorMessage = "Author is required.")]
        public string Location { get; set; }        
    }
}
