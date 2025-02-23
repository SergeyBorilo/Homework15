﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Books.Queries.GetBookDetails;
public record GetBookDetailsQuery(Guid Id) : IRequest<BookDetailsDto>;
