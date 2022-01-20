using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RestApiClient.Models
{
    public class ImportLog
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Начало импорта")]
        [UIHint("TextReadOnly")]
        public DateTime StartImport { get; set; }

        [Display(Name = "Конец импорта")]
        [UIHint("TextReadOnly")]
        public DateTime EndImport { get; set; }


        [Display(Name = "Число успешных добавлений")]
        [UIHint("TextReadOnly")]
        public int SuccessCount { get; set; }

        [Display(Name = "Число неуспешных добавлений")]
        [UIHint("TextReadOnly")]
        public int FailedCount { get; set; }

        [Display(Name = "Logs")]
        [UIHint("ImportLogs")]
        public List<ImportItemLog> ImportLogs { get; set; }
    }
}