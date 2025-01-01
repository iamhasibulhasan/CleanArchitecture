namespace CleanArchitecture.Domain.Common;

using System;

public class AuditLog
{
    public int Id { get; set; }
    public string EventType { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string Data { get; set; }
}
