﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SWCRM.Models;
using System.Web.Mvc;
using System.Text;

namespace _SWCRM.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");//<a> etiketini oluşturur.
                tag.MergeAttribute("href", pageUrl(i));//<a href=2 vs
                tag.InnerHtml = i.ToString();//<a href="..">1
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}