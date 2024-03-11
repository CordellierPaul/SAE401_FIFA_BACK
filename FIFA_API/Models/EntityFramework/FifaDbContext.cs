using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.EntityFramework
{
    public partial class FifaDbContext : DbContext
    {
        public FifaDbContext() { }

        public FifaDbContext(DbContextOptions<FifaDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Action> Action { get; set; } = null!;
        //public virtual DbSet<...> ... { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Il faudra donner des infos sur la base ici

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
