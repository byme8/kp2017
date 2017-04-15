using kp.Entities.Exceptions;

namespace kp.Business.Errors
{
    public static class Error
    {
        public static void Throw(string errorCode)
        {
            throw new BusinessException(errorCode);
        }

        public static void Throw(string[] errorCodes)
        {
            throw new BusinessException(errorCodes);
        }

        public static void Throw(string errorCode, params object[] args)
        {
            throw new BusinessException(string.Format(errorCode, args));
        }
    }

    public static class Errors
    {
        #region LoginScreen

        public const string WrongLoginOrPassword = "WrongLoginOrPassword";

        #endregion LoginScreen

        #region User

        public const string UserLoginExist = "UserLoginExist";
        public const string UserShouldHaveLogin = "UserShouldHaveLogin";
        public const string UserShouldHavePassword = "UserShouldHavePassword";
        public const string YouCantDeleteThisUser = "YouCantDeleteThisUser";

        #endregion User

        #region Roles

        public const string RoleExist = "RoleExist";
        public const string RoleShouldHaveName = "RoleShouldHaveName";
        public const string YouCantDeleteThisRole = "YouCantDeleteThisRole";
        public const string RoleNameShouldBeUnique = "RoleNameShouldBeUnique";
        public const string UserDoesNotHaveSuchRole = "UserDoesNotHaveSuchRole";

        #endregion Roles

        #region Entities

        public const string SuchEntryDoesNotExist = "SuchEntryDoesNotExistKey:{0}";

        #endregion Entities

        #region Authorization

        public const string AcessDenied = "AcessDenied";
        public const string TokenExpired = "TokenExpired";

        #endregion Authorization
    }
}