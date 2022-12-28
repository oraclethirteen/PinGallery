using SQLite;
using System;

namespace PinGallery.Data.Tables
{
    [Table("Photos")]
    public class Photo
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
    }
}