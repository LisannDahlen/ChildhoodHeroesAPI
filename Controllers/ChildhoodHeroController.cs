using ChildhoodHeroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChildhoodHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildhoodHeroController : ControllerBase
    {

        private readonly ChildhoodHeroService childhoodHeroService;
        public ChildhoodHeroController(ChildhoodHeroService superHeroService)
        {
            childhoodHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChildhoodHero>>> GetAllHeros()
        {
            var heroes = await childhoodHeroService.ChildhoodHeroesToListAsync();

            return Ok(heroes);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChildhoodHero>> GetHero(int id)
        {
            var hero = await childhoodHeroService.ChildhoodHeroFindAsync(id);
            if (hero == null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(hero);

        }

        [HttpPost]
        public async Task<ActionResult<List<ChildhoodHero>>> AddHero(ChildhoodHero hero)
        {
            if (hero == null)
            {
                return BadRequest("Invalid hero data.");
            }

            var updatedList = await childhoodHeroService.ChildhoodHeroesAdd(hero);

            return Ok(updatedList);

        }
        [HttpPut]
        public async Task<ActionResult<List<ChildhoodHero>>> UpdateHero(ChildhoodHero updatedHero)
        {

            await childhoodHeroService.UpdateHeroList(updatedHero);
            var heroes = await childhoodHeroService.ChildhoodHeroesToListAsync();
            return Ok(heroes);
        }

        [HttpDelete]
        public async Task<ActionResult<List<ChildhoodHero>>> DeleteHero(int id)
        {
            await childhoodHeroService.SuperHeroesDeleteHero(id);

            return Ok(await childhoodHeroService.ChildhoodHeroesToListAsync());

        }
    }
}
