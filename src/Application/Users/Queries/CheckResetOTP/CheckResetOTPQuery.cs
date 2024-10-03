using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Queries.CheckResetOTP;
public record CheckResetOTPQuery(string email,string otp) :IRequest<TResponse<string>>;
