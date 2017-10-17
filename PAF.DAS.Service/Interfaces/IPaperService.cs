using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Interfaces
{
    public interface IPaperService
    {
        Paper Add(Paper paper);
        List<Paper> GetAll();
        Paper Get(Guid ID);
        Paper Edit(Paper modifiedPaper);
    }
}
