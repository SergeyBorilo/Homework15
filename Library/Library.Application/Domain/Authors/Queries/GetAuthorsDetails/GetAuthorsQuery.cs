using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Common;
using MediatR;

namespace Library.Application.Domain.Authors.Queries.GetAuthorsDetails;

public record GetAuthorsQuery(int Page, int PageSize) : IRequest<PageResponse<AuthorDto[]>>;
