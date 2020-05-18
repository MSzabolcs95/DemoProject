using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccesLibrary.Application.Images.Models
{
    public class ImageStorage
    {
        public int Id { get; set; }
        public int ImageInfoId { get; set; }
        public byte[] Picture { get; set; }
        
    }
}
