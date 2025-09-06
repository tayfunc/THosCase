namespace THosCase.Business.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Product Property View Model
    /// </summary>
    public class ProductPropertyViewModel
    {
        /// <summary>
        /// Product Properties
        /// </summary>
        public List<ProductPropertyModel> ProductProperties { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        public List<ProductModel> Products { get; set; }

        /// <summary>
        /// Page Title
        /// </summary>
        public string PageTitle { get; set; }
    }
}
