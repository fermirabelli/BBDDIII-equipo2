using System;
using System.Collections.Generic;
using System.Text;

using DCE05.Ejemplos.EstrellaUno.ReglasNegocio;

namespace DCE05.Ejemplos.EstrellaUno.Cliente
{

    /// <summary>
    /// Representa la opción de listar los productos disponibles.
    /// </summary>
    internal class OpcionListarUsuarios : Opcion
    {

        /// <summary>
        /// Construye una instancia de la opción con sus datos básicos.
        /// </summary>
        /// <param name="codigo">El código de la opción.</param>
        internal OpcionListarUsuarios(int codigo)
        {
            Codigo = codigo;
            Descripcion = "Listar Usuarios";
        }

        /// <summary>
        /// Construye una instancia de la opción vacía.
        /// </summary>
        internal OpcionListarUsuarios() : this(0)
        {
        }

        /// <summary>
        /// Ejecuta la acción asociada a la opción.
        /// </summary>
        internal override void EjecutarAccion()
        {
            try
            {
                CatalogoUsuarios catalogo = new CatalogoUsuarios();
                List<Usuario> usuarios = catalogo.ObtenerUsuarios();

                Console.WriteLine("Listado de Usuarios");
                Console.WriteLine("--------------------\n");
                Console.WriteLine("{0}\t{1}\t\t{2}", "DNI".PadRight(7), "Nombre".PadRight(30), "Apellido");
                foreach (Usuario usuario in usuarios)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}", usuario.Dni.ToString().PadRight(7), usuario.Nombre.PadRight(30),
                        usuario.Apellido);
                }
                Console.WriteLine("\n\n");
            }
            catch (ReglasNegocioException ex)
            {
                Console.WriteLine("Error al listar los usuarios: " + ex.Message);
            }
        }
    }
}
