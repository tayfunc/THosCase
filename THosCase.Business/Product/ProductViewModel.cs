namespace THosCase.Business.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Product View Model
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Products
        /// </summary>
        public List<ProductModel> Products { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// Page Title
        /// </summary>
        public string PageTitle { get; set; }
    }
}
