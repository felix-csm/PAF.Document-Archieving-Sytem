using Integrated3M.Framework.BL.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated3M.Framework.BL.Model

{
    /// <summary>
    /// 
    /// </summary>
    public class UserModule
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModule"/> class.
        /// </summary>
        public UserModule()
        {
            CreatedDate = DateTime.Today;
            UpdatedDate = DateTime.Today;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the user role identifier.
        /// </summary>
        /// <value>
        /// The user role identifier.
        /// </value>
        public int UserRoleId { get; set; }
        /// <summary>
        /// Gets or sets the system role identifier.
        /// </summary>
        /// <value>
        /// The system role identifier.
        /// </value>
        public int SystemRoleId { get; set; }
        /// <summary>
        /// Gets or sets the module identifier.
        /// </summary>
        /// <value>
        /// The module identifier.
        /// </value>
        public int ModuleId { get; set; }

        //handle circular reference issue
        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        public UserRole UserRole { get; set; }
        /// <summary>
        /// Gets or sets the system role.
        /// </summary>
        /// <value>
        /// The system role.
        /// </value>
        public Role Role { get; set; }
        /// <summary>
        /// Gets or sets the modules.
        /// </summary>
        /// <value>
        /// The modules.
        /// </value>
        public Module Modules { get; set; }

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
