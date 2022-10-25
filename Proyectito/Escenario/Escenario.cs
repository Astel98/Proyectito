using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Proyectito
{
    class Escenario : IDibujable
    {

        public Punto centro { get; set; }
        public Punto centroAux { get; set; }
        public Punto centroLimpiar { get; set; }
        public Dictionary<string, Objeto3D> listaObjetos { get; set; }
        public Guion guioncito { get; set; }

        public Escenario()
        {
            this.centro = this.centroAux = this.centroLimpiar = new Punto();
            this.listaObjetos = new Dictionary<string, Objeto3D>();
        }

        public Escenario(Dictionary<string, Objeto3D> lista, Punto centro)
        {
            this.listaObjetos = lista;
            this.centro = centro;
            this.centroAux = centro;
            this.centroLimpiar = centro;

            foreach (var obj in listaObjetos)
            {
                Punto newCentro = this.centro + obj.Value.centro;
                obj.Value.centro = newCentro;
                obj.Value.centroLimpiar = this.centro + obj.Value.centroLimpiar;
            }
            setNuevoCentro(this.centro);
        }

        public void setNuevoCentro(Punto nuevoCentro)
        {
            this.centro = nuevoCentro;
            foreach (var obj in listaObjetos)
            {
                Punto nuevoCentroCara = nuevoCentro + obj.Value.centro;
                obj.Value.centro = nuevoCentroCara;
            }
        }

        public void Insertar(Objeto3D newObjeto, string key)
        {
            listaObjetos.Add(key, newObjeto);
        }

        public void Eliminar(string key)
        {
            listaObjetos.Remove(key);
        }

        public Objeto3D Obtener(string key)
        {
            return listaObjetos[key];
        }

        public void Dibujar()
        {

            foreach (var obj in this.listaObjetos)
            {
                obj.Value.Dibujar();
            }

        }

        public void Rotar(float x, float y, float z)
        {
            foreach (var objeto3D in listaObjetos)
            {
                objeto3D.Value.RotarE(x, y, z, centroAux);
            }
        }

        public void Escalar(float x, float y, float z)
        {
            foreach (var objeto3D in listaObjetos)
            {
                objeto3D.Value.EscalarE(x, y, z, centroAux);
            }
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (var objeto3D in listaObjetos)
            {
                objeto3D.Value.Trasladar(x, y, z);
            }
        }


        public Dictionary<string, Objeto3D> GetListaDeObjetos()
        {
            return this.listaObjetos;
        }

        public void Limpiar()
        {
            foreach (var obj in listaObjetos)
            {
                obj.Value.Limpiar();
                obj.Value.Limpiar();
            }
            this.centroAux = this.centroLimpiar;
        }

        public void toJson()
        {
            JsonBro.Serializador(this, "escenita");
        }

        public void fromJson()
        {
            JsonBro.Deserializador("ruta");
        }

    }
}
