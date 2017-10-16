using PAF.DAS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAF.DAS.Service.Model;

namespace PAF.DAS.Service.BL
{
    public class PaperService : IPaperService
    {
        private List<Paper> _papers = new List<Paper>();
        public List<Paper> Papers
        {
            get { return _papers; }
        }
        public Paper Add(Paper paper)
        {
            throw new NotImplementedException();
        }
        public Paper Edit(Paper modifiedPaper)
        {
            throw new NotImplementedException();
        }
        public Paper Get(Guid ID)
        {
            throw new NotImplementedException();
        }
        public List<Paper> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
