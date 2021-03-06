using System;
using System.Collections.Generic;

namespace Cofoundry.Domain.Data
{
    /// <summary>
    /// Represents a type of content that can be inserted into a section of 
    /// a page which could be simple content like 'RawHtml', 'Image' or 
    /// 'PlainText'. Custom and more complex module types can be defined by a 
    /// developer. Module types are typically created when the application
    /// starts up in the auto-update process.
    /// </summary>
    public partial class PageModuleType
    {
        public PageModuleType()
        {
            PageModuleTemplates = new List<PageModuleTypeTemplate>();
            PageVersionModules = new List<PageVersionModule>();
        }

        /// <summary>
        /// Database Id of this instance
        /// </summary>
        public int PageModuleTypeId { get; set; }

        /// <summary>
        /// A human readable name that is displayed when selecting page modules
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An optional paragraph of description text that is displayed in the
        /// user interface to help someone decide which module to choose.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the view file (without extension) that gets rendered 
        /// with the module data. This file name needs to be unique.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// This is basically a soft delete, with archived templates
        /// not allowed to be assigned but allowed to be kept in place 
        /// to support references to previous page versions.
        /// </summary>
        public bool IsArchived { get; set; }

        #region Auditing

        /// <summary>
        /// Date the module type was created.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Date the module type was last updated.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        #endregion

        /// <summary>
        /// A page module can optionally have one or more templates in addition to the 
        /// default template. This allows for a user to display content in multiple 
        /// ways.
        /// </summary>
        public virtual ICollection<PageModuleTypeTemplate> PageModuleTemplates { get; set; }
        
        /// <summary>
        /// The page modules this type is used in.
        /// </summary>
        public virtual ICollection<PageVersionModule> PageVersionModules { get; set; }

        /// <summary>
        /// The custom entity modules this type is used in.
        /// </summary>
        public virtual ICollection<CustomEntityVersionPageModule> CustomEntityVersionPageModules { get; set; }
    }
}
