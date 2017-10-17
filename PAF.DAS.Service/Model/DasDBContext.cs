using Microsoft.EntityFrameworkCore;

namespace PAF.DAS.Service.Model
{
    public class DasDBContext : DbContext
    {
        public DasDBContext(DbContextOptions<DasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<PaperArchieve> PaperArchieves { get; set; }
    }
}
