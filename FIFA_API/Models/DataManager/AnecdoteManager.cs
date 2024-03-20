using FIFA_API.Models.EntityFramework;
using FIFA_API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FIFA_API.Models.DataManager
{
    public class AnecdoteManager : IDataRepository<Anecdote>
    {

        private readonly FifaDbContext fifaDbContext;

        public AnecdoteManager(FifaDbContext context)
        {
            fifaDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Anecdote>>> GetAllAsync()
        {
            return await fifaDbContext.Anecdote.ToListAsync();
        }

        public async Task AddAsync(Anecdote entity)
        {
            await fifaDbContext.Anecdote.AddAsync(entity);
            await fifaDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Anecdote entity)
        {
            fifaDbContext.Anecdote.Remove(entity);
            await fifaDbContext.SaveChangesAsync();
        }


        public async Task<ActionResult<Anecdote?>> GetByIdAsync(int id)
        {
            Anecdote? anecdote = await fifaDbContext.Anecdote.FirstOrDefaultAsync(u => u.AnecdoteId == id);

            if (anecdote is null)
                return anecdote;

            return anecdote;
        }

        public async Task<ActionResult<Anecdote?>> GetByStringAsync(string str)
        {
            return await fifaDbContext.Anecdote.FirstOrDefaultAsync(u => u.AnecdoteReponse.ToUpper() == str.ToUpper());
        }

        public async Task UpdateAsync(Anecdote entityToUpdate, Anecdote entity)
        {
            fifaDbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.AnecdoteId = entity.AnecdoteId;
            entityToUpdate.JoueurId = entity.JoueurId;
            entityToUpdate.Question = entity.Question;
            entityToUpdate.AnecdoteReponse = entity.AnecdoteReponse;
            await fifaDbContext.SaveChangesAsync();
        }
    }
}
