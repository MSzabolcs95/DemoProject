using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace EFDataAccesLibrary.Models
{
    public class Image
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
