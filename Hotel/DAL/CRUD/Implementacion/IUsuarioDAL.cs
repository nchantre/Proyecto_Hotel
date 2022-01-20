using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CRUD.Implementacion
{
    public interface IUsuarioDAL
    {
        Usuario GetAllUsuarioId(int IdUsuario);
        string AddUsuario();
        void UpUsuario();
        void DeleteUsuario(int IdUsuario);
        ICollection<Usuario> GetAllUsuario();
    }
}
