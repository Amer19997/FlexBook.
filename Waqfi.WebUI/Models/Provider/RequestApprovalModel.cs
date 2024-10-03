using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Provider;

public class RequestApprovalModel
{
    public Guid Id { get; set; }
    public string? ApprovalNotes { get; set; } 
}
