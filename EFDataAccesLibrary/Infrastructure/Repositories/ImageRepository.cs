using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.DataAcces;
using EFDataAccesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _appDbContext;
        public ImageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ImageStorage> GetImageStorageById(int id)
        {
           return await _appDbContext.ImageStorage.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<ImageInfo>> GetImagesList(string name, DateTime startDate, DateTime endDate)
        {
            return await _appDbContext.ImageInfo.Where(x => x.Name.Contains(name) && x.Date >= startDate && x.Date <= endDate.AddDays(1) && x.IsDeleted != true).ToListAsync();
        }

        public async Task UploadImage(ImageInfo imageInfo, ImageStorage imageStorage)
        { 
            await _appDbContext.ImageInfo.AddAsync(imageInfo);
            await _appDbContext.ImageStorage.AddAsync(imageStorage);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteImage(ImageInfo image)
        {
            image.IsDeleted = true;
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<ImageInfo>> GetImagesFilteredByName(string name)
        {
            return await _appDbContext.ImageInfo.Where(x => x.Name.Contains(name) && x.IsDeleted != true).ToListAsync();
        }
        public async Task RenameImages(List<ImageInfo> RenamedImages)
        {
             _appDbContext.ImageInfo.UpdateRange(RenamedImages);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<ImageInfo>> GetImagesFilteredByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _appDbContext.ImageInfo.Where(x => x.Date >= startDate && x.Date <= endDate.AddDays(1) && x.IsDeleted != true).ToListAsync();
        }

        public async Task<List<ImageInfo>> GetAllImages()
        {
            return await _appDbContext.ImageInfo.ToListAsync();
        }

        public async Task<ImageInfo> GetImageById(int id)
        {
            return await _appDbContext.ImageInfo.SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}
