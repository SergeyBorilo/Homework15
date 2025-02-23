using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Common;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using MediatR;

namespace Library.Application.Domain.Books.Queries.GetBooks;
public record GetBooksQuery(int Page, int PageSize) : IRequest<PageResponse<BookDto[]>>, IRequest<PageResponse<BookDto>>;
