using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAF.DAS.Service.DAL
{
    public class PaperDAL : IPaperDAL
    {
        private readonly DasDBContext _context;

        public PaperDAL(DasDBContext context)
        {
            _context = context;
        }

        public Paper Add(Paper paper)
        {
            throw new NotImplementedException();
        }

        public Paper Get(Guid ID)
        {
            throw new NotImplementedException();
        }

        public List<Paper> GetAll()
        {
            return _context.Papers.ToList();
        }

        public Paper Update(Paper modifiedPaper)
        {
            throw new NotImplementedException();
        }
    }
}
