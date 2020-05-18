using EFDataAccesLibrary.Application.Images.Models;
using EFDataAccesLibrary.Application.Interfaces;
using EFDataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccesLibrary.Application.Images.Commands
{
    public class RenameImagesCommandHandler
    {
        public static async Task RenameImages(IImageRepository _imageRepository, string newName)
        {
            var images = new List<ImageInfo>();
            images = await _imageRepository.GetAllImages();
            string[] splitName = new string[0];
            string fullName = string.Empty;
            for(var i = 0; i < images.Count; i++)
            {
                splitName = images[i].Name.Split(".");
                if (splitName.Length > 1)
                {
                   fullName = newName + "." + splitName[splitName.Length -1]; //Add file extension to the new name
                   Array.Clear(splitName, 0, splitName.Length);
                }
                images[i].Name = fullName;
                fullName = string.Empty;
           }
           
           
            await _imageRepository.RenameImages(images);
        }
    }
}
