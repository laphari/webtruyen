using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webtruyen.Modelgethot
{
    public class Gethot
    {
        public int StoryId { get; set; }
        public string StoryName { get; set; }
        public string imghot { get; set; }
        public string trangthai { get; set; }
        public string namphathanh { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

    }
}