using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaByteTechnologyExam.Models
{
    [Table("DIVISION")]
    public class Division
    {
        [Column("DIV_ID")]
        public long Id { get; set; }

        [Column("DIVISION_NAME")]
        public string Name { get; set; }
    }
}