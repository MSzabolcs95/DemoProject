using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccesLibrary.DataAcces
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageInfo> ImageInfo { get; set; }
        public DbSet<ImageStorage> ImageStorage { get; set; }
    }
}
