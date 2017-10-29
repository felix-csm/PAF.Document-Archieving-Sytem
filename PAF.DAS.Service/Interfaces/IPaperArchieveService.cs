using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Interfaces
{
    public interface IPaperArchieveService
    {
        PaperArchieve Add(PaperArchieve paper);
        PaperArchieve Get(Guid ID);
        PaperArchieve GetByPaperId(Guid ID);
    }
}
