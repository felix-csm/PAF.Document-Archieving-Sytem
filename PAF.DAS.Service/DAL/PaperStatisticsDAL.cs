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

        public void AddDownloaded(Guid paperId)
        {
            PaperStatistic _paperStat;
            try
            {
                _paperStat = _context.PaperStatistics.FirstOrDefault(p => p.PaperId.Equals(paperId));
                if (_paperStat == null)
                {
                    Add(paperId, false);
                }
                else
                {
                    _paperStat.Downloaded++;
                    _context.PaperStatistics.Update(_paperStat);
                }
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddViewed(Guid paperId)
        {
            PaperStatistic _paperStat;
            try
            {
                _paperStat = _context.PaperStatistics.FirstOrDefault(p => p.PaperId.Equals(paperId));
                if (_paperStat == null)
                {
                    Add(paperId, true);
                }
                else
                {
                    _paperStat.Viewed++;
                    _context.PaperStatistics.Update(_paperStat);
                }
                _context.SaveChanges();
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

        private void Add(Guid newPaperStatId, bool isViewed)
        {
            try
            {
                PaperStatistic newpaperStat = new PaperStatistic();
                newpaperStat.PaperId = newPaperStatId;
                var result = isViewed ? newpaperStat.Viewed++ : newpaperStat.Downloaded++;
                _context.PaperStatistics.Add(newpaperStat);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
