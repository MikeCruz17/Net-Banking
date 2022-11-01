    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class ClaseNegocio

        // VARIABLE DE LA CLASE DATOS DE LA CAPA DATOS
    {
        ClaseDatos obj = new ClaseDatos();

        // ----------------------------------------------------------------------------------------------- //

        // *********************************************************************************************** //
        // *********************************************************************************************** //
        // ****************************-- MODULO DE ADMINISTRACCION --************************************ //
        // *********************************************************************************************** //
        // *********************************************************************************************** //

        // ----------------------------------------------------------------------------------------------- //

        // ********************************************************************** //
        // ************************-- TABLA USUARIO --*************************** //
        // ********************************************************************** //


        // LOGIN
        public Usuarios Login(string correo, string password)
        {
            return obj.Confirmacion_Login(correo, password);
        }

        // CREAR USUARIOS
        public void InsertarUsuario(Usuarios usuarios)
        {
            obj.Insertar(usuarios);
         
        }

        // LISTA DE USUARIOS
        public List<Reporte_Usuarios> LeerUsuarios()
        {
            return obj.LeerUsuarios();
        }

        // INFORMACION DEL USUARIO
        public Usuarios UsuarioInformacion(string Cedula)
        {
            return obj.UsuarioInformacion(Cedula);
        }

        // DESHABILTAR USUARIO
        public void DeshabilitarUsuario(string Cedula)
        {
            obj.DeshabilitarUsuario(Cedula);
        }

        // EDITAR USUARIO
        public void EditarUsuario(Usuarios u)
        {
            obj.EditarUsuario(u);
        }

        // ----------------------------------------------------------------------------------------------- //

        // ************************************************************************ //
        // ************************-- TABLA PRESTAMOS --*************************** //
        // ************************************************************************ //

        // CREAR PRESTAMO
        public void CrearPrestamos(PRESTAMO pre)
        {
            obj.CrearPrestamos(pre);
        }

        // LISTA DE PRESTAMOS
        public List<Reporte_Prestamos> LeerPrestamos()
        {
            return obj.LeerPrestamos();
        }

        // DESHABILITAR PRESTAMO
        public void DeshabilitarPrestamo(int id)
        {
            obj.DeshabilitarPrestamos(id);
        }

        // INFORMACION DEL PRESTAMO
        public PRESTAMO InformacionPrestamo(int Numero)
        {
            return obj.InformacionPrestamo(Numero);
        }

        // EDITAR INFORMACION DE UN PRESTAMO
        public void EditarPrestamo(PRESTAMO P)
        {
            obj.EditarPrestamo(P);
        }

        // ----------------------------------------------------------------------------------------------- //

        // *********************************************************************** //
        // ************************-- TABLA TARJETAS --*************************** //
        // *********************************************************************** //


        // CREAR TARJETA
        public void CrearTarjetas(TARJETAS t)
        {
            obj.CrearTarjetas(t);
        }

        // LISTA DE TARJETAS
        public List<Reporte_Tarjetas> LeerTarjetas()
        {
            return obj.LeerTarjetas();
        }

        // ELIMINAR CUENTA
        public void EliminarTarjeta(int Numero)
        {
            obj.EliminarTarjeta(Numero);
        }

        // INFORMACION DE LA TARJETA
        public TARJETAS InformacionTarjeta(int Numero)
        {
            return obj.TarjetasInformacion(Numero);
        }

        // EDITAR INFORMACION DE LA TARJETA
        public void EditarTarjeta(TARJETAS T)
        {
            obj.EditarTarjeta(T);
        }
        // ----------------------------------------------------------------------------------------------- //

        // ********************************************************************* //
        // ************************-- TABLA CUENTA --*************************** //
        // ********************************************************************* //


        // CREAR CUENTA
        public void CrearCuentas(CUENTAS c)
        {
            obj.CrearCuentas(c);
        }

        // LISTA DE CUENTAS
        public List<ReportesCuentas> LeerCuentas()
        {
            return obj.LeerCuentas();
        }


        // ELIMINAR CUENTA
        public void EliminarCuenta(int Numero)
        {
            obj.EliminarCuenta(Numero);
        }

        // INFORMACION DE LA CUENTA
        public CUENTAS InformacionCuenta(int Numero)
        {
            return obj.InformacionCuenta(Numero);
        }

        // EDITAR INFORMACION DE UNA CUENTA
        public void EditarCuenta(CUENTAS c)
        {
            obj.EditarCuenta(c);
        }

        // ----------------------------------------------------------------------------------------------- //

        // ********************************************************************* //
        // ************************-- TABLA USUARIO --************************** //
        // ********************************************************************* //



    }
}
