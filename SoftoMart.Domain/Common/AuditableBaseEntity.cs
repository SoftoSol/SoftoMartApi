using System;

namespace SoftoMart.Domain.Common
{
  public abstract class AuditableBaseEntity
  {
    public int Id { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
  }
}
