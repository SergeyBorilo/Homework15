﻿namespace Library.Application.Common;

public record PageResponse<T>(int Total, T Data) where T : class;
