using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;
using Usuario.Filters;

namespace Usuario.Controllers
{
    public class HomeController : Controller
    {
        ClaseNegocio Neg = new ClaseNegocio();

        [Veficacion(1)]
        public ActionResult Administracion()
        {
            var Nombre = Session["Nombre"];

            ViewBag.Nombre = Nombre;
            return View();
        }

        [Veficacion(1)]
        public ActionResult Cliente()
        {
            return View();
        }


        // ----------------------------------------------------------------------------------------------- //

        // *********************************************************************************************** //
        // ************************************ -- CRUD DE CUENTAS -- ************************************ //
        // *********************************************************************************************** //

        // CREACION DE CUENTAS
        [Veficacion(1)]
        public ActionResult CrearCuentas()
        {

            return View();
        }

        [HttpPost]
        [Veficacion(1)]
        public ActionResult CrearCuentas(CUENTAS c)
        {
            c.Estado = "Disponible";
            Neg.CrearCuentas(c);
            return View();
        }

        // VISTA DE LAS CUENTAS CON LOS DATOS DEL USUARIO 
        [Veficacion(1)]
        public ActionResult ReporteCuentas()
        {
            var cuentas = Neg.LeerCuentas();
            return View(cuentas);
        }

        // ELIMINAR CUENTAS
        [Veficacion(1)]
        [HttpGet]
        public ActionResult EliminarCuenta(int id)
        {
         
            Neg.EliminarCuenta(id);

            return RedirectToAction("ReporteCuentas", "Home");
        }
        [Veficacion(1)]
        // EDITAR CUENTAS
        public ActionResult EditarCuenta(int id)
        {
            var d = Neg.InformacionCuenta(id);
            return View(d);
        }
        [Veficacion(1)]
        [HttpPost]
        public ActionResult EditarCuenta(CUENTAS c)
        {
            Neg.EditarCuenta(c);
            return RedirectToAction("ReporteCuentas", "Home");

        }

        // ----------------------------------------------------------------------------------------------- //

        // ************************************************************************************************ //
        // ************************************ -- CRUD DE CLIENTES -- ************************************ //
        // ************************************************************************************************ //

        // REGISTRO DE CLIENTE
        [Veficacion(1)]
        public ActionResult RegistroCliente()
        {
            return View();
        }

        [HttpPost]
        [Veficacion(1)]
        public ActionResult RegistroCliente(Usuarios usuarios)
        {
            usuarios.Estatus = "Habilitado";
            Neg.InsertarUsuario(usuarios);
            return View();
        }

        [Veficacion(1)]
        // VISTA DE LOS USUARIOS
        public ActionResult ReporteUsuario()
        {
            var usuarios = Neg.LeerUsuarios();
            return View(usuarios);
        }

        [Veficacion(1)]
        // DESHABILITAR USUARIO
        [HttpGet]

        public ActionResult EditarEstado(string id)
        {
            Neg.DeshabilitarUsuario(id);
            return RedirectToAction("ReporteUsuario", "Home");

        }

        [Veficacion(1)]
        // EDITAR USUARIO
        public ActionResult EditarUsuario(string id)
        {
            var d = Neg.UsuarioInformacion(id);
            return View(d);
        }

        [Veficacion(1)]
        [HttpPost]
        public ActionResult EditarUsuario(Usuarios u)
        {
            Neg.EditarUsuario(u);
            return RedirectToAction("ReporteUsuario", "Home");

        }

        // ----------------------------------------------------------------------------------------------- //

        // ************************************************************************************************ //
        // ************************************ -- CRUD DE TARJETAS -- ************************************ //
        // ************************************************************************************************ //


        [Veficacion(1)]
        // CREAR TARJETAS
        public ActionResult CrearTarjetas()
        {

            return View();
        }

        [Veficacion(1)]
        [HttpPost]
        public ActionResult CrearTarjetas(TARJETAS t)
        {
            t.Estatus = "Activo";
            t.BALANCE = t.BALANCE_LIMITE;
            Neg.CrearTarjetas(t);
            return View();
        }

        [Veficacion(1)]
        // LISTA DE TARJETAS
        public ActionResult ReporteTarjetas()
        {
            var Tarjetas = Neg.LeerTarjetas();
            return View(Tarjetas);
        }

        [Veficacion(1)]
        // ELIMINAR CUENTAS
        [HttpGet]
        public ActionResult EliminarTarjeta(int id)
        {

            Neg.EliminarTarjeta(id);

            return RedirectToAction("ReporteTarjetas", "Home");
        }

        [Veficacion(1)]
        // EDITAR TARJETA
        public ActionResult EditarTarjeta(int id)
        {
            var d = Neg.InformacionTarjeta(id);
            return View(d);
        }

        [Veficacion(1)]
        [HttpPost]
        public ActionResult EditarTarjeta(TARJETAS T)
        {
            Neg.EditarTarjeta(T);
            return RedirectToAction("ReporteTarjetas", "Home");

        }

        // ----------------------------------------------------------------------------------------------- //

        // ************************************************************************************************* //
        // ************************************ -- CRUD DE PRESTAMOS -- ************************************ //
        // ************************************************************************************************* //


        [Veficacion(1)]
        public ActionResult CrearPrestamos()
        {
            return View();
        }

        [Veficacion(1)]
        [HttpPost]
        public ActionResult CrearPrestamos(PRESTAMO pre)
        {
            Neg.CrearPrestamos(pre);
            return View();
        }

        [Veficacion(1)]
        // LISTA DE PRESTAMOS
        public ActionResult ReportePrestamos()
        {
            var Pres = Neg.LeerPrestamos();
            return View(Pres);
        }

        [Veficacion(1)]
        // DESHABILITAR PRESTAMO
        [HttpGet]
        public ActionResult DeshabilitarPrestamo(int id)
        {
           Neg.DeshabilitarPrestamo(id);
            return RedirectToAction("ReportePrestamos", "Home");
        }

        [Veficacion(1)]
        // EDITAR PRESTAMOS
        public ActionResult EditarPrestamo(int id)
        {
            var d = Neg.InformacionPrestamo(id);
            return View(d);
        }

        [Veficacion(1)]
        [HttpPost]
        public ActionResult EditarPrestamo(PRESTAMO P)
        {
            Neg.EditarPrestamo(P);
            return RedirectToAction("ReportePrestamos", "Home");

        }
    }
}