using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Model
{
    public class PaperArchieve
    {
        [Required(ErrorMessage = "ID is required.")]
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Paper ID is required.")]
        public Guid PaperID { get; set; }
        [Required(ErrorMessage = "FileName is required.")]
        public string FileName { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public string Location { get; set; }
        public PaperArchieve()
        { }
        public PaperArchieve(Guid id, Guid paperID, string fileName, string location)
        {
            ID = id;
            PaperID = paperID;
            FileName = fileName;
            Location = location;
        }
    }
}
