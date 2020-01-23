using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class MyService : IMyService
    {
        public Task<List<Item>> GetItems() => Task.FromResult(Enumerable.Range(1, 200).Select(x => new Item(x.ToString())).ToList());
    }
}
