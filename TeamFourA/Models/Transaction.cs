using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class Transaction
    {
        public string Id { get; set; } // guid
        public int UserId { get; set; }
        public DateTime UtcTimestamp { get; set; } // DateTime.UtcNow
        public virtual User User { get; set; }
        public virtual IList<TransactionDetail> TransactionDetail { get; set; }

    }
}
