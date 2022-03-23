using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webtruyen.Models
{
    public class Story
    {
        [Key]
        public int StoryId { get; set;}
        public string StoryName { get; set;}
        public string StoryImage { get; set;}
        public string StoryDescription { get; set;}
        public string StoryIsDone { get; set;}
        public string Storyauthor { get; set;}
        public string Storycate { get; set;}
        public DateTime StoryCreated { get; set;}
        public DateTime StoryUpdated { get; set;}
        public DateTime StoryDeleted { get; set;}
        public string Nxb { get; set;}
        public string Ngonngu { get; set;}
        public string namsx { get; set;}
        public int? idtacgia { get; set; }
        [ForeignKey("idtacgia")]
        public virtual Author author { get; set; }
        public int? idcate { get; set; }
        [ForeignKey("idcate")]
        public virtual Category Category { get; set; }
        public ICollection<Anhbia> Anhbias { get; set;}
    }
}