namespace SoftoMart.Common
{
  public static class Utils
  {
    public static string EncryptId(int id) { return id.ToString(); }
    public static int DecryptId(string encryptedId) { return int.Parse(encryptedId); }
  }
}
