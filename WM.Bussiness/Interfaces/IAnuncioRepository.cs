using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Bussiness.Models;

namespace WM.Bussiness.Interfaces
{
    public interface IAnuncioRepository : IRepository<AnuncioModel>
    {
        List<AnuncioModel> getAnuncios();
        int Add(AnuncioModel anuncioModel);
        AnuncioModel Findby(int id);
        int Update(AnuncioModel anuncioModel);
        int Delete(AnuncioModel anuncio);
        void Dispose();
    }
}
