namespace Peticom.Service.Constants;

public static class Messages
{
    //Common
    public static string USER_NOT_FOUND = "Sisteme kayıtlı kullanıcı bulunamadı!";

    //Register Errors
    public static string DUPLICATE_USER_NAME = "Bu kullanıcı adı başka bir kullanıcı tarafından kullanılmaktadır!";
    public static string DUPLICATE_EMAİL = "Bu e-posta başka bir kullanıcı tarafından kullanılmaktadır!";
    public static string PASSWORD_TOO_SHORT = "Şifreniz en az 6 karakterli olmalıdır!";
    public static string PASSWORD_REQUIRES_LOWER = "Şifreniz en az 1 adet küçük karakter içermelidir!";
    
    //Login Errors 
    public static string PASSWORD_WRONG = "E-Posta veya şifreniz hatalı!";
    
    //Update Password Errors 
    public static string CURRENT_PASSWORD_WRONG = "Geçerli şifreniz hatalı!";
    public static string PASSWORDS_NOT_MATCH = "Girdiğiniz şifreler uyuşmamaktadır!";
    public static string PASSWORD_UPDATE_ERROR = "Şifre güncelleme işlemi sırasında bir hata oluştu!";
    
    //Reset Password Errors
    public static string RESET_PASSWORD_WRONG = "Doğrulama kodunuz hatalı!";

}