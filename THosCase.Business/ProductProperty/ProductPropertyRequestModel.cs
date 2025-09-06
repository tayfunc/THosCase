namespace THosCase.Business.RequestModel
{
    /// <summary>
    /// Product Property Request Model
    /// </summary>
    public class ProductPropertyRequestModel
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
        /// Property Id
        /// </summary>
        public int PropertyId { get; set; }
    }
}
