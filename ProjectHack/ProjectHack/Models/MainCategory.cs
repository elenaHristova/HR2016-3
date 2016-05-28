using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
    public class MainCategory : CategoryElement
    {
        public MainCategory ParentElement { get; private set; }
        public List<CategoryElement> Elements { get; set; }

        public MainCategory(string title, string id, MainCategory parent) : base(title, id)
        {
            Elements = new List<CategoryElement>();
            ParentElement = parent;
        }


        public void AddElement(CategoryElement element)
        {
            Elements.Add(element);
        }
    }
}