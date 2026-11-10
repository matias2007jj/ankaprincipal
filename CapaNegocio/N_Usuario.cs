using CapaDatos;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Usuario
    {
        private readonly D_Usuario objDatos = new D_Usuario();

        public async Task<bool> ValidarLogin(string usuario, string password)
        {
            return await objDatos.AutenticarUsuario(usuario, password);
        }
    }
}