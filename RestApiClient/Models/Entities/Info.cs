using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestApiClient.Models
{
    public class Info
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [Display(Name = "Версия Апи")]
        [UIHint("TextReadOnly")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or Sets NewsSites
        /// </summary>
        [Display(Name = "Источники")]
        [UIHint("ListString")]
        public List<string> NewsSites { get; set; }
    }
}