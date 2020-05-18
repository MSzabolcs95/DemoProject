using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Commands
{
    public class DownloadImageCommandHandler
    {
        public static async Task<string> DownloadImage(IImageRepository _imageRepository, int id)
        {
            var image = new ImageStorage();
            image = await _imageRepository.GetImageStorageById(id);
            
            var convertedPicture = Convert.ToBase64String(image.Picture);

            return convertedPicture;
        }
    }
}
