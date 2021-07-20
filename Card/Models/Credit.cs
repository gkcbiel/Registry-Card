using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Models
{
    public class Credit
    {
        [Key]
        public string Id { get; set; }

        public string BatchNumber { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CardNumber { get; set; }

        public string FileName { get; set; }

        public string IssueDate { get; set; }

        public string Batch { get; set; }

        public string QuantityRecords { get; set; }
    }
}
