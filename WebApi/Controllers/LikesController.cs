﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Infrastructure.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeManager _likeManager;
        private readonly IMapper _mapper;

        public LikesController(ILikeManager likeManager, IMapper mapper)
        {
            this._likeManager = likeManager;
            this._mapper = mapper;
        }

        // GET: api/Likes
        [HttpGet]
        public IList<LikeViewModel> GetLikes()
        {
            var likes = _likeManager.GetLikes();
            var result = _mapper.Map<IList<Like>, IList<LikeViewModel>>(likes);
            return result;
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<LikeViewModel>> GetLike(Guid id)
        {
            var like = _likeManager.GetLikeById(id);
            var result = _mapper.Map<Like, LikeViewModel>(like);
            return result;
        }

        // GET: api/Likes/ByFilm/5
        [HttpGet("ByFilm/{filmId}")]
        [Authorize]
        public LikeViewModel GetLikeByFilm(Guid filmId)
        {
            var like = _likeManager.GetLikeByFilm(HttpContext.User.Identity.Name, filmId);
            var result = _mapper.Map<Like, LikeViewModel>(like);
            return result;
        }

        // POST: api/Likes
        [HttpPost]
        [Authorize]
        public async Task<LikeViewModel> PostLike(LikeViewModel likeViewModel)
        {
            var newlike = _mapper.Map<LikeViewModel, Like>(likeViewModel);
            var createdLike = await _likeManager.CreateAsync(newlike);
            var result = _mapper.Map<Like, LikeViewModel>(createdLike);
            return result;
        }

        // DELETE: api/Likes/ByFilm/5
        [HttpDelete("ByFilm/{filmId}")]
        [Authorize]
        public async Task<ActionResult> DeleteLikeByFilm(Guid filmId)
        {
            var deletingResult = await _likeManager.DeleteByFilmAsync(HttpContext.User.Identity.Name, filmId);
            if (deletingResult)
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteLike(Guid id)
        {
            var deletingResult = await _likeManager.DeleteAsync(id);
            if (deletingResult)
                return Ok();
            else
                return BadRequest();
        }
    }
}
