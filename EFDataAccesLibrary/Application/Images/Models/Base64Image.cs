using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccesLibrary.Application.Images.Models
{
    public class Base64Image
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Base64Picture { get; set; }
    }
}
