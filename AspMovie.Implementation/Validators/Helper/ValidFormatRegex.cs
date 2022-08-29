
namespace AspMovie.Implementation.Validators.Helper
{
    public static class ValidFormatRegex
    {
        public static string ValidNameFormat => @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";
        public static string ValidUsernameFormat => @"^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$";
        public static string ValidPasswordFormat => @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";


        #region Messages
        public static string ValidNameFormatMsg => "Invalid format for name";
        public static string ValidUsernameFormatMsg => "Invalid format for username";
        public static string ValidPasswordFormatMsg => "The password must contain a minimum of 8 characters, " +
            "one uppercase letter, " + "one lowercase letter, a number and a special character.";
        #endregion
    }

    public static class  Messages
    {
        public static string FirstNameRequired => "First name is required";
        public static string LastNameRequired => "Last name is required";
    }


}
