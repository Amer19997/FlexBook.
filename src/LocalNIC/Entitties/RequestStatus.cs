using System.ComponentModel.DataAnnotations;

namespace Waqfi.LocalNIC.Entities;
public enum RequestStatus
{
    Draft = 0,
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    New = 4,

    DraftVersion = 5,
    PendingVersion = 6,
    RejectedVersion = 7,
    ReturnedVersion = 8,
    Deprecated = 9
}