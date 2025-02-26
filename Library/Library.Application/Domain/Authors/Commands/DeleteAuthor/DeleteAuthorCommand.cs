﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthor;
public record DeleteAuthorCommand(Guid Id) : IRequest;
