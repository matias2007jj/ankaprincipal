using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaEntidad;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Extintores
    {
        private D_Extintores objDato = new D_Extintores();

        public async Task<List<E_Extintor>> ListarExtintores()
        {
            return await objDato.ObtenerExtintores();
        }
    }
}
