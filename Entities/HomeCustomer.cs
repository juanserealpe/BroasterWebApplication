using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BroasterWebApp.Entities{

public class HomeCustomer
{
        [Key]
        [MaxLength(20)]
        public string MainPhoneNumber { get; set; }

        [MaxLength(20)]
        public string SecondPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressCustomer { get; set; }

        [MaxLength(100)]
        public string SecondAddress { get; set; }
}
}