using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Empleado_Guia_I.Datos
{
    public class Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Apellido2 { get; private set; }
        public double Edad {  get; private set; }
        public string Email {  get; private set; }
        public Empleado(string id, string nombre, string apellido, string apellido2, double edad, string email) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Apellido2 = apellido2;
            this.Edad = edad;
            this.Email = email;
        }
    }
}
