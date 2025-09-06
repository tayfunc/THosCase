namespace THosCase.Business.Abstraction
{
    public class ServiceSuccessResult : BaseServiceResult
    {
        public ServiceSuccessResult(string message, int code) : base(message, code)
        {
        }

        public static ServiceSuccessResult DefaultServiceSuccessResult => new ServiceSuccessResult("İşlem başarılı.", 101);
    }
}
