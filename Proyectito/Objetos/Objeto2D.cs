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
    internal class Objeto2D :IDibujable
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

        public Matrix3 matrizRotacion = Matrix3.Identity;
        public Matrix3 matrizEscalado = Matrix3.Identity;

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
                Punto vectorADibujar = (vertice.Value + centroTransformar) * matrizRotacion * matrizEscalado;
                vectorADibujar -= (centroTransformar * matrizRotacion * matrizEscalado);
                vertice.Value.x = vectorADibujar.x;
                vertice.Value.y = vectorADibujar.y;
                vertice.Value.z = vectorADibujar.z;
                vectorADibujar += traslacion + centro;
                GL.Vertex3(vectorADibujar.x, vectorADibujar.y, vectorADibujar.z);
            }
            GL.End();
            this.centroTransformar = new Punto(0, 0, 0);
            matrizRotacion = Matrix3.Identity;
            matrizEscalado = Matrix3.Identity;
        }

        public void Rotar(float anguloX, float anguloY, float anguloZ)
        {

            anguloX = MathHelper.DegreesToRadians(anguloX);
            anguloY = MathHelper.DegreesToRadians(anguloY);
            anguloZ = MathHelper.DegreesToRadians(anguloZ);
            matrizRotacion = Matrix3.CreateRotationX(anguloX) * Matrix3.CreateRotationY(anguloY) * Matrix3.CreateRotationZ(anguloZ);
        }

        public void RotarE(float anguloX, float anguloY, float anguloZ, Punto centro)
        {
            Rotar(anguloX, anguloY, anguloZ);
            this.centroTransformar = centro + this.centroCaraCopia;
            this.centro = this.centro - centroTransformar;
            this.centroCaraCopia = (centroCaraCopia + centro) * matrizRotacion;
            this.centroCaraCopia = centroCaraCopia - centro * matrizRotacion;
            this.centro = this.centro + centroCaraCopia + centro * matrizRotacion;
        }

        public void EscaladoE(float x, float y, float z, Punto centro)
        {
            matrizEscalado = Matrix3.CreateScale(x, y, z);
            this.centro = this.centro - centroCaraCopia - centro;
            this.centroTransformar = centroCaraCopia + centro;
            centroCaraCopia = ((centroCaraCopia + centro) * matrizEscalado) - (centro * matrizEscalado);
            this.centro = this.centro + centroCaraCopia + (centro * matrizEscalado);
        }

        public void Trasladar(float x, float y, float z)
        {
            traslacion += new Punto(x, y, z);
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

        public void Escalar(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
    }
}
