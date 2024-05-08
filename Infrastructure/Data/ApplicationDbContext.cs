using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    // Миграции
    // dotnet ef migrations add "Init" --project .\Infrastructure\Infrastructure.csproj --startup-project .\Server\Server.csproj --output-dir .\Data\Migrations
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }


        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<PrintDevice> PrintDevices { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<PrintInstallation> PrintInstallations { get; set; }
    }
}
