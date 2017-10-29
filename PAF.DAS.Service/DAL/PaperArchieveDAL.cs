using PAF.DAS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAF.DAS.Service.Model;

namespace PAF.DAS.Service.DAL
{
    public class PaperArchieveDAL : IPaperArchieveDAL
    {
        private readonly ApplicationDbContext _context;

        public PaperArchieveDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        public PaperArchieve Add(PaperArchieve paper)
        {
            try
            {
                _context.PaperArchieves.Add(paper);
                _context.SaveChanges();
                return paper;
            }
            catch
            {
                throw;
            }
        }

        public PaperArchieve Get(Guid ID)
        {
            try
            {
                return _context.PaperArchieves.FirstOrDefault(x => x.Id.Equals(ID));
            }
            catch
            {
                throw;
            }
        }

        public List<PaperArchieve> GetAll()
        {
            try
            {
                return _context.PaperArchieves.ToList();
            }
            catch
            {
                throw;
            }
        }

        public PaperArchieve GetByPaperId(Guid ID)
        {
            try
            {
                return _context.PaperArchieves.FirstOrDefault(x => x.PaperId.Equals(ID));
            }
            catch
            {
                throw;
            }
        }

        public PaperArchieve Update(PaperArchieve modifiedPaper)
        {
            PaperArchieve _paper;
            try
            {
                _paper = _context.PaperArchieves.FirstOrDefault(p => p.Id.Equals(modifiedPaper.Id));

                if (_paper == null)
                {
                    throw new KeyNotFoundException("Paper Archieve not found.");
                }
                _paper.FileName = modifiedPaper.FileName;
                _paper.Location = modifiedPaper.Location;
                _context.PaperArchieves.Update(modifiedPaper);
                _context.SaveChanges();
                return _paper;
            }
            catch
            {

                throw;
            }
        }
    }
}
