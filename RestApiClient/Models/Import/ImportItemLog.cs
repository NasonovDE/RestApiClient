using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiClient.Models
{
    public class ImportItemLog
    {
        public string Message { get; set; }
        public ImportItemLogType Type { get; set; }
    }
}