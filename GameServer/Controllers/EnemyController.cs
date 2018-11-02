

using System.Collections.Generic;
using System.Linq;
using GameServer.EnemyBuilder;
using GameServer.EnemyFactory;
using GameServer.Models;
using Microsoft.AspNetCore.Mvc;
/**
* @(#) EnemyController.cs
*/
namespace GameServer.Controllers
{
    [Route("api/enemy")]
    [ApiController]
    public class EnemyController : ControllerBase
    {


        IEnemyCreator enemyCreator;
        private readonly EnemyContext context;

        public EnemyController(EnemyContext context)
        {
            this.context = context;
            //this.enemyCreator = new EnemyCreatorAdapter(new EnemyPartyDirector(new GrassEnvironmentFactory()));
            //createEnemies();
        }

        public List<EnemyParty> createEnemies()
        {
            List<EnemyParty> enemies = new List<EnemyParty>();
            /*enemies.Add(enemyCreator.GetEnemyParty(0, new Coordinates(0, 0)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(4, 4)));
            foreach (EnemyParty p in enemies)
            {
                context.enemyParties.Add(EnemyConverter.createEnemyPartyJson(p));
            }*/
            return enemies;
        }
        // GET api/enemy
        [HttpGet]
        public ActionResult<IEnumerable<EnemyPartyJson>> getEnemyParties()
        {
            return context.enemyParties.ToList();
        }
		
	}
	
}
