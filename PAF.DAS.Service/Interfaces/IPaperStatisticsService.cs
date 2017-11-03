using PAF.DAS.Service.Model;
using System.Collections.Generic;

namespace PAF.DAS.Service.Interfaces
{
    public interface IPaperStatisticsService
    {
        PaperStatistic AddViewed(PaperStatistic viewedStat);
        PaperStatistic AddDownloaded(PaperStatistic downloadedStat);
        List<PaperStatistic> GetAll();
    }
}