using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiNetcore5.DAL;
using WebApiNetcore5.Model;

namespace WebApiNetcore5.Services
{
    public class TodoService : ITodosService
    {
        private readonly DataContext _dataContext;

        public TodoService(DataContext dataContext)
        {
            _dataContext  = dataContext;
        }

        public async Task CreatePostAsync(Todos todo)
        {
            await _dataContext.Todos.AddAsync(todo);
        }

        public async Task<IEnumerable<Todos>> getAllTodosAsync()
        {
            return await _dataContext.Todos.ToListAsync();
        }
    }
}
