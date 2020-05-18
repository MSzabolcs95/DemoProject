using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Commands
{
    public class UploadImageCommandHandler
    {

        public static async Task UploadImage(IImageRepository _imageRepository, Base64Image image)
        {
            byte[] data = System.Convert.FromBase64String(image.Base64Picture.Split(',')[1]);

            var imageInfo = new ImageInfo
            {
                Date = image.Date,
                Id = image.Id,
                Name = image.Name
            };

            var imageStorage = new ImageStorage
            {
                ImageInfoId = image.Id,
                Picture = data,
            };

            await _imageRepository.UploadImage(imageInfo, imageStorage );
        }

    }
}
