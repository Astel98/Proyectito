using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectito
{
    public class Accion
    {
        

        TipoAc accion { set; get; }
        float ejeX { set; get; }
        float ejeY { set; get; }
        float ejeZ { set; get; }

        public Accion()
        {
            this.accion = TipoAc.NONE;
            this.ejeX = this.ejeY = this.ejeZ = 0;
        }

        public Accion(TipoAc accion, float ejeX, float ejeY, float ejeZ)
        {
            this.accion = accion;
            this.ejeX = ejeX;
            this.ejeY = ejeY;
            this.ejeZ = ejeZ;
        }
    }
}
