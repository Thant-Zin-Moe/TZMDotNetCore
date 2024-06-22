﻿using Microsoft.EntityFrameworkCore;
using TZMDotNetCore.MvcApp.Models;

namespace TZMDotNetCore.MvcApp.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    //}
    public DbSet<BlogModel> Blogs { get; set; }
}