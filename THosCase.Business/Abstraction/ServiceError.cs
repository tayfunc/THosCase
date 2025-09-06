namespace THosCase.Business.Abstraction
{
    public class ServiceError : BaseServiceResult
    {
        public ServiceError(string message, int code) : base(message, code)
        {
        }

        public static ServiceError DefaultError => new ServiceError("Genel hata", 999);

        public static ServiceError InvalidUser => new ServiceError("Geçersiz kullanıcı bilgisi", 998);

        public static ServiceError UsernameMustNotBeEmpty => new ServiceError("Kullanıcı adı boş olamaz", 997);

        public static ServiceError PasswordMustNotBeEmpty => new ServiceError("Kullanıcı adı boş olamaz", 997);

        public static ServiceError CreateUserFailed => new ServiceError("Kullanıcı oluştururken hata meydana geldi", 996);

        public static ServiceError CategoryDeleteFailed => new ServiceError("Kategori silme işleminde hata", 995);

        public static ServiceError CategoryDeleteSucceeded => new ServiceError("Kategori silme işlemi başarılı", 994);

        public static ServiceError CategoryAddFailed => new ServiceError("Kategori ekleme işleminde hata", 993);

        public static ServiceError CategoryUpdateFailed => new ServiceError("Kategori güncelleme işleminde hata", 992);

        public static ServiceError UserAddFailed => new ServiceError("Kullanıcı ekleme işleminde hata: {0}", 991);

        public static ServiceError UserDeleteFailed => new ServiceError("Kullanıcı silme işleminde hata", 990);

        public static ServiceError UserUpdateFailed => new ServiceError("Kullanıcı güncelleme işleminde hata: {0}", 989);

        public static ServiceError CategoryHasSubRecord => new ServiceError("Kategoriye ait alt kategoriler mevuct. Silme işleminde hata", 988);

        public static ServiceError ProductAddFailed => new ServiceError("Ürün ekleme işleminde hata", 987);

        public static ServiceError ProductDeleteFailed => new ServiceError("Ürün silme işleminde hata", 986);

        public static ServiceError ProductPropertyAddFailed => new ServiceError("Ürün özelliği ekleme işleminde hata", 985);

        public static ServiceError ProductPropertyDeleteFailed => new ServiceError("Ürün özelliği silme işleminde hata", 984);
    }
}
