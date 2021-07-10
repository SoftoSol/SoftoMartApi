namespace SoftoMart.Common
{
  public static class SqlProcedures
  {
    public static string CreateUser => "uspInsertUser";
    public static string UpdateUser => "uspUpdateUser";
    public static string DeleteUser => "uspDeleteUser";
    public static string GetUser=> "uspGetUser";
    public static string GetUsers=> "uspGetAllUsers";
    public static string GetUserByUsername => "uspGetUserByUsername";
    
    public static string CreateSeller => "uspInsertSeller";
    public static string UpdateSeller => "uspUpdateSeller";
    public static string DeleteSeller => "uspDeleteSeller";
    public static string GetSeller => "uspGetSeller";
    public static string GetSellers => "uspGetAllSeller";
    public static string GetSellerByUsername => "uspGetSellerByUsername";

    public static string CreateCustomer=> "uspInsertCustomer";
    public static string UpdateCustomer => "uspUpdateCustomer";
    public static string DeleteCustomer => "uspDeleteCustomer";
    public static string GetCustomer=> "uspGetCustomer";
    public static string GetCustomers=> "uspGetAllCustomer";
    public static string GetCustomerByUsername => "uspGetCustomerByUsername";
  }
}
