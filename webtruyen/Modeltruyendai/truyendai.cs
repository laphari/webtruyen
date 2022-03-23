using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webtruyen.Modeltruyendai
{
    public class truyendai
    {
        public int StoryId { get; set; }
        public string StoryName { get; set; }
        public string StoryImage { get; set; }
        public string Nxb { get; set; }
        public string Ngonngu { get; set; }
        public string namsx { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}