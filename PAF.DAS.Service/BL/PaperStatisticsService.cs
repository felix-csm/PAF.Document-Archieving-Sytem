using PAF.DAS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAF.DAS.Service.Model;

namespace PAF.DAS.Service.BL
{
    public class PaperStatisticsService : IPaperStatisticsService
    {
        private readonly IPaperStatisticsDAL _paperStatisticsDAL;
        public PaperStatisticsService(IPaperStatisticsDAL paperStatisticsDAL)
        {
            _paperStatisticsDAL = paperStatisticsDAL;
        }

        public PaperStatistic AddDownloaded(PaperStatistic downloadedStatistic)
        {
            try
            {
                return _paperStatisticsDAL.AddDownloaded(downloadedStatistic);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }       

        public PaperStatistic AddViewed(PaperStatistic viewedStatistic)
        {
            try
            {
                return _paperStatisticsDAL.AddViewed(viewedStatistic);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public List<PaperStatistic> GetAll()
        {
            try
            {
                return _paperStatisticsDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
    }
}
