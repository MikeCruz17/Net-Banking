using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;
using Usuario.Filters;

namespace Usuario.Controllers
{
    public class ClienteController : Controller
    {

        ClaseNegocioCliente neg = new ClaseNegocioCliente();

        // PAGINA DE INICIO

        [Veficacion(2)]
        public ActionResult Index()
        {
            var Cedula = Session["Cedula"];

            var Nombre = Session["Nombre"];

      //      ViewBag.Tarjeta = Session["Tarjetas"];


            ViewBag.Hola = Cedula;

            ViewBag.Nombre = Nombre;

            return View();
        }

        [Veficacion(2)]
        [HttpGet]

        // CUENTAS DE AHORRO

        public ActionResult Balance()
        {

            var Cedula = Session["Cedula"];
            ViewBag.Hola = Cedula;
            var b = neg.BalanceInfo(Cedula.ToString());
            return View(b);
        }

        [Veficacion(2)]
        [HttpGet]
        public ActionResult Cuentas()
        {
            var Cedula = Session["Cedula"];
            ViewBag.Cedula = Cedula;

            var b = neg.CuentasCliente();

            return View(b);
        }

        [Veficacion(2)]
        // TRANSFERENCIAS BANCARIAS A TRAVÉS DE LA CUENTA
        public ActionResult Tranferencia(string id)
        {
           
            ViewBag.Cuenta = id;

            return View();
        }

        [Veficacion(2)]
        [HttpPost]
        public ActionResult Tranferencia(TRANSACCION t)
        {

            int Cuenta_pago = (int)t.ID_CUENTA_DEPOSITO;
            int Cuenta_a_depositar = (int)t.ID_CUENTA_ENVIO;
            int Monto = (int)t.DINERO;

            t.Tipo_Transaccion = "Depósito";


            // GUARDAR TRANSACCION
            neg.GuardarTransaccion(t);

           
            // PROCEDURE QUE ME GUARDA LA TRANSACCION
            neg.TransaccionCuenta(Cuenta_pago,Cuenta_a_depositar,Monto);
            return RedirectToAction("Cuentas", "Cliente");

        }

        // REALIZAR AVANCE DE EFECTIVO
        [HttpGet]
        [Veficacion(2)]
        public ActionResult AvanceEfectivo(int id)
        {

            // VARIABLES QUE ME RETORNAN DATOS
            var Cedula = Session["Cedula"];
            ViewBag.Cedula = Cedula;

            ViewBag.Cuenta = id;

          
            // VARIABLE QUE ME OBTIENE LA FECHA ACTUAL

            var dateAndTime = DateTime.Now;
            var Fecha = dateAndTime.ToShortDateString();

            ViewBag.Fecha = Fecha;


            return View();
        }

        [Veficacion(2)]
        [HttpPost]
        public ActionResult AvanceEfectivo(TRANSACCION_TARJETA t)
        {

            // VARIABLES PARA LAS OPERACIONES LOGICAS

            var NumeroT = (int)t.Numero_Tarjeta;
            var CuentaD = (int)t.ID_CUENTA_ENVIO;
            var Dinero = (int)t.DINERO;

            // REALIZAR OPERACIONES LOGICAS 

            neg.EST_AVANCE_EFECTIVO(NumeroT, CuentaD, Dinero);

            // AGREGAR DATOS A LA TABLA DE TRANSACCIONES DE TARJETA
            neg.Guardar_Avance_EF(t);


            // RETORNAR A LA VISTA ANTERIOR
            return RedirectToAction("Cuentas", "Cliente");
        }

        // ************************* -- RETIRO DE EFECTIVO -- ********************************************* //
        /* [HttpGet]
          public ActionResult RetiroEfectivo(int id)
          {
              Session["idCuenta"] = id;

              // VARIABLE QUE ME OBTIENE LA FECHA ACTUAL

              var dateAndTime = DateTime.Now;
              var Fecha = dateAndTime.ToShortDateString();

              DateTime ejemploFecha = DateTime.Parse("2021-12-02");

            //  var c = neg.ReporteCuenta(ejemploFecha, dateAndTime);

              return View();
          }

          [HttpGet]
          public ActionResult RangoFechaTransacciones()
          {

              // VARIABLE QUE ME OBTIENE LA FECHA ACTUAL

              var dateAndTime = DateTime.Now;
              var Fecha = dateAndTime.ToShortDateString();

              DateTime ejemploFecha = DateTime.Parse("2021-12-02");


              return View(dateAndTime.ToString(),ejemploFecha.ToString());
          }*/

        //***********************************************************************************************************//
        //***********************************************************************************************************//
        //***********************************************************************************************************//


        // PRESTAMOS 

