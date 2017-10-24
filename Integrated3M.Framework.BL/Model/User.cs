using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated3M.Framework.BL.Model
{
    public class User : Common
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            CreatedDate = DateTime.Today;
            UpdatedDate = DateTime.Today;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        public int? Backup_User_Id { get; set; }
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Primary_Email { get; set; }
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Secondary_Email { get; set; }
        
        public bool Is_Authenticated { get; set; }
        public bool IsRequiredToChangePassword { get; set; }
        

        [Required]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? User_Role_Id { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Employee_Number { get; set; }
        public int? Shift_Id { get; set; }
        public string Phone_Number { get; set; }

    }
}
