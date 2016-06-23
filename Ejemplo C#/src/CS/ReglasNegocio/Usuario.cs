using System;
using System.Collections.Generic;
using System.Text;

namespace DCE05.Ejemplos.EstrellaUno.ReglasNegocio
{

    /// <summary>
    /// Representa un producto genérico.
    /// </summary>
    public class Usuario
    {

        private int dni;
        private string nombre;
        private string apellido;

        /// <summary>
        /// Construye una instancia del producto con sus datos completos.
        /// </summary>
        /// <param name="dni">El código del producto.</param>
        /// <param name="nombre">La descripción del producto.</param>
        /// <param name="apellido">El precio del producto.</param>
        public Usuario(int dni, string nombre, string apellido)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
        }

        /// <summary>
        /// El codigo del producto.
        /// </summary>
        /// <exception cref="ArgumentException">Si el parámetro es inválido.</exception>
        public int Dni
        {
            get { return this.dni; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El dni es inválido.");
                }
                this.dni = value;
            }
        }

        /// <summary>
        /// La descripcion del producto.
        /// </summary>
        /// <exception cref="ArgumentException">Si el parámetro es inválido.</exception>
        public string Nombre
        {
            get { return nombre; }
            private set
            {
                if (value.Equals(string.Empty))
                {
                    throw new ArgumentException("El nombre es inválido.");
                }
                this.nombre = value;
            }
        }
        /// <summary>
        /// La descripcion del producto.
        /// </summary>
        /// <exception cref="ArgumentException">Si el parámetro es inválido.</exception>
        public string Apellido
        {
            get { return apellido; }
            private set
            {
                if (value.Equals(string.Empty))
                {
                    throw new ArgumentException("El apellido es inválido.");
                }
                this.apellido = value;
            }
        }

    }
}