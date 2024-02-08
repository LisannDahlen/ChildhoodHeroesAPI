using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChildhoodHeroAPI.Models
{
    public class ChildhoodHeroService
    {
        private readonly DataContext context;

        public ChildhoodHeroService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<ChildhoodHero>> ChildhoodHeroesToListAsync()
        {
            return await context.ChildhoodHeroes.ToListAsync();
        }

        public async Task<ChildhoodHero?> ChildhoodHeroFindAsync(int id)
        {
            return await context.ChildhoodHeroes.FindAsync(id);
        }

        internal async Task<List<ChildhoodHero>> ChildhoodHeroesAdd(ChildhoodHero hero)
        {
            context.ChildhoodHeroes.Add(hero);
            await context.SaveChangesAsync();
            return await context.ChildhoodHeroes.ToListAsync();
        }

        internal async Task UpdateHeroList(ChildhoodHero updatedHero)
        {

            var dbHero = await context.ChildhoodHeroes.FindAsync(updatedHero.Id);

            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.Place = updatedHero.Place;

            await context.SaveChangesAsync();
        }

        internal async Task DeleteChildhoodHero(int id)
        {
            var dbHero = await context.ChildhoodHeroes.FindAsync(id);

            if (dbHero is null)
            {
                return;
            }


            context.ChildhoodHeroes.Remove(dbHero);
            await context.SaveChangesAsync();

        }
    }
}
