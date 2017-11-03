using PAF.DAS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAF.DAS.Service.Model;

namespace PAF.DAS.Service.DAL
{
    public class PaperStatisticsDAL : IPaperStatisticsDAL
    {
        private readonly ApplicationDbContext _context;

        public PaperStatisticsDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaperStatistic AddDownloaded(PaperStatistic downloadedStatistic)
        {
            PaperStatistic _paperStat;
            try
            {
                _paperStat = _context.PaperStatistics.FirstOrDefault(p => p.PaperId.Equals(downloadedStatistic.PaperId));
                if (_paperStat == null)
                {
                    _paperStat = Add(downloadedStatistic);
                }
                else
                {
                    _paperStat.Viewed = downloadedStatistic.Viewed;
                    _context.PaperStatistics.Update(_paperStat);
                }
                _context.SaveChanges();
                return _paperStat;
            }
            catch
            {
                throw;
            }
        }

        public PaperStatistic AddViewed(PaperStatistic viewedStatistic)
        {
            PaperStatistic _paperStat;
            try
            {
                _paperStat = _context.PaperStatistics.FirstOrDefault(p => p.PaperId.Equals(viewedStatistic.PaperId));
                if (_paperStat == null)
                {
                    _paperStat = Add(viewedStatistic);
                }
                else
                {
                    _paperStat.Viewed = viewedStatistic.Viewed;
                    _context.PaperStatistics.Update(_paperStat);
                }
                _context.SaveChanges();
                return _paperStat;
            }
            catch
            {
                throw;
            }
        }

        public List<PaperStatistic> GetAll()
        {
            try
            {
                return _context.PaperStatistics.ToList();
            }
            catch
            {
                throw;
            }
        }

        private PaperStatistic Add(PaperStatistic newPaperStat)
        {
            try
            {
                _context.PaperStatistics.Add(newPaperStat);
                _context.SaveChanges();
                return newPaperStat;
            }
            catch
            {
                throw;
            }
        }
    }
}
