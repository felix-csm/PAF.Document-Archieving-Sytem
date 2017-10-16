using PAF.DAS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAF.DAS.Service.Model;

namespace PAF.DAS.Service.BL
{
    public class PaperArchieveService : IPaperArchieveService
    {
        private readonly IPaperArchieveDAL _paperArchieveDAL;
        public PaperArchieveService(IPaperArchieveDAL paperArchieveDAL)
        {
            _paperArchieveDAL = paperArchieveDAL;
        }
        public PaperArchieve Add(PaperArchieve paper)
        {
            throw new NotImplementedException();
        }

        public PaperArchieve Get(Guid ID)
        {
            try
            {
                PaperArchieve pArchieve = _paperArchieveDAL.Get(ID);
                if (pArchieve != null)
                {
                    return pArchieve;
                }
                else
                {
                    throw new Exception("Paper does not exist");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
