using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Models
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OperationTypes")]
        public int FKOperationTypeId { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public DateTime CreateDate { get; set; } 
    }
}
