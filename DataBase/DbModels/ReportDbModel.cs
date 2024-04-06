using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DbModels
{
    public class ReportDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdReport { get; set; }

        [Required]
        public string Title { get; set; }

        public byte [] Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        private ReportDbModel() { }

        public ReportDbModel(string title, byte [] image, string description, string location)
        {
            this.Title = title;
            this.Image = image;
            this.Description = description;
            this.Location = location;
        }
        public ReportDbModel(string title, string description, string location)
        {
            this.Title = title;
            this.Description = description;
            this.Location = location;
        }

    }
}
