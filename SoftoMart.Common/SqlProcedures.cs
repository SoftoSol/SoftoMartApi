namespace SoftoMart.Common
{
  public static class SqlProcedures
  {
    public static string CreateUser => "uspInsertUser";
    public static string UpdateUser => "uspUpdateUser";
    public static string GetUserByUsername => "uspGetUserByUsername";
    public static string AuthenticateUser => "uspAuthenticateUser";
    public static string CreateSeller => "uspInsertSeller";
  }
}
