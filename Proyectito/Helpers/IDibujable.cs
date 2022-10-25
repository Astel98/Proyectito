using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectito
{
    public interface IDibujable
    {

        void Dibujar();
        void Trasladar(float x, float y, float z);
        void Rotar(float x, float y, float z);
        void Escalar(float x, float y, float z);

    }
}
