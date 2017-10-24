using Integrated3M.Framework.BL.Enumeration;
using System;

namespace Integrated3M.Framework.BL.Model
{

    //This is the Default Module Mapping according to System Role
    /// <summary>
    /// 
    /// </summary>
    public class RoleModule 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
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

        /// <summary>
        /// Gets or sets the system role.
        /// </summary>
        /// <value>
        /// The system role.
        /// </value>
        public Role Role { get; set; }
        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        public Module Module { get; set; }

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
