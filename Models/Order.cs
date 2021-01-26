using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Details { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
