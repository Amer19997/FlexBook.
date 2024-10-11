using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Domain;
using MediatR;
using Microsoft.Extensions.Options;

namespace FlexBook.Application.Features.Admin.Commnds.AssignRoleToUserCommand;
public class AssignRoleToUserCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public class Handler : IRequestHandler<AssignRoleToUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IResourceService _resourceService;
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;

        public Handler(IUnitOfWork unitOfWork,
             IAccountService accountService,
             ITokenService tokenService,
             IOptions<AppSettings> appSettings,
             IResourceService resourceService,
             IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _tokenService = tokenService;
            _appSettings = appSettings.Value;
            _resourceService = resourceService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.FindById(request.UserId, cancellationToken);
            if (user == null) throw new Exception("User not found");

            user.RoleId = request.RoleId;
            //_unitOfWork.Users.Update(user);
            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}