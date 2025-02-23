using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Authors.Queries.GetAuthors;

public record GetAuthorDetailsQuery(Guid Id) : IRequest<AuthorDetailsDto>;
