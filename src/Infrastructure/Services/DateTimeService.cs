using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
