using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Interfaces
{
    public interface IPaperDAL
    {
        Paper Add(Paper paper);
        List<Paper> GetAll();
        Paper Get(Guid ID);
        Paper Update(Paper modifiedPaper);
    }
}
