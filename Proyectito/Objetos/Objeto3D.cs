using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectito
{
    internal class Objeto3D
    {

        public Dictionary<string, Objeto2D> listaDeCaras { get; set; }
        public Punto centro { get; set; }
        public Punto centroCopia { get; set; }
        public Punto centroLimpiar { get; set; }

        public Objeto3D()
        {
            this.centro = this.centroCopia = this.centroLimpiar = new Punto();
            this.listaDeCaras = new Dictionary<string, Objeto2D>();
        }

        public Objeto3D(Dictionary<string, Objeto2D> listaDeCaras, Punto centro)
        {
            this.listaDeCaras = listaDeCaras;
            this.centro = centro;
            centroCopia = centro;
            centroLimpiar = centro;
            foreach (var cara in listaDeCaras)
            {
                Punto newCentro = this.centro + cara.Value.centro;
                cara.Value.centro = newCentro;
                cara.Value.centroLimpiar = this.centro + cara.Value.centroLimpiar;
            }
            setNuevoCentro(this.centro);
        }

        public void setNuevoCentro(Punto nuevoCentro)
        {
            this.centro = nuevoCentro;
            foreach (var cara in listaDeCaras)
            {
                Punto nuevoCentroCara = nuevoCentro + cara.Value.centro;
                cara.Value.centro = nuevoCentroCara;
            }
        }

        public void Insertar(Objeto2D nuevaCara, string key)
        {
            listaDeCaras.Add(key, nuevaCara);
        }

        public void Eliminar(string key)
        {
            listaDeCaras.Remove(key);
        }

        public Objeto2D Obtener(string key)
        {
            return listaDeCaras[key];
        }

        public void Dibujar()
        {

            foreach (var face in this.listaDeCaras)
            {
                face.Value.Dibujar();
            }

        }
        public Dictionary<string, Objeto2D> GetListaDeCaras()
        {
            return this.listaDeCaras;
        }

        public void Limpiar()
        {
            foreach (var cara in listaDeCaras)
            {
                cara.Value.Limpiar();
            }
            this.centroCopia = this.centroLimpiar;
        }

    }
}
