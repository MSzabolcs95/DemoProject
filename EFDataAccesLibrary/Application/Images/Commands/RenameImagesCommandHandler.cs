using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Commands
{
    public class RenameImagesCommandHandler
    {
        public static async Task RenameImages(IImageRepository _imageRepository, string newName)
        {
            var images = await _imageRepository.GetAllImages();
            string fullName = string.Empty;
            for(var i = 0; i < images.Count; i++)
            {
                fullName = newName + "." + Path.GetExtension(images[i].Name); //Add file extension to the new name
                images[i].Name = fullName;
                fullName = string.Empty;
            }
           
           
            await _imageRepository.RenameImages(images);
        }
    }
}
