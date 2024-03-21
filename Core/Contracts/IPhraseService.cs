﻿using Core.Models;

namespace Core.Contracts
{
    public interface IPhraseService
    {
        Task<List<Phrase>> GetAsync();
        Task CreateAsync(Phrase phrase);
    }
}