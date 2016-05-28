using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace ProjectHack.Models
{
    public abstract class CategoryElement
    {
        public string Title { get; private set; }
		public string Id { get; private set; }

		public CategoryElement(string title, string id)
		{
			Title = title;
			Id = id;
		}

		public CategoryElement(string title)
		{
			Title = title;
			Id = "";
		}

		public static List<CategoryElement> GetElementsFromFile(string filePath, string mainItem, string subItem)
	    {
			MainCategory currentCategory = new MainCategory("root","", null);
			int nestedDepth = 0;

			using (StreamReader sr = new StreamReader(filePath))
			{
				using (XmlReader reader = XmlReader.Create(sr))
				{
					reader.Read();
					reader.Read();
					reader.Read();
					while (reader.NodeType != XmlNodeType.EndElement || reader.Name != mainItem)
					{
						if (reader.NodeType == XmlNodeType.EndElement && reader.Name == subItem)
						{
							nestedDepth--;
							currentCategory = currentCategory.ParentElement;
						}

						if (reader.NodeType == XmlNodeType.Element && reader.Name == subItem)
						{
							nestedDepth++;

							MainCategory category = new MainCategory(reader.GetAttribute("Name"), reader.GetAttribute("ID"), currentCategory);
							currentCategory.AddElement(category);
							currentCategory = category;
						}
						else if (reader.NodeType == XmlNodeType.Element && reader.Name == "Topic")
						{
							reader.Read();
							if (reader.NodeType == XmlNodeType.Text)
							{
								Topic topic = new Topic(reader.Value);
								currentCategory.AddElement(topic);
							}
						}

						reader.Read();
					}
				}
			}
		    return currentCategory.Elements;
	    }

        public static string GetHtmlListString(IEnumerable<CategoryElement> elements)
        {
            string output = ReadElement(elements);
            return output;
        }

        private static string ReadElement(IEnumerable<CategoryElement> elements)
        {
            string output = "";
            foreach (CategoryElement element in elements)
            {
                output += "<li>";

                if (element is MainCategory)
                {
                    output += element.Title;
                    output += "<ul>";
                    output += ReadElement(((MainCategory)element).Elements);
                    output += "</ul>";
                }
                else if (element is Topic)
                {
                    output += element.Title;
                }

                output += "</li>";
            }

            return output;
        }
    }
}