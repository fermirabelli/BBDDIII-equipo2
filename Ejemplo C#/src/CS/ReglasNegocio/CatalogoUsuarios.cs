using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using DCE05.Ejemplos.EstrellaUno.AccesoDatos;

namespace DCE05.Ejemplos.EstrellaUno.ReglasNegocio
{

    /// <summary>
    /// Representa el catálogo de productos del sistema.
    /// </summary>
    public class CatalogoUsuarios
    {

        /// <summary>
        /// Obtiene la lista de productos del sistema.
        /// </summary>
        /// <returns>La lista de productos.</returns>
        /// <exception cref="ReglasNegocioException">Si ocurre un error de negocio.</exception>
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                string sql = "SELECT Dni, Nombre, Apellido FROM Usuarios";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComando(sql);
                DbDataReader datos = db.EjecutarConsulta();

                Usuario u = null;
                while (datos.Read())
                {
                    try
                    {
                        u = new Usuario(datos.GetInt32(0), datos.GetString(1), datos.GetString(2));
                        usuarios.Add(u);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new ReglasNegocioException("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new ReglasNegocioException("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (BaseDatosException)
            {
                throw new ReglasNegocioException("Error al acceder a la base de datos para obtener los usuarios.");
            }
            catch (ReglasNegocioException)
            {
                throw new ReglasNegocioException("Error a obtener los usuarios.");
            }
            return usuarios;
        }

        /// <summary>
        /// Obtiene un usuario en base a su código.
        /// </summary>
        /// <param name="dni">El dni del producto.</param>
        /// <returns>El producto encontrado.</returns>
        /// <exception cref="ReglasNegocioException">Si ocurre un error de negocio.</exception>
        public Usuario ObtenerUsuario(int dni)
        {
            Usuario usuario = null;

            try
            {

                if (dni <= 0)
                {
                    throw new ReglasNegocioException("El dni es inválido.");
                }

                string sql = "SELECT Dni, Nombre, Apellido FROM Usuarios WHERE Dni=@dni";
                BaseDatos db = new BaseDatos();
                db.Conectar();
                db.CrearComando(sql);
                db.AsignarParametroEntero("@dni", dni);
                DbDataReader datos = db.EjecutarConsulta();

                while (datos.Read())
                {
                    try
                    {
                        usuario = new Usuario(datos.GetInt32(0), datos.GetString(1), datos.GetString(2));
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new ReglasNegocioException("Los tipos no coinciden.", ex);
                    }
                    catch (DataException ex)
                    {
                        throw new ReglasNegocioException("Error de ADO.NET.", ex);
                    }
                }
                datos.Close();
                db.Desconectar();
            }
            catch (BaseDatosException)
            {
                throw new ReglasNegocioException("Error al acceder a la base de datos para obtener los usuarios.");
            }
            catch (ReglasNegocioException ex)
            {
                throw new ReglasNegocioException("Error a obtener los usuarios. " + ex.Message);
            }
            return usuario;
        }


        /// <summary>
        /// Inserta un usuario nuevo.
        /// </summary>
        /// <param name="dni">el dni del usuario.</param>
        /// <exception cref="ReglasNegocioException">Si ocurre un error de negocio.</exception>
        public void ConfirmarInsercion(Usuario usuario )
        {
            BaseDatos db = new BaseDatos();
            db.Conectar();
            String sql = "INSERT Usuarios (Dni,Nombre,Apellido) VALUES (@dni,@nombre,@apellido)";
            db.CrearComando(sql);
            db.AsignarParametroEntero("@dni", usuario.Dni);
            db.AsignarParametroCadena("@nombre", usuario.Nombre);
            db.AsignarParametroCadena("@apellido", usuario.Apellido);
            db.EjecutarComando();
            db.Desconectar();
        }

        public void EliminarUsuario(int dni) {
            BaseDatos db = new BaseDatos();
            db.Conectar();
            String sql = "DELETE FROM Usuarios WHERE Dni = @dni";
            db.CrearComando(sql);
            db.AsignarParametroEntero("@dni", dni);
            db.EjecutarComando();
            db.Desconectar();
        }
    }
}
