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
        public int Qty { get; set; } = 0;

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View("this in index");
        //}

        public PlayerController(PlayerContext context)
        {
            _context = context;

            if (_context.Players2.Count() == 0)
            {
                // Create a new Player if collection is empty,
                // which means you can't delete all Players.
                for (int i = 0; i < 10; i++)
                {
                    Qty++;
                    Player2 p = new Player2
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
                    _context.Players2.Add(p);
                }

                _context.SaveChanges();
            }
        }


        // GET api/player
        [HttpGet]
        public ActionResult<IEnumerable<Player2>> GetAll()
        {
            return _context.Players2.ToList();
        }

        // GET api/player/5
        [HttpGet("{id}", Name = "GetPlayer")]
        public ActionResult<Player2> GetById(long id)
        {
            Player2 p = _context.Players2.Find(id);
            if (p == null)
            {
                return NotFound("player not found");
            }
            return p;
        }

        // POST api/player
        [HttpPost]
        //public string Create(Player player)
        public ActionResult<Player> Create([FromBody] Player2 player)
        {
            _context.Players2.Add(player);
            _context.SaveChanges();

            //return Ok(); //"created - ok"; 
            return CreatedAtRoute("GetPlayer", new { id = player.id }, player);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Player2 p)
        {
            var pp = _context.Players2.Find(id);
            if (pp == null)
            {
                return NotFound();
            }

            _context.Players2.Update(pp);
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
            var todo = _context.Players2.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Players2.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}




