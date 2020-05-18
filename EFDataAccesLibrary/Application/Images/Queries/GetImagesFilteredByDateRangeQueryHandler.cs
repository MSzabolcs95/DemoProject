using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Queries
{
    public class GetImagesFilteredByDateRangeQueryHandler
    {
        public static async Task<List<ImageInfo>> GetImagesFilteredByDateRange(IImageRepository _imageRepository, DateTime startDate, DateTime endDate)
        {
            return await _imageRepository.GetImagesFilteredByDateRange(startDate, endDate);
        }
    }
}
