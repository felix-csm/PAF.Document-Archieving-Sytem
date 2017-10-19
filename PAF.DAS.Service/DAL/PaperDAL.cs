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
            try
            {
                _context.Papers.Add(paper);
                _context.SaveChanges();
                return paper;
            }
            catch
            {

                throw;
            }
        }

        public Paper Get(Guid ID)
        {
            try
            {
                return _context.Papers.FirstOrDefault(x => x.Id.Equals(ID));
            }
            catch
            {
                throw;
            }            
        }

        public List<Paper> GetAll()
        {
            try
            {
                return _context.Papers.ToList();
            }
            catch
            {
                throw;
            }
            
        }

        public Paper Update(Paper modifiedPaper)
        {
            Paper _paper;
            try
            {
                _paper = _context.Papers.FirstOrDefault(p => p.Id.Equals(modifiedPaper.Id));

                if (_paper == null)
                {
                    throw new KeyNotFoundException("Paper not found.");
                }
                _paper.Title = modifiedPaper.Title;
                _paper.DocumentType = modifiedPaper.DocumentType;
                _paper.Author = modifiedPaper.Author;
                _paper.YearSubmitted = modifiedPaper.YearSubmitted;
                _paper.Remarks = modifiedPaper.Remarks;
                _context.Papers.Update(modifiedPaper);
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
