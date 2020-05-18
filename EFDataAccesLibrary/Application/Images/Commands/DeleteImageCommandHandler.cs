using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Commands
{
    public class DeleteImageCommandHandler
    {
        public static async Task DeleteImage(IImageRepository _imageRepository, int id)
        {
            var image = new ImageInfo();
            image = await _imageRepository.GetImageById(id);

            await _imageRepository.DeleteImage(image);
        }

    }
}
