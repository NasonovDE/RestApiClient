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
    public class Film
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary> 
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string NameFilm { get; set; }



        /// <summary>
        /// Возрастное ограничение
        /// </summary> 
        [Required]
        [ScaffoldColumn(false)]
        public FilmYears FilmYears { get; set; }

        [Display(Name = "Ограничение", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("FilmYears")]
        [NotMapped]
        public IEnumerable<SelectListItem> YearsDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (FilmYears type in Enum.GetValues(typeof(FilmYears)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == FilmYears
                    });
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Фото обложка
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual FilmCover FilmCover { get; set; }

        [Display(Name = "Обложка", Order = 60)]
        [NotMapped]
        public HttpPostedFileBase FilmCoverFile { get; set; }



        /// <summary>
        /// Формат
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Format> Formats { get; set; }

        [ScaffoldColumn(false)]
        public List<int> FormatIds { get; set; }

        [Display(Name = "Форматы", Order = 55)]
        [UIHint("MultipleSelect")]
        [TargetProperty("FormatIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> FormatDictionary
        {
            get
            {
                var db = new KinoAfishaContext();
                var query = db.Formats;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Films.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.Name}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }






        /// <summary>
        /// Расписание кино
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Kino> Kinos { get; set; }


    }
}