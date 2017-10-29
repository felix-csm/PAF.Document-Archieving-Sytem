using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.DAS.Service.Model
{
    [Table("PaperArchieve")]
    public class PaperArchieve
    {
        public Guid Id { get; set; }
        public Guid PaperId { get; set; }
        public string FileName { get; set; }
        public string Location { get; set; }
    }
}
