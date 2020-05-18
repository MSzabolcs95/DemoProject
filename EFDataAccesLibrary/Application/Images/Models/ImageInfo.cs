using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccesLibrary.Application.Images.Models
{
    public class ImageInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
