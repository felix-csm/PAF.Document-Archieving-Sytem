using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF.DAS.Service.Model
{
    public class CurrentUserModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Roles { get; set; }
    }
}
