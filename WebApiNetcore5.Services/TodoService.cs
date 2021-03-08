using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiNetcore5.Model;

namespace WebApiNetcore5.Services
{
    public class TodoService : ITodosService
    {
        public Task<IEnumerable<Todos>> getAllTodos()
        {
            throw new NotImplementedException();
        }
    }
}
