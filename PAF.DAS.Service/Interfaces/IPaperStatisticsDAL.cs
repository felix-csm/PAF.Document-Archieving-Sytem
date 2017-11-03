using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;

namespace PAF.DAS.Service.Interfaces
{
    public interface IPaperStatisticsDAL
    {
        void AddViewed(Guid paperId);
        void AddDownloaded(Guid paperId);
        List<PaperStatistic> GetAll();
    }
}