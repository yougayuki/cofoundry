﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cofoundry.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Web
{
    /// <summary>
    /// Data model representing html text with full html editing
    /// </summary>
    public class RawHtmlDataModel : IPageModuleDataModel
    {
        [Required, Display(Name = "Html")]
        [Html(HtmlToolbarPreset.BasicFormatting, HtmlToolbarPreset.Headings, HtmlToolbarPreset.Source, HtmlToolbarPreset.Media)]
        //[Searchable]
        public string RawHtml { get; set; }

    }
}