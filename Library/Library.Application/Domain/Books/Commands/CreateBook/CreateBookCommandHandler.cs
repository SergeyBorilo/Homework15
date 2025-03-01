﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Models;
using MediatR;

namespace Library.Application.Domain.Books.Commands.CreateBook;
public class CreateBookCommandHandler(
    IBooksRepository booksRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateBookCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateBookData(command.Title, command.Description);
        var book = Book.Create(data);
        booksRepository.Add(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return book.Id;
    }
}
