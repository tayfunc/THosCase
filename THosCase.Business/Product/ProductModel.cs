namespace THosCase.Business
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Product Model
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public int CategoryName { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Image Path
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Creator User Id
        /// </summary>
        public int CreatorUserId { get; set; }

        /// <summary>
        /// Creator User Name
        /// </summary>
        public string CreatorUserName { get; set; }

        /// <summary>
        /// Product Properties
        /// </summary>
        public string ProductProperties { get; set; }
    }
}
