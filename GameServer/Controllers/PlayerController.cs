using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameServer.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext _context;

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View("this in index");
        //}

        public PlayerController(PlayerContext context)
        {
            _context = context;

            if (_context.players.Count() == 0)
            {
                // Create a new Player if collection is empty,
                // which means you can't delete all Players.
                for (int i = 0; i < 10; i++)
                {
                    PlayerJson p = new PlayerJson
                    {
                        x = 1,
                        y = 2,
                        name = "2",
                        hitpoints = 10,
                        attack = 1,
                        defence = 1,
                        level = 1,
                        experience = 0,
                        gold = 4
                    };
                    _context.players.Add(p);
                }

                _context.SaveChanges();
            }
        }


        // GET api/player
        [HttpGet]
        public ActionResult<IEnumerable<PlayerJson>> GetAll()
        {
            return _context.players.ToList();
        }

        // GET api/player/5
        [HttpGet("{id}", Name = "GetPlayer")]
        public ActionResult<PlayerJson> GetById(long id)
        {
            PlayerJson p = _context.players.Find(id);
            if (p == null)
            {
                return NotFound("player not found");
            }
            return p;
        }

        // POST api/player
        [HttpPost]
        //public string Create(Player player)
        public ActionResult<Player> Create([FromBody] PlayerJson player)
        {
            _context.players.Add(player);
            _context.SaveChanges();

            //return Ok(); //"created - ok"; 
            return CreatedAtRoute("GetPlayer", new { id = player.id }, player);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] PlayerJson p)
        {
            var pp = _context.players.Find(id);
            if (pp == null)
            {
                return NotFound();
            }

            _context.players.Update(pp);
            _context.SaveChanges();

            return Ok(); //NoContent();
        }

       
        // DELETE api/values/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.players.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.players.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}




