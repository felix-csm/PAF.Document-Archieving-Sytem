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

        public void AddDownloaded(Guid paperId)
        {
            try
            {
                _paperStatisticsDAL.AddDownloaded(paperId);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }       

        public void AddViewed(Guid paperId)
        {
            try
            {
                _paperStatisticsDAL.AddViewed(paperId);
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
