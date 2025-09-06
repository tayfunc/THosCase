namespace THosCase.Business.Abstraction
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseServiceResult
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public int Code { get; set; }

        protected BaseServiceResult(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
