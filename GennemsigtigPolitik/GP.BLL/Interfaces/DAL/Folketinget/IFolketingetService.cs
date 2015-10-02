using System.Collections.Generic;
using System.Threading.Tasks;
using GP.BLL.Model.Folketinget;

namespace GP.BLL.Interfaces.DAL.Folketinget
{
    public interface IFolketingetService
    {
        Task<IEnumerable<Actor>> GetActors();
    }
}