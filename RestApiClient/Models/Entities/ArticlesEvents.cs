using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestApiClient.Models
{
    public class ArticlesEvents
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [Required]
        [Display(Name = "Провайдер", Order = 10)]
        public string Provider { get; set; }
    }
}