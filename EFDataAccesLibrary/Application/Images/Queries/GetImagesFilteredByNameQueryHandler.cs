using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Queries
{
    public class GetImagesFilteredByNameQueryHandler
    {
        public static async Task<List<ImageInfo>> GetImagesFilteredByName(IImageRepository _imageRepository, string name)
        {
            return await _imageRepository.GetImagesFilteredByName(name);
        }
    }
}
