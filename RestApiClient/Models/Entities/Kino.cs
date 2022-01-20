using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Common.Attributes;
using Common.Extentions;


namespace RestApiClient.Models
{
    public class Kino
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        /// <summary>
        /// Название
        /// </summary> 

        [ScaffoldColumn(false)]

        public virtual ICollection<Film> Films { get; set; }
        [ScaffoldColumn(false)]
        public List<int> FilmIds { get; set; }
        [Required]

        [Display(Name = "Название", Order = 5)]
        [UIHint("DropDownList")]
        [TargetProperty("FilmIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> FilmDictionary
        {
            get
            {
                var db = new KinoAfishaContext();
                var query = db.Films;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Kinos.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.NameFilm}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };

            }
        }




        /// <summary>
        /// Цена
        /// </summary> 
        [Required]
        [Display(Name = "Цена", Order = 10)]
        public decimal Price { get; set; }



        /// <summary>
        /// Место показа
        /// </summary> 

        [ScaffoldColumn(false)]
        public virtual ICollection<Cinema> Cinemas { get; set; }
        [ScaffoldColumn(false)]
        public List<int> CinemaIds { get; set; }
        [Required]
        [Display(Name = "Место показа", Order = 5)]
        [UIHint("DropDownList")]
        [TargetProperty("CinemaIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> CinemaDictionary
        {
            get
            {
                var db = new KinoAfishaContext();
                var query = db.Cinemas;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Kinos.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.CinemaPlace}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }
                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }

        // <summary>
        // Дата
        // </summary> 
        //// [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Дата сеанса", Order = 40)]
        public DateTime? NextArrivalDate { get; set; }


        // <summary>
        // Время Кино
        // </summary> 

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Время сеанса", Order = 40)]
        public DateTime? KinoTime { get; set; }

        ///// <summary>
        ///// Дата создания записи
        ///// </summary> 
        //[ScaffoldColumn(false)]
        //public DateTime CreateAt { get; set; }

    }
}