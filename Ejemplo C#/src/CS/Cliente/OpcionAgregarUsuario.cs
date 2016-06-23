using System;
using System.Collections.Generic;
using System.Text;
using DCE05.Ejemplos.EstrellaUno.ReglasNegocio;

namespace DCE05.Ejemplos.EstrellaUno.Cliente
{

    /// <summary>
    /// Representa la opción de agregar un ítem de venta a una venta iniciada.
    /// </summary>
    internal class OpcionAgregarUsuario : Opcion
    {

        /// <summary>
        /// Construye una instancia de la opción con sus datos básicos.
        /// </summary>
        /// <param name="codigo">El código de la opción.</param>
        internal OpcionAgregarUsuario(int codigo)
        {
            Codigo = codigo;
            Descripcion = "Agregar un usuario";
        }

        /// <summary>
        /// Construye una instancia de la opción vacía.
        /// </summary>
        internal OpcionAgregarUsuario() : this(0) {
        }


        /// <summary>
        /// Ejecuta la acción asociada a la opción.
        /// </summary>
        /// <exception cref="OpcionInvalidaException">Si la opción no fue ejecutada exitosamente.</exception>
        internal override void EjecutarAccion()
        {
            try
            {
                CatalogoUsuarios catalogUsua = new CatalogoUsuarios();
                Usuario usuario = null;
                Console.Write("Ingrese el documento del usuario a agregar: ");
                int dni = 0;
                try
                {
                    dni = int.Parse(Console.ReadLine());
                    usuario = catalogUsua.ObtenerUsuario(dni);
                    if (usuario != null)
                    {
                        throw new OpcionInvalidaException("Usuario existente");
                    }
                }
                catch (FormatException)
                {
                    throw new OpcionInvalidaException("Número inválido !");
                }

                string nombre;
                Console.Write("Ingrese el Nombre: ");
                try
                {
                    nombre = Console.ReadLine();
                }
                catch (FormatException)
                {
                    throw new OpcionInvalidaException("nombre inválido !");
                }
                string apellido;
                Console.Write("Ingrese el apellido : ");
                try
                {
                    apellido = Console.ReadLine();
                }
                catch (FormatException)
                {
                    throw new OpcionInvalidaException("apellido inválido !");
                }
                Console.WriteLine("Dni {0}agregado con nombre: {1} apellido: {2} .\n", dni, nombre, apellido);
                CatalogoUsuarios insertar = new CatalogoUsuarios();//NOSE SE NO ESTA DEMAS, SE PODRIA USUAR CATALOGUSUA
                Usuario usuario2 = new Usuario(dni, nombre, apellido);
                insertar.ConfirmarInsercion(usuario2);

                Console.Clear();
                Console.WriteLine("Dni:{0} agregado con nombre: {1} apellido: {2} .\n", dni,nombre,apellido);

            }
            catch (ReglasNegocioException ex)
            {
                Console.Clear();
                Console.WriteLine("Error al agregar el usuario nuevo" + ex.Message);
            }
            catch (OpcionInvalidaException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al agregar el usuario.");
            }
        }
    }
}
