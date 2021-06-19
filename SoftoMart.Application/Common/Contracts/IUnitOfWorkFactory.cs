namespace SoftoMart.Application.Common.Contracts
{
  public interface IUnitOfWorkFactory
  {
    IUnitOfWork Create();
  }
}
