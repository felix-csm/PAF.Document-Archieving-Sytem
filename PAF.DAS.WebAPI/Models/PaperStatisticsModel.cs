using System;

namespace PAF.DAS.Service.Model
{
    public class PaperStatistics
    {
        public Guid Id { get; set; }
        public Guid PaperId { get; set; }
        public int Viewed { get; set; }
        public int Downloaded { get; set; }
    }
}