        [Veficacion(2)]
        [HttpGet]
        public ActionResult Prestamos()
        {
            var Cedula = Session["Cedula"];
            ViewBag.Cedula = Cedula;

            var b = neg.PrestamosCliente();
          

            return View(b);
        }



        // PAGO DE PRESTAMOS
        [Veficacion(2)]
        public ActionResult PagoPrestamos(int id)
        {
           

            var p = neg.InfoPrestamo(id);

            var Cedula = Session["Cedula"];

            ViewBag.Cedula = Cedula;
            ViewBag.NCuenta = p.Cuenta_id;
            ViewBag.Cuota = p.Cuota_Mensual;
            ViewBag.Cantidad = p.Cantidad_Meses;

            Session["Numero"] = p.ID;

                ViewBag.ID = p.ID;

            // VARIABLE QUE ME OBTIENE LA FECHA ACTUAL

            var dateAndTime = DateTime.Now;
            var Fecha = dateAndTime.ToShortDateString();

            ViewBag.Fecha = Fecha;

            return View();
        }

        [HttpPost]
        [Veficacion(2)]
        public ActionResult PagoPrestamos(PAGO_PRESTAMO P)
        {

            int id = (int)P.ID;
            int Cuenta = (int)P.Cuenta_id;
            int Monto = (int)P.Cuota_Mensual;

            neg.PagoPrestamo(id,Cuenta,Monto);

                neg.GuardarPagosPrestamos(P);
           
            return RedirectToAction("Prestamos", "Cliente");

        }

        // TABLA DE HISTORIAL DE PAGOS DEL/DE LOS PRESTAMOS
        [Veficacion(2)]
        
        public ActionResult ReportePago(int id)
        {
            var Cedula = Session["Cedula"];

            ViewBag.Cedula = Cedula;

            var HistorialPagos = neg.Hist_Pagos_Prestamos(id);
            return View(HistorialPagos);

        }


        //***********************************************************************************************************//
        //***********************************************************************************************************//
        //***********************************************************************************************************//

        [Veficacion(2)]
        [HttpGet]
        public ActionResult Tarjetas()
        {
            var Cedula = Session["Cedula"];
            ViewBag.Cedula = Cedula;

            var b = neg.ListTarjetas();


            return View(b);
        }


        [HttpGet]
        // PAGO DE TARJETAS
        [Veficacion(2)]
        public ActionResult PagoTarjetas(int id)
        {
            var info = neg.InfoTarjeta(id);

            Session["Numero"] = info.Numero;
            ViewBag.Cuenta_id = info.Cuenta_id;
            ViewBag.Cedula = info.Cedula;
            ViewBag.Balance = info.BALANCE;
            ViewBag.BalanceL = info.BALANCE_LIMITE;
          

            // VARIABLE QUE ME OBTIENE LA FECHA ACTUAL

            var dateAndTime = DateTime.Now;
            var Fecha = dateAndTime.ToShortDateString();

            ViewBag.Fecha = Fecha;

            return View();
        }

        [HttpPost]
        [Veficacion(2)]
        public ActionResult PagoTarjetas(PAGO_TARJETA T)
        {
            // VARIABLE PARA GUARDAR DATOS EN LA TABLA PAGO_TARJETA
            var numero = Session["Numero"];
            var Cedula = Session["Cedula"];

            // CONVIRTIENDO 
            T.ID_TARJETA = (int)numero;
            T.Cedula = Cedula.ToString();
            T.ID = 0;

            // VARIABLES PARA EL STORED PROCEDURE

            int Cuenta_desc = (int)T.Cuenta_id;
            int Numero = (int)T.ID_TARJETA;
            int Monto_desc = (int)T.Total_Pago;

            // APLICANDO LA LOGICA Y LAS OPERACIONES DEL STORED PROCEDURE

            neg.EST_PAGO_TARJETA(Monto_desc,Numero,Cuenta_desc);

            // AGREGANDO DATOS A LA TABLA
            neg.Guarcar_Pago_Tarjeta(T);


            // RETORNAR A LA VISTA ANTERIOR
            return RedirectToAction("Tarjetas", "Cliente");

        }

        // HISTORIAL DE PAGO DE TARJETAS

        [HttpGet]
        [Veficacion(2)]
        public ActionResult PagosTarjeta(int id)
        {
            Session["Numero"] = id;
            var Cedula = Session["Cedula"];
            ViewBag.Cedula = Cedula;

            ViewBag.Numero = Session["Numero"];

            var b = neg.ListPagoTarjeta();

            return View(b);
        }

      

        //***********************************************************************************************************//
        //***********************************************************************************************************//
        //***********************************************************************************************************//



        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
