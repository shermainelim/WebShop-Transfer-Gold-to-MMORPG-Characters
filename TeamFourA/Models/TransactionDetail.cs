using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class TransactionDetail
    {
        public string Id { get; set; } //guid
        public string TransactionId { get; set; } // get from transaction data
        public string ProductId { get; set; } // get from productid
        public int Quantity { get; set; } // given

        public int Value { get; set; } // given (shermaine)

        public double Amount { get; set; } // given
        public virtual Transaction Transaction { get; set; }
        public virtual Product Product { get; set; }

        public string GameUsername { get; set; }// given (shermaine)

        public virtual IList<ActivationCode> ActivationCodes { get; set; }
    }
}
