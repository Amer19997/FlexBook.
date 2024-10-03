using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Application.Common.Interfaces.NotificationServices;
public interface IMessageSender<M> where M : Message
{
    Task SendAsync(M msg);
}
