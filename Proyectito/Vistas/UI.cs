using OpenTK.Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenTK.Input;

namespace Proyectito
{
    public partial class UI : Form
    {
        private Escenario escenario;
        private float rotar;
        private float escalar;
        private float trasladar;
        private int rotarB;
        private int escalarB;
        private int trasladarB;
        private bool estaAnimado = false;
        private Thread animacion;
        public UI()
        {
            InitializeComponent();
        }

        private void glLoad(object sender, EventArgs e)
        {
            this.escenario = Creador.CrearEscena();
            this.rotar = this.escalar = this.trasladar = 0;
            this.rotarB = this.escalarB = this.trasladarB = 5;
            cargarObj();
            //this.escenario = JsonBro.Deserializador(File.ReadAllText(AbrirJson()));
            GL.ClearColor(Color4.SkyBlue);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Frustum(-10, 10, -10, 10, 5, 30);
            Matrix4 lookat = Matrix4.LookAt(-5, 5, 10, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            this.glControlador.Invalidate();
        }

        private void glDraw(object sender, PaintEventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            escenario.Dibujar();
            this.glControlador.SwapBuffers();
        }

        private void glResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, this.glControlador.Width, this.glControlador.Height);
            this.glControlador.SwapBuffers();
            this.glControlador.Invalidate();
        }

        private void cargarObj()
        {
            this.obj3D.Items.Clear();
            this.obj3D.Items.Add("ESCENARIO");
            foreach (KeyValuePair<string, Objeto3D> item in escenario.listaObjetos)
            {
                this.obj3D.Items.Add(item.Key);
            }
        }

        private void cargarCaras(Dictionary<string, Objeto2D> caras)
        {
            this.caras.Items.Clear();
            this.caras.Items.Add("OBJETO");
            foreach (KeyValuePair<string, Objeto2D> item in caras)
            {
                this.caras.Items.Add(item.Key);
            }
        }

        private void obj3DCambio(object sender, EventArgs e)
        {
            Objeto3D onFocus;
            if (this.obj3D.SelectedItem.ToString() != "ESCENARIO")
            {
                this.escenario.listaObjetos.TryGetValue(this.obj3D.SelectedItem.ToString(), out onFocus);
                try
                {
                    cargarCaras(onFocus.listaDeCaras);
                }
                catch
                {
                    Console.WriteLine("ERROR CARGANDO CARAS");
                }
            }

        }

        private void EscalarStart(object sender, EventArgs e)
        {
            calcularEscalar();
            Console.WriteLine(this.escalar);
            if (this.obj3D.SelectedItem != null)
            {
                if (this.obj3D.SelectedItem.ToString() == "ESCENARIO")
                {
                    this.escenario.Escalar(this.eX.Checked ? this.escalar : 1,
                            this.eY.Checked ? this.escalar : 1,
                            this.eZ.Checked ? this.escalar : 1);
                }
                else
                {
                    Objeto3D aux = escenario.listaObjetos[this.obj3D.SelectedItem.ToString()];
                    if (this.caras.SelectedItem.ToString() == "OBJETO")
                    {
                        aux.EscalarE(this.eX.Checked ? this.escalar : 1,
                            this.eY.Checked ? this.escalar : 1,
                            this.eZ.Checked ? this.escalar : 1,
                            this.escenario.centroAux);
                    }
                    else
                    {
                        Objeto2D aux2 = aux.listaDeCaras[this.caras.SelectedItem.ToString()];
                        aux2.EscaladoE(this.eX.Checked ? this.escalar : 1,
                            this.eY.Checked ? this.escalar : 1,
                            this.eZ.Checked ? this.escalar : 1,
                            this.escenario.centroAux);
                    }
                }
            }
            this.escalarB = this.escBar.Value;
            this.glControlador.Invalidate();
        }

