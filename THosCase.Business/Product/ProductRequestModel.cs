namespace THosCase.Business.RequestModel
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    /// <summary>
    /// Product Request Model
    /// </summary>
    public class ProductRequestModel
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
        /// Price
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Image Path
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// ImageFile
        /// </summary>
        public HttpPostedFileBase ImageFile { get; set; }

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
        /// Product Properties
        /// </summary>
        public string ProductProperties { get; set; }
    }
}
