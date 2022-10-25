using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectito
{
    public class Guion
    {

        Dictionary<string, Accion> listaAcciones { get; set; }

        public Guion()
        {
            this.listaAcciones = new Dictionary<string, Accion>();
        }

        public void AddAccion(TipoAc accion, float x, float y, float z)
        {
            this.listaAcciones.Add(accion.ToString() + this.listaAcciones.Count + 1, new Accion(accion, x, y, z));
        }

        public void RemoveAccion(string key)
        {
            this.listaAcciones.Remove(key);
        }


    }
}
