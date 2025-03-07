﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;

public record UpdateAuthorCommand(Guid Id, string FirstName, string LastName, string? MiddleName = default) : IRequest;
