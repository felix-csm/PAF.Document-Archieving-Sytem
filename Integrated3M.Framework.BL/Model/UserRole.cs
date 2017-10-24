using Integrated3M.Framework.BL.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated3M.Framework.BL.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRole 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRole"/> class.
        /// </summary>
        public UserRole()
        {
            UserModules = new List<UserModule>();
            CreatedDate = DateTime.Today;
            UpdatedDate = DateTime.Today;
        }
        // Primitive
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Designation { get; set; }

        //handle circular reference issue
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        // Foreign
        public User User { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
       
        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int CountryId { get; set; }
        /// <summary>
        /// Gets or sets the system role.
        /// </summary>
        /// <value>
        /// The system role.
        /// </value>
        public Role Role { get; set; }
        /// <summary>
        /// Gets or sets the system role identifier.
        /// </summary>
        /// <value>
        /// The system role identifier.
        /// </value>
        public int RoleId { get; set; }

        
        //Navigation
        /// <summary>
        /// Gets or sets the user modules.
        /// </summary>
        /// <value>
        /// The user modules.
        /// </value>
        public List<UserModule> UserModules { get; set; }

        //eg. Q2-2016
        /// <summary>
        /// Gets or sets the start quarter.
        /// </summary>
        /// <value>
        /// The start quarter.
        /// </value>
        public string StartQuarter { get; set; }
        //eg. Q2-2016
        /// <summary>
        /// Gets or sets the end quarter.
        /// </summary>
        /// <value>
        /// The end quarter.
        /// </value>
        public string EndQuarter { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime? UpdatedDate { get; set; }

    }
}
