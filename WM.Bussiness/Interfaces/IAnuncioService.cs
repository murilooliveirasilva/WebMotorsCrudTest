using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Bussiness.Models;

namespace WM.Bussiness.Interfaces
{
    public interface IAnuncioService : IDisposable
    {
        Task<List<MakeModel>> callMakeAPI();
        Task<List<ModelModel>> callModelAPI(int id);
        Task<List<VersionModel>> callVersionAPI(int id);
    }
}
