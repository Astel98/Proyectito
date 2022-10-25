//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using OpenTK;
using System.IO;

namespace Proyectito
{
    static class JsonBro
    {

        public static Boolean EscenaToJson(Escenario escena, string nombre)
        {


            return true;
        }

        public static Boolean Serializador(Escenario escenita, string nombreArchivo)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(escenita, Formatting.Indented, new JsonSerializerSettings()
                {
                    //ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }); 
                Console.WriteLine(jsonString);
                File.WriteAllText(nombreArchivo + ".json", jsonString);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static Escenario Deserializador(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<Escenario>(jsonString);
            }
            catch
            {
                return new Escenario();
            }
        }


    }
}
