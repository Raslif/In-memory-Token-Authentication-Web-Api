using System.Threading.Tasks;

namespace CutomTokenAuth.Models
{
    public interface ICustomer
    {
        Task<string> GetName();
    }
}
