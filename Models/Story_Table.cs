using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Story_Maker_Sridhar.Models
{
    public class Story_Table
    {
        [Key]
        public int StoryId { get; set; }
        [Required]
        public string StoryName { get; set; }

        public int StorySeq { get; set; }

        public string AuthorName { get; set; }
        public DateTime DateandTimeCreated { get; set; }

        public DateTime DateandTimeModified { get; set; }
        public string Importantevel { get; set; }

        //public virtual Image_Table ImageID { get; set; } 

        public string speed { get; set; }

        public int TimerInterval { get; set; }

        public string var1 { get; set; }
        public string var2 { get; set; }

        public string var3 { get; set; }

        public int num1 { get; set; }

        public int num2 { get; set; }
        public int num3 { get; set; }
        public Story_Table()
        {
        this.DateandTimeCreated = DateTime.Now;
        }

    }
}