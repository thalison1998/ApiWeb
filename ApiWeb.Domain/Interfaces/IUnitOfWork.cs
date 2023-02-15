﻿namespace ApiBase.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}
