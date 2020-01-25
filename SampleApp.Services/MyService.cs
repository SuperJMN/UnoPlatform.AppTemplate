using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public class MyService : IMyService
    {
        public Task<List<Item>> GetItems() => Task.FromResult(Enumerable.Range(1, 50).Select(x => new Item(x.ToString())).ToList());
    }
}
