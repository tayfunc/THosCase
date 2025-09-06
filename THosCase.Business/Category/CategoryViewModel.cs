namespace THosCase.Business.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Category View Model
    /// </summary>
    public class CategoryViewModel
    {
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
