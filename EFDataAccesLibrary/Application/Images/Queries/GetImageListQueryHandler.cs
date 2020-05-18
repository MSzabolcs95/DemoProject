using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Queries
{
    public class GetImageListQueryHandler 
    {
        public static async Task<List<ImageInfo>> GetImagesList(IImageRepository _imageRepository, string name, DateTime startDate, DateTime endDate)
        {
            if(name.Length < 1 || name == "null")
            {
                return await _imageRepository.GetImagesFilteredByDateRange(startDate, endDate);
            }
            return await _imageRepository.GetImagesList(name,startDate,endDate);
        }
    }
}
