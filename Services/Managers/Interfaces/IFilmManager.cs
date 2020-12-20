﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Managers.Interfaces
{
    public interface IFilmManager
    {
        IList<Film> GetAllFilms();
        Film GetFilmById(Guid id);
        Task<IList<Film>> GetRandomShakedFilms(string userId = null);
        IList<Genre> GetGenres(Guid id);
        Task<IList<Film>> GetSameUsersFilms(string userId);
        Task<bool?> IsLiked(string userId, Guid filmId);
        Task<Film> CreateAsync(Film film);
        Task<Film> UpdateAsync(Guid id, Film film);
        Task<bool> DeleteAsync(Guid id);
    }
}