        private void RotarStart(object sender, EventArgs e)
        {
            calcularRotar();
            Console.WriteLine(this.rotar);
            if (this.obj3D.SelectedItem != null)
            {
                if (this.obj3D.SelectedItem.ToString() == "ESCENARIO")
                {
                    this.escenario.Rotar(this.rX.Checked ? this.rotar : 0,
                            this.rY.Checked ? this.rotar : 0,
                            this.rZ.Checked ? this.rotar : 0);
                }
                else
                {
                    Objeto3D aux = escenario.listaObjetos[this.obj3D.SelectedItem.ToString()];
                    if (this.caras.SelectedItem.ToString() == "OBJETO")
                    {
                        aux.RotarE(this.rX.Checked ? this.rotar : 0,
                            this.rY.Checked ? this.rotar : 0,
                            this.rZ.Checked ? this.rotar : 0,
                            this.escenario.centroAux);
                    }
                    else
                    {
                        Objeto2D aux2 = aux.listaDeCaras[this.caras.SelectedItem.ToString()];
                        aux2.RotarE(this.rX.Checked ? this.rotar : 0,
                            this.rY.Checked ? this.rotar : 0,
                            this.rZ.Checked ? this.rotar : 0,
                            this.escenario.centroAux);
                    }
                }
            }
            this.rotarB = this.rotBar.Value;
            this.glControlador.Invalidate();
        }
        private void TrasladarStart(object sender, EventArgs e)
        {
            calcularTrasladar();
            Console.WriteLine(this.trasladar);
            if (this.obj3D.SelectedItem != null)
            {
                if (this.obj3D.SelectedItem.ToString() == "ESCENARIO")
                {
                    this.escenario.Trasladar(this.tX.Checked ? this.trasladar : 0,
                            this.tY.Checked ? this.trasladar : 0,
                            this.tZ.Checked ? this.trasladar : 0);
                }
                else
                {
                    Objeto3D aux = escenario.listaObjetos[this.obj3D.SelectedItem.ToString()];
                    if (this.caras.SelectedItem.ToString() == "OBJETO")
                    {
                        aux.Trasladar(this.tX.Checked ? this.trasladar : 0,
                            this.tY.Checked ? this.trasladar : 0,
                            this.tZ.Checked ? this.trasladar : 0);
                    }
                    else
                    {
                        Objeto2D aux2 = aux.listaDeCaras[this.caras.SelectedItem.ToString()];
                        aux2.Trasladar(this.tX.Checked ? this.trasladar : 0,
                            this.tY.Checked ? this.trasladar : 0,
                            this.tZ.Checked ? this.trasladar : 0);
                    }
                }
            }
            this.trasladarB = this.traBar.Value;
            this.glControlador.Invalidate();
        }
        private void calcularEscalar()
        {
            if (this.escBar.Value == this.escalarB)
            {
                this.escalar = 1f;
                return;
            }

            if (this.escBar.Value - this.escalarB < 0)
            {
                this.escalar = (float)1f / (1f + ((float)(this.escalarB - this.escBar.Value) / 10));
                return;
            }
            this.escalar = (float)(1f + ((float)(this.escBar.Value - this.escalarB) / 10));

        }
        private void calcularRotar()
        {
            if (this.rotBar.Value == this.rotarB)
            {
                this.rotar = 0f;
                return;
            }
            this.rotar = (float)(this.rotBar.Value - this.rotarB);
        }


        private void calcularTrasladar()
        {
            if (this.traBar.Value == this.trasladarB)
            {
                this.trasladar = 0f;
                return;
            }
            this.trasladar = (float)(this.traBar.Value - this.trasladarB);

        }

        private void bTransf_Click(object sender, EventArgs e)
        {
            this.escenario = Creador.CrearEscena();
            this.estaAnimado = false;
            cargarObj();
            this.glControlador.Invalidate();
        }

        private void bAnim_Click(object sender, EventArgs e)
        {
            this.estaAnimado = true;
            removeObjetos();
            initAnimar();
            cargarObj();
        }

        private void removeObjetos()
        {
            this.escenario.listaObjetos = new Dictionary<string, Objeto3D>
            {
                {"auto", autito() }
            };
            this.glControlador.Invalidate();
        }

        private Objeto3D autito()
        {
            return Creador.CrearAuto();
        }

        private void initAnimar()
        {
            Guion guioncillo = Creador.CrearGuion();

            animacion = new Thread(() =>
            {
                try
                {
                    int aux = 0;
                    foreach (KeyValuePair<string, Accion> item in guioncillo.listaAcciones)
                    {
                        switch (item.Value.accion)
                        {
                            case TipoAc.ESCALAR:
                                this.escenario.listaObjetos["auto"].EscalarE(item.Value.ejeX, item.Value.ejeY, item.Value.ejeZ, this.escenario.centroAux);
                                break;
                            case TipoAc.ROTAR:
                                this.escenario.listaObjetos["auto"].RotarE(item.Value.ejeX, item.Value.ejeY, item.Value.ejeZ, this.escenario.centroAux);
                                break;
                            case TipoAc.TRASLADAR:
                                this.escenario.listaObjetos["auto"].Trasladar(item.Value.ejeX, item.Value.ejeY, item.Value.ejeZ);
                                break;
                            case TipoAc.NONE:
                                break;
                        }
                        aux++;
                        this.glControlador.Invalidate();
                        if (aux % 2 == 0) Thread.Sleep(500);

                    }
                    this.estaAnimado = false;
                    this.animacion.Abort();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            animacion.Start();
        }

    }
}
