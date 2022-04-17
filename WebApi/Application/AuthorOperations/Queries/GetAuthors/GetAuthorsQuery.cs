using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.ToList();
            List<AuthorsViewModel> VM = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return VM;

        }
    }

    public class AuthorsViewModel {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirttDate { get; set; }

    }
}
