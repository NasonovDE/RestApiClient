using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestApiClient.Models
{
    public class News
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

           
        [HiddenInput(DisplayValue = false)]
        public bool? Featured { get; set; }

        [Required]
        [Display(Name = "Название статьи", Order = 10)]
        public string Title { get; set; }


        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets ImageUrl
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or Sets NewsSite
        /// </summary>
        [Required]
        [Display(Name = "Сайт статьи", Order = 30)]
        public string NewsSite { get; set; }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [Required]
        [Display(Name = "Краткое содержание статьи", Order = 20)]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or Sets PublishedAt
        /// </summary>
        
        [HiddenInput(DisplayValue = false)]
        public string PublishedAt { get; set; }

        /// <summary>
        /// Gets or Sets Launches
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public List<ArticlesEvents> Launches { get; set; }

        /// <summary>
        /// Gets or Sets Events
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public List<ArticlesEvents> Events { get; set; }
    }
}