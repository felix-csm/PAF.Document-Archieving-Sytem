using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Interfaces
{
    public interface IPaperArchieveDAL
    {
        PaperArchieve Add(PaperArchieve paper);
        List<PaperArchieve> GetAll();
        PaperArchieve Get(Guid ID);
        PaperArchieve Update(PaperArchieve modifiedPaper);
    }
}
