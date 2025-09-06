namespace THosCase.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Product Property Model
    /// </summary>
    public class ProductPropertyModel
    {
        /// <summary>
        /// Product Property Id
        /// </summary>
        public int ProductPropertyId { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public int ProductName { get; set; }

        /// <summary>
        /// Property Id
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Property Name
        /// </summary>
        public int PropertyName { get; set; }
    }
}
