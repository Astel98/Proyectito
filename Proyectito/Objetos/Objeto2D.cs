using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Proyectito
{
    internal class Objeto2D
    {

        public Dictionary<string, Punto> listaDeVertices { get; set; }
        public Dictionary<string, Punto> listaDeVerticesCopia { get; set; }
        public Color color { get; set; }
        public Punto centro { get; set; }
        public Punto traslacion { get; set; } = new Punto(0, 0, 0);
        public Punto centroCaraCopia { get; set; }
        public Punto centroTransformar { get; set; }
        public Punto centroLimpiar { get; set; }
        public Punto centroLimpiar2 { get; set; }

        public Objeto2D()
        {
            this.centro = this.centroCaraCopia = this.centroLimpiar = this.centroLimpiar2 = this.centroTransformar = new Punto();
            this.listaDeVertices = new Dictionary<string, Punto>();
            this.listaDeVerticesCopia = new Dictionary<string, Punto>();
            this.color = Color.Black;

        }

        public Objeto2D(Dictionary<string, Punto> listaDeVertices, Color color, Punto centro)
        {
            this.listaDeVertices = listaDeVertices;
            listaDeVerticesCopia = new Dictionary<string, Punto>();
            foreach (var vertice in listaDeVertices)
            {
                listaDeVerticesCopia.Add(vertice.Key, new Punto(vertice.Value.x, vertice.Value.y, vertice.Value.z));
            }
            this.color = color;
            this.centro = centro;
            centroCaraCopia = centro;
            centroLimpiar = centro;
            centroLimpiar2 = centro;
            centroTransformar = new Punto(0, 0, 0);
        }

        public void Insertar(Punto nuevoVertice, string key)
        {
            listaDeVertices.Add(key, nuevoVertice);
        }

        public void Eliminar(string key)
        {
            listaDeVertices.Remove(key);
        }

        public Punto Obtener(string key)
        {
            return listaDeVertices[key];
        }

        public void Dibujar()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);
            foreach (var vertice in listaDeVertices)
            {
                Punto vectorADibujar = (vertice.Value + centroTransformar);
                vectorADibujar -= centroTransformar;
                vertice.Value.x = vectorADibujar.x;
                vertice.Value.y = vectorADibujar.y;
                vertice.Value.z = vectorADibujar.z;
                vectorADibujar += traslacion + centro;
                GL.Vertex3(vectorADibujar.x, vectorADibujar.y, vectorADibujar.z);
            }
            GL.End();
            this.centroTransformar = new Punto(0, 0, 0);
        }

        public void Limpiar()
        {
            listaDeVertices = new Dictionary<string, Punto>();
            foreach (var vertice in listaDeVerticesCopia)
            {
                listaDeVertices.Add(vertice.Key.ToString(), new Punto(vertice.Value.x, vertice.Value.y, vertice.Value.z));
            }
            centroCaraCopia = centroLimpiar2;
            centro = centroLimpiar;
            traslacion = new Punto(0, 0, 0);
        }

    }
}
