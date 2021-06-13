using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models.CustomHelpers
{
    public static class CityCustomHelper
    {
        public static MvcHtmlString RenderDdlCities(this HtmlHelper html, IEnumerable<City> cities)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "IDCity");
            selectTag.MergeAttribute("CityName", "IDCity");
            selectTag.AddCssClass("form-control");

            foreach (City city in cities)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", city.IDCity.ToString());
                optionTag.SetInnerText(city.Name);
                selectTag.InnerHtml += optionTag.ToString();
            }

            return new MvcHtmlString(selectTag.ToString());
        }
    }
}