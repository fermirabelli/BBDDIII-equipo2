using System;
using System.Collections.Generic;
using System.Text;

using DCE05.Ejemplos.EstrellaUno.ReglasNegocio;

namespace DCE05.Ejemplos.EstrellaUno.Cliente {
    
    /// <summary>
    /// Representa la opción de iniciar una venta.
    /// </summary>
    class OpcionIniciarVenta : Opcion {

        public static Usuario usuario;
        public static int dni;
        /// <summary>
        /// Construye una instancia de la opción con sus datos básicos.
        /// </summary>
        /// <param name="codigo">El código de la opción.</param>
        internal OpcionIniciarVenta(int codigo) {
            Codigo = codigo;
            Descripcion = "Iniciar Venta";
        }
    
        /// <summary>
        /// Ejecuta la acción asociada a la opción.
        /// </summary>
        /// <exception cref="OpcionInvalidaException">Si la opción no fue ejecutada exitosamente.</exception>
        internal override void EjecutarAccion() {
            if (PuntoDeVenta.VentaActual != null) {
                throw new OpcionInvalidaException("La venta ya fue iniciada.");
            }

            try {
                CatalogoVentas catalogo = new CatalogoVentas();
                CatalogoUsuarios catalogoUsua = new CatalogoUsuarios();
                try
                {
                    Console.Write("Ingrese el usuario de la venta: ");
                    dni = int.Parse(Console.ReadLine());
                    usuario = catalogoUsua.ObtenerUsuario(dni);
                    if (usuario == null)
                    {
                        Console.WriteLine("Usuario inexistente! \n Desea Agregarlo?:\n 1-Si\n 2-No \n\n Opcion: ");
                        int opcion = 0;
                        opcion = int.Parse(Console.ReadLine());
                        if (opcion == 2)
                        {
                            Console.Clear();
                            throw new OpcionInvalidaException("Venta No iniciada");
                        }
                        else {
                            Console.Clear();
                            new OpcionAgregarUsuario().EjecutarAccion();
                        }

                    }

                }
                catch (ReglasNegocioException ex){
                    Console.WriteLine("Numero Invalido!", ex.Message);
                }
                PuntoDeVenta.VentaActual = catalogo.IniciarVenta();
            } catch (ReglasNegocioException ex) {
                Console.WriteLine("Error al iniciar una venta: " + ex.Message);
            }
        }
    }
}