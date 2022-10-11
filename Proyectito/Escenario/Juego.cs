//Import sistema
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Imports proyecto

//Imports externos
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.IO;

namespace Proyectito
{
    class Juego : GameWindow
    {

        public Escenario escenario;

        //Constructores
        public Juego() { }

        public Juego(int width, int height, string title) :
            base(width, height, GraphicsMode.Default, title)
        {
        }

        //Funciones GameOn
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //CrearEscena();
            this.escenario = JsonBro.Deserializador(File.ReadAllText(AbrirJson()));
            GL.ClearColor(Color4.SkyBlue);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Frustum(-10, 10, -10, 10, 5, 30);
            Matrix4 lookat = Matrix4.LookAt(-5, 5, 10, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            escenario.Dibujar();
            SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }


        //Funciones personalizadas
        protected string AbrirJson()
        {
            string file = "NA";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Selecciona JSON";
            openDialog.Filter = "Text Files (*.json)|*.json";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                file = openDialog.FileName;
            }

            return file;
        }

        protected void CrearEscena()
        {
            Dictionary<string, Objeto3D> listaObjetos = new Dictionary<string, Objeto3D>
            {
                {"cubo", CrearCubo() },
                {"piramide", CrearTecho()},
                {"mesa", CrearMesa() },
                {"auto", CrearAuto() }
            };

            this.escenario = new Escenario(listaObjetos, new Punto());


            this.escenario.toJson();
        }

        protected Objeto3D CrearCubo()
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

        protected Objeto3D CrearTecho()
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

        protected Objeto3D CrearMesa()
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

        protected Objeto3D CrearAuto()
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


        //Casita
        protected Objeto2D CaraIzquierda()
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

        protected Objeto2D CaraDerecha()
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

        protected Objeto2D CaraFrontal()
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

        protected Objeto2D CaraTrasera()
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

        protected Objeto2D CaraSuperior()
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

        protected Objeto2D CaraInferior()
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

        protected Objeto2D BaseTecho()
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

        protected Objeto2D TechoFrente()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(1.5f, -0.25f, 0.75f) },
                { "I", new Punto(-1.5f, -0.25f, 0.75f) },
                { "S", new Punto(0f, 0.5f, -0.75f) }
            };

            return new Objeto2D(vertices, Color.Yellow, new Punto(0f, 1.25f, 0.75f));
        }

        protected Objeto2D TechoDetras()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(1.5f, -0.25f, -0.75f) },
                { "I", new Punto(-1.5f, -0.25f, -0.75f) },
                { "S", new Punto(0f, 0.5f, 0.75f) }
            };

            return new Objeto2D(vertices, Color.Red, new Punto(0f, 1.25f, -0.75f));
        }

        protected Objeto2D TechoDerecha()
        {
            Dictionary<string, Punto> vertices = new Dictionary<string, Punto>
            {
                { "D", new Punto(0.75f, -0.25f, 1.5f) },
                { "I", new Punto(0.75f, -0.25f, -1.5f) },
                { "S", new Punto(-0.75f, 0.5f, 0f) }
            };

            return new Objeto2D(vertices, Color.Yellow, new Punto(0.75f, 1.25f, 0f));
        }

        protected Objeto2D TechoIzquierda()
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
        protected Objeto2D MesaBase()
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

        protected Objeto2D MesaP1()
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

        protected Objeto2D MesaP2()
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

        protected Objeto2D MesaP3()
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

        protected Objeto2D MesaP4()
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
        protected Objeto2D AutoBase()
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

        protected Objeto2D AutoBase2()
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


        protected Objeto2D AutoR1()
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

        protected Objeto2D AutoR2()
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

        protected Objeto2D AutoR3()
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

        protected Objeto2D AutoR4()
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
