using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Proyectito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread((ThreadStart)(() => {
                //using (var juego = new Juego(700, 600, ":D"))
                //{
                //    juego.Run();
                //}

                UI juegazo = new UI();
                juegazo.ShowDialog();
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            
        }
    }
}
