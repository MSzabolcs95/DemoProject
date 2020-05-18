using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Interfaces
{
    public interface IImageRepository
    {
        Task<List<ImageInfo>> GetAllImages();
        Task<List<ImageInfo>> GetImagesList(string name, DateTime startDate, DateTime endDate);
        Task UploadImage(ImageInfo imageInfo, ImageStorage imageStorage);
        Task<ImageStorage> GetImageStorageById(int id);
        Task<ImageInfo> GetImageById(int id);
        Task DeleteImage(ImageInfo image);
        Task RenameImages(List<ImageInfo> RenamedImages);
        Task<List<ImageInfo>> GetImagesFilteredByName(string name);
        Task<List<ImageInfo>> GetImagesFilteredByDateRange(DateTime startDate, DateTime endDate);
    }
}
