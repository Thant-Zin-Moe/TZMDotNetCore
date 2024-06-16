using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZMDotNetCore.ConsoleApp.Dtos;
using TZMDotNetCore.ConsoleApp.Services;

namespace TZMDotNetCore.ConsoleApp.EFCoreExamples;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    //}
    public DbSet<BlogDto> Blogs { get; set; }
}
