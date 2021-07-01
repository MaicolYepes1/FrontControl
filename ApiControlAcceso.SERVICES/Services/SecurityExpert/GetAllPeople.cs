using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetAllPeople : IGetAllPeople
    {
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;

        public GetAllPeople(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllPeopleSe() 
        {
            var result = await _context.Users.FromSqlRaw("GetAllPeopleAccess").ToListAsync();
            var map = _mapper.Map<List<UserDto>>(result);
            return  map;
        }
    }
}
