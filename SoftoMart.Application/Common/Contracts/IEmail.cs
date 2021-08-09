namespace SoftoMart.Application.Common.Contracts
{
    public interface IEmail
    {
        bool Send(string subject, string bod, string toAddress, string fromAddress);
        bool Send(string subject, string bod, string toAddress, string fromAddress, string fromName);
    }
}
