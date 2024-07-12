
using AutoMapper;
using Dapper;
using DatabaseFirst.DTOs;
using DatabaseFirst.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseFirst.Controllers
{
    public class ActorController : Controller
    {
        private readonly ILogger<ActorController> _logger;
        private readonly sakilaContext _sakilaContext;
        private readonly IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(typeof(ActorController));
        private readonly IDbConnection _dbConnection;

        public ActorController(ILogger<ActorController> logger, sakilaContext sakilaContext, IMapper mapper, IDbConnection dbConnection)
        {
            _logger = logger;
            _sakilaContext = sakilaContext;
            _mapper = mapper;
            _dbConnection = dbConnection;
        }

        public async Task<IActionResult> List()
        {
            var actors = _sakilaContext.Actors.Select(a => a).ToList<Actor>();
            //var actors = await _dbConnection.QueryAsync<Actor>("SELECT * FROM actor");
            //var actors = await _dbConnection.QueryAsync<Actor>(
            //    "GetAllRecords",
            //    new { },
            //    commandType: CommandType.StoredProcedure
            //);


            _logger.LogInformation("Get list actors");
            log.Info("Get list actors"); //log4net
            return View(actors);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(Actor actor)
        {
            if (ModelState.IsValid)
            {
                //_sakilaContext.Actors.Add(actor);
                //_sakilaContext.SaveChanges();
                string sql = "INSERT INTO actor (actor_id, first_name, last_name) VALUES (@actor_id, @first_name, @last_name)";
                await _dbConnection.ExecuteAsync(sql, new { actor_id = actor.ActorId, first_name = actor.FirstName, last_name = actor.LastName });
                _logger.LogInformation("Added actor");
                return RedirectToAction("List");
            }
            else
            {
                _logger.Log(LogLevel.Error, ("Actor is invalid"));
                return StatusCode(400);
            }
        }

        public async Task<IActionResult> Details(ushort id)
        {
            //var _actor = await (_sakilaContext.Actors
            //                        .Include(b => b.FilmActors)
            //                        .ThenInclude(f => f.Film)).FirstOrDefaultAsync(a => a.ActorId == id);

            var _actor = await _sakilaContext.Actors.FirstOrDefaultAsync(a => a.ActorId == id);

            if (_actor == null)
            {
                _logger.LogWarning("Actor not found");
                return NotFound();
            }

            await _sakilaContext.Entry(_actor).Collection(a => a.FilmActors).LoadAsync(); //Reference

            List<Film> films = new List<Film>();
            foreach (var filmActor in _actor.FilmActors)
            {
                films.Add(_sakilaContext.Films.FirstOrDefault(f => f.FilmId == filmActor.FilmId));
            }

            var actorViewModel = new ActorViewModel
            {
                actor = _actor,
                Films = films
            };

            _logger.LogInformation("Get details actor " + _actor.FirstName);
            return View(actorViewModel);
        }

        [HttpGet]
        public IActionResult Edit(ushort id)
        {
            var actor = _sakilaContext.Actors.Find(id);
            if (actor == null)
            {
                _logger.LogWarning("Actor not found");
                return NotFound();
            }
            var actorDTO = _mapper.Map<ActorDTO>(actor);
            return View(actorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActorDTO actor)
        {
            var _actor = _sakilaContext.Actors.Find(actor.ActorId);
            if (_actor == null)
            {
                _logger.LogWarning("Actor not found");
                return NotFound();
            }

            //_mapper.Map(actor, _actor);
            //_sakilaContext.SaveChanges();

            string sql = "UPDATE actor SET first_name = @first_name, last_name = @last_name WHERE actor_id = @actor_id";
            await _dbConnection.ExecuteAsync(sql, new { actor_id = actor.ActorId, first_name = actor.FirstName, last_name = actor.LastName });

            _logger.LogInformation("Eddited actor " + _actor.FirstName);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(ushort id)
        {
            var _actor = _sakilaContext.Actors.Find(id);
            if (_actor == null)
            {
                _logger.LogWarning("Actor not found");
                return NotFound();
            }
            _sakilaContext.Actors.Remove(_actor);
            _sakilaContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
