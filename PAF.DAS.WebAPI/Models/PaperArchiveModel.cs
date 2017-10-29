using System;

namespace PAF.DAS.Service.Model
{
    public class PaperArchiveModel
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DocumentType DocumentType { get; set; }
        public string YearSubmitted { get; set; }
        public string Remarks { get; set; }
        public string FileName { get; set; }
    }
}
