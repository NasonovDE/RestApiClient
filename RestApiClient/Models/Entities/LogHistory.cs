using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestApiClient.Models
{
    public class LogHistory
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Импорт начат в", Order = 10)]
        public DateTime StartImport { get; set; }

        [Display(Name = "Импорт закончен в", Order = 20)]
        public DateTime EndImport { get; set; }


        [Display(Name = "Распознанных строк", Order = 30)]
        public int SuccessCount { get; set; }

        [Display(Name = "Не распознанных строк", Order = 40)]
        public int FailedCount { get; set; }
    }
}