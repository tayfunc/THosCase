namespace THosCase.Business.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Property View Model
    /// </summary>
    public class PropertyViewModel
    {
        /// <summary>
        /// Properties
        /// </summary>
        public List<PropertyModel> Properties { get; set; }

        /// <summary>
        /// Page Title
        /// </summary>
        public string PageTitle { get; set; }
    }
}
