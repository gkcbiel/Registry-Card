using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Models
{
    public class OperationTypes
    {
        [Key]
        public int OperationTypeId { get; set; }
        public string OperationName { get; set; }
    }
}
