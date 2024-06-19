using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Generic
{
    interface Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
