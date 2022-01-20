using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Models.Xlsx
{
    public class XlsxColumn
    {
        public string DisplayName { get; set; }
        public Type ColumnType { get; set; }
        public int? Order { get; set; }
    }
}