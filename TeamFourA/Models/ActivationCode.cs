using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class ActivationCode
    {
        public string Id { get; set; } // guid
        public string TransactionDetailId { get; set; }
        public virtual TransactionDetail TransactionDetail { get; set; }
    }
}
