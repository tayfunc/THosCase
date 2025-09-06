namespace THosCase.Business.RequestModel
{
    using System;

    /// <summary>
    /// Category Request Model
    /// </summary>
    public class CategoryRequestModel
    {
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Parent Category Id
        /// </summary>
        public int ParentCategoryId { get; set; }

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
    }
}
