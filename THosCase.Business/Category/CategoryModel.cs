namespace THosCase.Business
{
    using System;

    public class CategoryModel
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
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// Parent Category Name
        /// </summary>
        public string ParentCategoryName { get; set; }

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
    }
}
