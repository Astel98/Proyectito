using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectito
{
    class Punto
    {

        //atributos
        private float ejeX { get; set; }
        private float ejeY { get; set; }
        private float ejeZ { get; set; }


        //Setter y Getter
        public float x { get { return ejeX; } set { ejeX = value; } }
        public float y { get { return ejeY; } set { ejeY = value; } }
        public float z { get { return ejeZ; } set { ejeZ = value; } }


        //contructores
        public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }
        public Punto() : this(0, 0, 0) { }
        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }
        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }

        //Punto a Vector
        public Vector3 ToVector3()
        {
            return new Vector3(this.ejeX, this.ejeY, this.ejeZ);
        }

        //Operaciones vectoriales
        public void acumular(Punto p)
        {
            this.ejeX += p.x;
            this.ejeY += p.y;
            this.ejeZ += p.z;
        }
        public void acumular(float x, float y, float z)
        {
            this.ejeX += x;
            this.ejeY += y;
            this.ejeZ += z;
        }
        public void multiplicar(float x, float y, float z)
        {
            this.ejeX *= x;
            this.ejeY *= y;
            this.ejeZ *= z;
        }
        public void setPunto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }

        //Operadores
        public static Punto operator +(Punto a, Punto b) => new Punto(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Punto operator -(Punto a, Punto b) => new Punto(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Punto operator -(Punto a) => new Punto(-a.x, -a.y, -a.z);
        public static Punto operator *(Punto a, Punto b) => new Punto(a.x * b.x, a.y * b.y, a.z * b.z);

        public static Punto operator *(Punto a, Matrix3 b) => new Punto(
            a.x * b.M11 + a.y * b.M12 + a.z * b.M13,
            a.x * b.M21 + a.y * b.M22 + a.z * b.M23,
            a.x * b.M31 + a.y * b.M32 + a.z * b.M33);

        //Funciones Auxiliares
        public bool compareTo(Punto a)
        {
            return (this.ejeX == a.ejeX && this.ejeY == a.ejeY && this.ejeZ == a.ejeZ);
        }
        public override string ToString() => $"({ejeX}|{ejeY}|{ejeZ})";

    }
}
