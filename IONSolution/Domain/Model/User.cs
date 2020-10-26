using System;
using System.ComponentModel.DataAnnotations;

namespace IONSolution.Domain.Model
{
    public class User
    {
        [Key]
        public string UserName{ get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

    }
}
