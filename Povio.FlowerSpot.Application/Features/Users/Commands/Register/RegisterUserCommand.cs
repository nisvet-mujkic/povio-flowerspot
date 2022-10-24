using Ardalis.Result;
using AutoMapper;
using MediatR;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Features.Users.Commands.Register
{
    public record RegisterUserCommand(string Username, string Password, string Email) : IRequest<Result>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user, cancellationToken);

            return Result.Success();
        }
    }
}