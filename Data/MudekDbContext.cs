using Microsoft.EntityFrameworkCore;
using MUDEK.Models;

namespace MUDEK.Data;
public class MudekDbContext : DbContext
{
    public MudekDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Degerlendirme> Degerlendirmeler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Course ve Evaluation arasında bir ilişki kurma
        modelBuilder.Entity<Degerlendirme>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Degerlendirmeler)
            .HasForeignKey(e => e.CourseId);
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Degerlendirmeler)
            .WithOne(d => d.Course)
            .HasForeignKey(d => d.CourseId);
        
        
    
    }
    
}