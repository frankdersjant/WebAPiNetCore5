using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiNetcore5.Model;

namespace WebApiNetcore5.Services
{
    public interface ITodosService
    {
        Task<IEnumerable<Todos>> getAllTodosAsync();
        Task CreatePostAsync(Todos todo);
    }
}
