using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.DAS.Service.Model
{
    [Table("PaperStatistic")]
    public class PaperStatistic
    {
        public Guid Id { get; set; }
        public Guid PaperId { get; set; }
        public int Viewed { get; set; }
        public int Downloaded { get; set; }
    }
}
