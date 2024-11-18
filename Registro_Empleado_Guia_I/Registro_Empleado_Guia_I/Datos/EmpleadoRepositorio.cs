using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Empleado_Guia_I.Datos
{
    public class EmpleadoRepositorio
    {
        private const string RUTA_FICHERO_EMPLEADOS = @"C:\Users\Hp\OneDrive.Json";
        public static List<Empleado> Empleados {  get; private set; }

        public static void InicializarRepositorio()
        {
            Empleados = new List<Empleado>();
        }
        public static void AñadirEmpleado(Empleado empleado)
        {
            Empleados.Add(empleado);
            string json = JsonConvert.SerializeObject(Empleados, Formatting.Indented);
            File.WriteAllText(RUTA_FICHERO_EMPLEADOS, json);
        }
        public static void EliminarEmpleado(string id)
        {
            Empleados.RemoveAll(e => e.Id.Equals(id));
            string json = JsonConvert.SerializeObject(Empleados, Formatting.Indented);
            File.WriteAllText(RUTA_FICHERO_EMPLEADOS, json);
        }
        public static void ActualizarEmpleado(string idEmpleadoOrigen, Empleado EmpleadoModificado) 
        {
            int indiceEmpleadoOriginal = Empleados.FindIndex(e => e.Id == idEmpleadoOrigen);
            if (indiceEmpleadoOriginal != -1)
            {
                Empleados[indiceEmpleadoOriginal] = EmpleadoModificado;
            }
            string json = JsonConvert.SerializeObject(Empleados, Formatting.Indented);
            File.WriteAllText(RUTA_FICHERO_EMPLEADOS, json);
        }
    }
}
