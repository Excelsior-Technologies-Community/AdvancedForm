using AdvancedForm.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedForm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
    }

}
