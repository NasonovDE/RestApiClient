using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;
using Common.Extentions;

namespace RestApiClient.Models
{
    public class Cinema
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Место показа
        /// </summary> 
        [Required]
        [Display(Name = "Место показа", Order = 5)]
        public string CinemaPlace { get; set; }

        /// <summary>
        /// Количество посадочных мест
        /// </summary> 
        [Required]
        [Display(Name = "Количество посадочных мест", Order = 30)]
        public int NumberOfBilets { get; set; }


        /// <summary>
        /// QR код
        /// </summary> 
        [Required]
        [ScaffoldColumn(false)]
        public QRcode QRcode { get; set; }

        [Display(Name = "Наличие QR кода", Order = 7)]
        [UIHint("RadioList")]
        [TargetProperty("QRcode")]
        [NotMapped]
        public IEnumerable<SelectListItem> QRcodeDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (QRcode type in Enum.GetValues(typeof(QRcode)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == QRcode
                    });
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Расписание кино
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Kino> Kinos { get; set; }

    }
}