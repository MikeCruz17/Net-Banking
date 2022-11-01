using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos
{
    public class ClaseDatos
    {

        // VARIABLE MODELO DE LA BASE DE DATOS BANKING

        BANKINGEntities db = new BANKINGEntities();

        // ----------------------------------------------------------------------------------------------- //

        // *********************************************************************************************** //
        // *********************************************************************************************** //
        // ****************************-- MODULO DE ADMINISTRACCION --************************************ //
        // *********************************************************************************************** //
        // *********************************************************************************************** //

        // ----------------------------------------------------------------------------------------------- //


        // ****************************************************************************** //
        // ****************************-- TABLA CUENTAS --******************************* //
        // ****************************************************************************** //


        // CREAR CUENTA
        public void CrearCuentas(CUENTAS C)
        {
            db.CUENTAS.Add(C);
            db.SaveChanges();
        }
        
        // LISTA DE CUENTAS
        public List<ReportesCuentas> LeerCuentas()
        {
            return db.ReportesCuentas.ToList();
        }

        // ELIMINAR CUENTA
        public void EliminarCuenta(int Numero)
        {
            var d = db.CUENTAS.Find(Numero);
            d.Estado = "Desactivado";
            db.SaveChanges();
        }

        // INFORMACION DE LA CUENTA
        public CUENTAS InformacionCuenta(int Numero)
        {
            return db.CUENTAS.Find(Numero);
        }

        // EDITAR INFORMACION DE LA CUENTA
        public void EditarCuenta(CUENTAS c)
        {
            var d = db.CUENTAS.Find(c.Numero);
            d.Cedula = c.Cedula;
            d.Balance = c.Balance;
            d.Monto_Limite = c.Monto_Limite;
            db.SaveChanges();
        }

        // ----------------------------------------------------------------------------------------------- //

        // ******************************************************************************* //
        // ****************************-- TABLA USUARIOS --******************************* //
        // ******************************************************************************* //

        // LOGIN
        public Usuarios Confirmacion_Login(string correo, string password)
        {
            return (from user in db.Usuarios
                    where user.Correo == correo &&
                    user.Contraseña == password
                    select user).FirstOrDefault();

        }


        // INSERTAR
        public void Insertar(Usuarios us)
        {
            db.Usuarios.Add(us);
            db.SaveChanges();

        }

        // LISTA DE USUARIOS
        public List<Reporte_Usuarios> LeerUsuarios()
        {
            return db.Reporte_Usuarios.ToList();
        }

        // DESHABILITAR USUARIO
        public void DeshabilitarUsuario(string Cedula)
        {
            var d = db.Usuarios.Find(Cedula);
            d.Estatus = "Deshabilitado";
            db.SaveChanges();
        }

        // INFORMACION DEL USUARIO
        public Usuarios UsuarioInformacion(string Cedula)
        {
            return db.Usuarios.Find(Cedula);
        }

        // EDITAR DATOS DE USUARIO

        public void EditarUsuario(Usuarios u)
        {
            var d = db.Usuarios.Find(u.Cedula);
            d.Cedula = u.Cedula;
            d.Nombre = u.Nombre;
            d.Apellido = u.Apellido;
            d.Direccion = u.Direccion;
            d.Fecha_Nacimiento = u.Fecha_Nacimiento;
            d.Sexo = u.Sexo;
            d.Telefono = u.Telefono;
            d.Correo = u.Correo;
            d.Contraseña = u.Contraseña;
            d.ID_Rol = u.ID_Rol;
            d.Estatus = u.Estatus;
            db.SaveChanges();
        }


        // ----------------------------------------------------------------------------------------------- //

        // ******************************************************************************* //
        // ****************************-- TABLA TARJETAS --******************************* //
        // ******************************************************************************* //


        // CREAR TARJETAS
        public void CrearTarjetas(TARJETAS t)
        {
            db.TARJETAS.Add(t);
            db.SaveChanges();

        }

        // LISTA DE TARJETAS
        public List<Reporte_Tarjetas> LeerTarjetas()
        {
            return db.Reporte_Tarjetas.ToList();
        }

        // ELIMINAR TARJETA
        public void EliminarTarjeta(int Numero)
        {
            var d = db.TARJETAS.Find(Numero);
            d.Estatus = "Inactivo";
            db.SaveChanges();
        }


        // INFORMACION DEL USUARIO
        public TARJETAS TarjetasInformacion(int Numero)
        {
            return db.TARJETAS.Find(Numero);
        }


        // EDITAR DATOS DE UNA TARJETA

        public void EditarTarjeta(TARJETAS T)
        {
            var d = db.TARJETAS.Find(T.Numero);
            d.Cuenta_id = T.Cuenta_id;
            d.Cedula = T.Cedula;
            d.Fecha_de_Vencimiento = T.Fecha_de_Vencimiento;
            db.SaveChanges();
        }


        // ----------------------------------------------------------------------------------------------- //

        // ******************************************************************************** //
        // ****************************-- TABLA PRESTAMOS --******************************* //
        // ******************************************************************************** //

        // CREAR PRESTAMOS
        public void CrearPrestamos(PRESTAMO pre)
        {
            db.PRESTAMO.Add(pre);
            db.SaveChanges();
        }

        // LISTA DE TARJETAS
        public List<Reporte_Prestamos> LeerPrestamos()
        {
            return db.Reporte_Prestamos.ToList();
        }

        // DESHABILITAR PRESTAMOS
        public void DeshabilitarPrestamos(int id)
        {
            var d = db.PRESTAMO.Find(id);
            d.Estado = "Inactivo";
            db.SaveChanges();
        }

        // INFORMACION DEL PRESTAMO
        public PRESTAMO InformacionPrestamo(int id)
        {
            return db.PRESTAMO.Find(id);
        }

        // EDITAR INFORMACION DE UN PRESTAMO
        public void EditarPrestamo(PRESTAMO P)
        {
            var d = db.PRESTAMO.Find(P.ID);
            d.Monto = P.Monto;
            d.Cedula = P.Cedula;
            d.Cuenta_id = P.Cuenta_id;
            d.Cuota_Mensual = P.Cuota_Mensual;
            d.Estado = P.Estado;
            d.Fecha = P.Fecha;
            d.Cantidad_Meses = P.Cantidad_Meses;
            db.SaveChanges();
        }

    }
}
