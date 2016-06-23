using System;
using System.Collections.Generic;
using System.Text;

using DCE05.Ejemplos.EstrellaUno.ReglasNegocio;

namespace DCE05.Ejemplos.EstrellaUno.Cliente
{
    internal class OpcionEliminarUsuario : Opcion
    {

        /// <summary>
        /// Construye una instancia de la opción con sus datos básicos.
        /// </summary>
        /// <param name="codigo">El código de la opción.</param>
        internal OpcionEliminarUsuario(int codigo)
        {
            Codigo = codigo;
            Descripcion = "Eliminar un Usuario";
        }

        internal override void EjecutarAccion()
        {
            try
            {
                new OpcionListarUsuarios().EjecutarAccion();

                CatalogoUsuarios catalogoUsua = new CatalogoUsuarios();
                Usuario usuario = null;
                int dni = 0;
                Console.Write("Ingrese el DNI del usuario a eliminar: ");
                try
                {
                    dni = int.Parse(Console.ReadLine());
                    usuario = catalogoUsua.ObtenerUsuario(dni);
                    if (usuario == null)
                    {
                        throw new OpcionInvalidaException("Usuario inexistente");
                    }
                }
                catch (FormatException)
                {
                    throw new OpcionInvalidaException("Número inválido !");
                }
                catalogoUsua.EliminarUsuario(dni);
                Console.Clear();
                Console.Write("Usuario con DNI: {0} eliminado\n", dni);


            }
            catch (ReglasNegocioException ex)
            {
                Console.Clear();
                Console.WriteLine("Error al eliminar usuario " + ex.Message);
            }
            catch (OpcionInvalidaException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al eliminar usuario");
            }

        }
    }
}