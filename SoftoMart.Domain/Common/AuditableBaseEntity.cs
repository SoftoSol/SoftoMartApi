using System;

namespace SoftoMart.Domain.Common
{
  public abstract class AuditableBaseEntity : BaseEntity
  {
    public int? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
  }
}
