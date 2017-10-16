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
        private readonly IPaperDAL _paperDAL;
        public PaperService(IPaperDAL paperDAL)
        {
            _paperDAL = paperDAL;
        }
        public Paper Add(Paper paper)
        {
            var validator = new PaperValidator<Paper>();
            try
            {
                if (validator.ValidateInput(paper))
                {
                    if (Get(paper.ID) == null)
                    {
                        return _paperDAL.Add(paper);
                    }
                    else
                    {
                        throw new Exception("Paper already exist");
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
        public Paper Edit(Paper modifiedPaper)
        {
            throw new NotImplementedException();
        }
        public Paper Get(Guid ID)
        {
            try
            {
                Paper paper = _paperDAL.Get(ID);
                if (paper != null)
                {
                    return paper;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
        public List<Paper> GetAll()
        {
            try
            {
                return _paperDAL.GetAll();                
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
    }
}
