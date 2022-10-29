using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectito
{
    static class Creador
    {
        //COSAS DE ESCENARIO
        public static Escenario CrearEscena()
        {
            Dictionary<string, Objeto3D> listaObjetos = new Dictionary<string, Objeto3D>
            {
                {"cubo", CrearCubo() },
                {"piramide", CrearTecho()},
                {"mesa", CrearMesa() },
                {"auto", CrearAuto() }
            };

            return new Escenario(listaObjetos, new Punto());
        }

        public static Objeto3D CrearCubo()
        {
            Dictionary<string, Objeto2D> listaObj = new Dictionary<string, Objeto2D>
            {
                { "frontal", CaraFrontal() },
                { "trasera", CaraTrasera() },
                { "derecha", CaraDerecha() },
                { "izquierda", CaraIzquierda() },
                { "superior", CaraSuperior() },
                { "inferior", CaraInferior() }
            };

            return new Objeto3D(listaObj, new Punto());
        }

        public static Objeto3D CrearTecho()
        {
            Dictionary<string, Objeto2D> listaObj = new Dictionary<string, Objeto2D>
            {
                { "frontal", TechoFrente() },
                { "trasera", TechoDetras() },
                { "derecha", TechoDerecha() },
                { "izquierda", TechoIzquierda() }
            };

            return new Objeto3D(listaObj, new Punto());
        }

        public static Objeto3D CrearMesa()
        {
            Dictionary<string, Objeto2D> listaObj = new Dictionary<string, Objeto2D>
            {
                { "base", MesaBase() },
                { "pata1", MesaP1() },
                { "pata2", MesaP2() },
                { "pata3", MesaP3 () },
                { "pata4", MesaP4() }
            };

            return new Objeto3D(listaObj, new Punto());
        }

        public static Objeto3D CrearAuto()
        {
            Dictionary<string, Objeto2D> listaObj = new Dictionary<string, Objeto2D>
            {
                { "base", AutoBase() },
                { "base2", AutoBase2() },
                { "rueda1", AutoR1() },
                { "rueda2", AutoR2() },
                { "rueda3", AutoR3 () },
                { "rueda4", AutoR4() }
            };

            return new Objeto3D(listaObj, new Punto());
        }

        public static Guion CrearGuion()
        {
            Dictionary<string, Accion> acciones = new Dictionary<string, Accion>
            {
                {"001", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"002", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"003", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"004", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"005", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"006", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"007", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"008", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"009", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"010", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"011", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"012", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"013", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"014", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"015", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"016", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"017", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"018", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) },
                {"019", new Accion(TipoAc.ESCALAR, (float)(1/1.1),(float)(1/1.1),(float)(1/1.1)) },
                {"020", new Accion(TipoAc.TRASLADAR, 0.5f, 0f, 0f) }
            };
            return new Guion(acciones);
        }


        //Casita
        private static Objeto2D CaraIzquierda()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(0f, 1.0f, -1.0f) },
                { "DI", new Punto(0f, -1.0f, -1.0f) },
                { "DS", new Punto(0f, -1.0f, 1.0f) },
                { "IS", new Punto(0f, 1.0f, 1.0f) }
            };

            return new Objeto2D(vertices, Color.Black, new Punto(-1f, 0f, 0f));
        }

        private static Objeto2D CaraDerecha()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0f, 1.0f, -1.0f) },
                { "II", new Punto(0f, -1.0f, -1.0f) },
                { "IS", new Punto(0f, -1.0f, 1.0f) },
                { "DS", new Punto(0f, 1.0f, 1.0f) }
            };

            return new Objeto2D(vertices, Color.Black, new Punto(1f, 0f, 0f));
        }

        private static Objeto2D CaraFrontal()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(-1.0f, 0f, -1.0f) },
                { "DI", new Punto(1.0f, 0f, -1.0f) },
                { "DS", new Punto(1.0f, 0f, 1.0f) },
                { "IS", new Punto(-1.0f, 0f, 1.0f) }
            };

            return new Objeto2D(vertices, Color.Green, new Punto(0f, 1f, 0f));
        }

        private static Objeto2D CaraTrasera()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(1.0f, 0f, -1.0f) },
                { "DI", new Punto(-1.0f, 0f, -1.0f) },
                { "DS", new Punto(-1.0f, 0f, 1.0f) },
                { "IS", new Punto(1.0f, 0f, 1.0f) }
            };

            return new Objeto2D(vertices, Color.Black, new Punto(0f, -1f, 0f));
        }

        private static Objeto2D CaraSuperior()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(-1.0f, 1.0f, 0f) },
                { "DI", new Punto(1.0f, 1.0f, 0f) },
                { "DS", new Punto(1.0f, -1.0f, 0f) },
                { "IS", new Punto(-1.0f, -1.0f, 0f) }
            };

            return new Objeto2D(vertices, Color.Blue, new Punto(0f, 0f, 1f));
        }

        private static Objeto2D CaraInferior()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(-1.0f, 1.0f, 0f) },
                { "DI", new Punto(1.0f, 1.0f, 0f) },
                { "DS", new Punto(1.0f, -1.0f, 0f) },
                { "IS", new Punto(-1.0f, -1.0f, 0f) }
            };

            return new Objeto2D(vertices, Color.Black, new Punto(0f, 0f, -1f));
        }

        private static Objeto2D BaseTecho()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(-1.5f, 0f, 1.5f) },
                { "DI", new Punto(1.5f, 0f, 1.5f) },
                { "DS", new Punto(1.5f, 0f, -1.5f) },
                { "IS", new Punto(-1.5f, 0f, -1.5f) }
            };

            return new Objeto2D(vertices, Color.Red, new Punto(0f, 1f, 0f));
        }

        private static Objeto2D TechoFrente()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(1.5f, -0.25f, 0.75f) },
                { "I", new Punto(-1.5f, -0.25f, 0.75f) },
                { "S", new Punto(0f, 0.5f, -0.75f) }
            };

            return new Objeto2D(vertices, Color.Yellow, new Punto(0f, 1.25f, 0.75f));
        }

        private static Objeto2D TechoDetras()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(1.5f, -0.25f, -0.75f) },
                { "I", new Punto(-1.5f, -0.25f, -0.75f) },
                { "S", new Punto(0f, 0.5f, 0.75f) }
            };

            return new Objeto2D(vertices, Color.Red, new Punto(0f, 1.25f, -0.75f));
        }

        private static Objeto2D TechoDerecha()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(0.75f, -0.25f, 1.5f) },
                { "I", new Punto(0.75f, -0.25f, -1.5f) },
                { "S", new Punto(-0.75f, 0.5f, 0f) }
            };

            return new Objeto2D(vertices, Color.Yellow, new Punto(0.75f, 1.25f, 0f));
        }

        private static Objeto2D TechoIzquierda()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(-0.75f, -0.25f, 1.5f) },
                { "I", new Punto(-0.75f, -0.25f, -1.5f) },
                { "S", new Punto(0.75f, 0.5f, 0f) }
            };

            return new Objeto2D(vertices, Color.Red, new Punto(-0.75f, 1.25f, 0f));
        }


        //MESITA
        private static Objeto2D MesaBase()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "II", new Punto(2f, 0f, -1.0f) },
                { "DI", new Punto(-2f, 0f, -1.0f) },
                { "DS", new Punto(-2f, 0f, 1.0f) },
                { "IS", new Punto(2f, 0f, 1.0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(5f, 0f, 0f));
        }

        private static Objeto2D MesaP1()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0f, 0f, 0f) },
                { "II", new Punto(0.5f, 0f, 0f) },
                { "IS", new Punto(0.5f, -1.0f, 0f) },
                { "DS", new Punto(0f, -1.0f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(3f, 0f, 1f));
        }

        private static Objeto2D MesaP2()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0f, 0f, 0f) },
                { "II", new Punto(0.5f, 0f, 0f) },
                { "IS", new Punto(0.5f, -1.0f, 0f) },
                { "DS", new Punto(0f, -1.0f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(6.5f, 0f, 1f));
        }

        private static Objeto2D MesaP3()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0f, 0f, 0f) },
                { "II", new Punto(0.5f, 0f, 0f) },
                { "IS", new Punto(0.5f, -1.0f, 0f) },
                { "DS", new Punto(0f, -1.0f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(3f, 0f, -1f));
        }

        private static Objeto2D MesaP4()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0f, 0f, 0f) },
                { "II", new Punto(0.5f, 0f, 0f) },
                { "IS", new Punto(0.5f, -1.0f, 0f) },
                { "DS", new Punto(0f, -1.0f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(6.5f, 0f, -1f));
        }

        //AUTITO
        private static Objeto2D AutoBase()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "V1", new Punto(-1f, 0f, 0f) },
                { "V2", new Punto(-2f, 0f, 0f) },
                { "V3", new Punto(-2f, 0.5f, 0f) },
                { "V4", new Punto(-1f, 0.5f, 0f) },
                { "V5", new Punto(-1f, 1f, 0f) },
                { "V6", new Punto(1f, 1f, 0f) },
                { "V7", new Punto(1.5f, 0.5f, 0f) },
                { "V8", new Punto(2f, 0.5f, 0f) },
                { "V9", new Punto(2f, 0f, 0f) },
                { "V10", new Punto(1f, 0f, 0f) },
                { "V11", new Punto(1f, 0.1f, 0f) },
                { "V12", new Punto(0.5f, 0.1f, 0f) },
                { "V13", new Punto(0.5f, 0f, 0f) },
                { "V14", new Punto(-0.5f, 0f, 0f) },
                { "V15", new Punto(-0.5f, 0.1f, 0f) },
                { "V16", new Punto(-1f, 0.1f, 0f) }
            };

            return new Objeto2D(vertices, Color.Pink, new Punto(-5f, 0f, 1f));
        }

        private static Objeto2D AutoBase2()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "V1", new Punto(-1f, 0f, 0f) },
                { "V2", new Punto(-2f, 0f, 0f) },
                { "V3", new Punto(-2f, 0.5f, 0f) },
                { "V4", new Punto(-1f, 0.5f, 0f) },
                { "V5", new Punto(-1f, 1f, 0f) },
                { "V6", new Punto(1f, 1f, 0f) },
                { "V7", new Punto(1.5f, 0.5f, 0f) },
                { "V8", new Punto(2f, 0.5f, 0f) },
                { "V9", new Punto(2f, 0f, 0f) },
                { "V10", new Punto(1f, 0f, 0f) },
                { "V11", new Punto(1f, 0.1f, 0f) },
                { "V12", new Punto(0.5f, 0.1f, 0f) },
                { "V13", new Punto(0.5f, 0f, 0f) },
                { "V14", new Punto(-0.5f, 0f, 0f) },
                { "V15", new Punto(-0.5f, 0.1f, 0f) },
                { "V16", new Punto(-1f, 0.1f, 0f) }
            };

            return new Objeto2D(vertices, Color.Pink, new Punto(-5f, 0f, 0.7f));
        }


        private static Objeto2D AutoR1()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0.2f, 0.2f, 0f ) },
                { "II", new Punto(0.2f, -0.2f, 0f) },
                { "IS", new Punto(-0.2f,-0.2f, 0f) },
                { "DS", new Punto(-0.2f,0.2f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(-5.75f, 0f, 1f));
        }

        private static Objeto2D AutoR2()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0.2f, 0.2f, 0f ) },
                { "II", new Punto(0.2f, -0.2f, 0f) },
                { "IS", new Punto(-0.2f,-0.2f, 0f) },
                { "DS", new Punto(-0.2f,0.2f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(-4.25f, 0f, 1f));
        }

        private static Objeto2D AutoR3()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0.2f, 0.2f, 0f ) },
                { "II", new Punto(0.2f, -0.2f, 0f) },
                { "IS", new Punto(-0.2f,-0.2f, 0f) },
                { "DS", new Punto(-0.2f,0.2f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(-5.75f, 0f, 0.7f));
        }

        private static Objeto2D AutoR4()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "DI", new Punto(0.2f, 0.2f, 0f ) },
                { "II", new Punto(0.2f, -0.2f, 0f) },
                { "IS", new Punto(-0.2f,-0.2f, 0f) },
                { "DS", new Punto(-0.2f,0.2f, 0f) }
            };

            return new Objeto2D(vertices, Color.Brown, new Punto(-4.25f, 0f, 0.7f));
        }
    }
}
