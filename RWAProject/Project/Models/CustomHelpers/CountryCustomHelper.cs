using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models.CustomHelpers
{
    public static class CountryCustomHelper
    {
        public static SelectList RenderDdlCountries(this HtmlHelper html, IEnumerable<Country> countries)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "IDCountry");
            selectTag.MergeAttribute("CountryName", "IDCountry");
            selectTag.AddCssClass("form-control");

            foreach (Country country in countries)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", country.IDCountry.ToString());
                optionTag.SetInnerText(country.Name);
                selectTag.InnerHtml += optionTag.ToString();
            }

            

            return new SelectList(selectTag.ToString());
        }
    }
}