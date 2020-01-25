/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB0APIMovie.Models
{
    public class Lista
    {
        public class Nodo
        {
            public string Nombre { get; set; }
            public string Anio { get; set; }
            public string Director { get; set; }

            public Nodo siguiente;
            public Nodo anterior;
            public Nodo(string nombre, string anio, string director)
            {
                Nombre = nombre;
                Anio = anio;
                Director = director;

                siguiente = null;
                anterior = null;
            }
        }

        public Nodo primero = null;
        public Nodo ultimo = null;
        public void Insertar(string nombre, string anio, string director )
        {
            Nodo nuevo = new Nodo(nombre, anio, director);

            if (primero == null)
            {
                primero = nuevo;
                ultimo = primero;
            }
            else
            {
                nuevo.anterior = ultimo;
                ultimo.siguiente = nuevo;
                ultimo = nuevo;
            }

        }

        public Nodo Valores()
        {
            int contador = 0;
            Nodo scanner = ultimo;
            while (contador!=2)
            {
                return 
            }
        }

    }
}*/
