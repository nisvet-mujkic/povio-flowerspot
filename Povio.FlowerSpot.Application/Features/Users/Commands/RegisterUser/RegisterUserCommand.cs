using AutoMapper;
using MediatR;
using OneOf;
using OneOf.Types;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Features.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(string Username, string Password, string Email) : IRequest<OneOf<Success, None>>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OneOf<Success, None>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<OneOf<Success, None>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user, cancellationToken);

            return new Success();
        }
    }
}
