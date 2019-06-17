using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarterProject.Api.Data;
using StarterProject.Api.Data.Entities;
using StarterProject.Api.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarterProject.Api.Features.Users
{
    public class GetAllUsersRequest : IRequest<List<GetUserDto>>
    {
    }

    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, List<GetUserDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersRequestHandler(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetUserDto>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            return await _context
                .Set<User>()
                .ProjectTo<GetUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }

    public class GetAllUsersRequestValidator : AbstractValidator<GetAllUsersRequest>
    {
        public GetAllUsersRequestValidator()
        {

        }
    }
}
