using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Story_Maker_Sridhar.Models
{
    public class Image_Table
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public string ImageCaption { get; set; }
        public string ImageSequence { get; set; }
        public DateTime DateofCreation { get; set; }
        public DateTime DateofModification { get; set; }
        public string ImageDescription { get; set; }

        public int StoryId { get; set; } // newly added
         [ForeignKey("StoryId")]
        public virtual Story_Table Storydet { get; set; }
        public Image_Table()
        {
            this.DateofCreation = DateTime.Now;
        }

        public string ivar1 { get; set; }
        public string ivar2 { get; set; }
        public string ivar3 { get; set; }

        public int inum1 { get; set; }
        public int inum2 { get; set; }

        public int inum3 { get; set; }

    }
}