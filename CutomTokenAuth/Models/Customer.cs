using System.Threading.Tasks;

namespace CutomTokenAuth.Models
{
    public class Customer : ICustomer
    {
        public async Task<string> GetName()
        {
            return await Task.FromResult("Get Customer Name");
        }
    }
}