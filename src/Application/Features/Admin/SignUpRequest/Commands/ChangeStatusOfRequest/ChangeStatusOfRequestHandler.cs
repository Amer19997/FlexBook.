using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;
using FlexBook.Domain.Enums;

namespace FlexBook.Application.Features.Admin.SignUpRequest.Commands.ChangeStatusOfRequest;
public record ChangeStatusOfRequestCommand(Guid userId, bool Approve) : IRequest<TResponse<bool>>;

public class ChangeStatusOfRequestHandler : IRequestHandler<ChangeStatusOfRequestCommand, TResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    public IResourceService ResourceService { get; set; }

    public ChangeStatusOfRequestHandler(IUnitOfWork unitOfWork,
                                        IResourceService resourceService)
    {
        _unitOfWork = unitOfWork;
        ResourceService = resourceService;
    }
    public async Task<TResponse<bool>> Handle(ChangeStatusOfRequestCommand request, CancellationToken cancellationToken)
    {
        var resu = (await _unitOfWork.Users.FindAsync(filter: m => m.Id == request.userId,
                                                    includeProperties: "Country,University,Department,Faculty")).FirstOrDefault();

        resu = resu.UpdateUserStatus(request.Approve ? UserStatus.Active : UserStatus.Deactive,
                                     request.Approve ? LookUpStatus.Active : LookUpStatus.Deactive);

        var commitResult = await _unitOfWork.CommitAsync(cancellationToken);

        return commitResult > 0 ? TResponse<bool>.Success(true): 
                                  TResponse<bool>.Failure(new[] { ResourceService.GetError("SomeThingError") });

    }
}
