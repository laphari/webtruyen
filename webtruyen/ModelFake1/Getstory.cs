using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webtruyen.ModelFake1
{
    public class Getstory
    {
        public int StoryId { get; set; }
        public string StoryName { get; set; }
        public string StoryImage { get; set; }
        public string StoryDescription { get; set; }
        public string StoryIsDone { get; set; }
        public string Storyauthor { get; set; }
        public string Storycate { get; set; }
        public DateTime StoryCreated { get; set; }
        public DateTime StoryUpdated { get; set; }
        public DateTime StoryDeleted { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}