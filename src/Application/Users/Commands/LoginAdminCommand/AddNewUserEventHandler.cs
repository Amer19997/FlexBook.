using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Interfaces.NotificationServices;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;
internal class AddNewUserEventHandler : INotificationHandler<AddNewUserEvent>
{
    private readonly INotificationService _notificationService;
    private readonly IResourceService _resourceService;

    public AddNewUserEventHandler(INotificationService notificationService, IResourceService resourceService)
    {
        _notificationService = notificationService;
        _resourceService = resourceService;
    }

    public async Task Handle(AddNewUserEvent notification, CancellationToken cancellationToken)
    {
        var template = new AddPasswordTemplateBody() {  Name = notification.Name,Email =notification.Email,ApiUrl =notification.ApiUrl };
        var body = $"{template.Body}";
        _notificationService.Push(new EmailMessage(notification.Email, _resourceService.GetInfo("EmailTemplateAddNewUser"), body));
    }
}
