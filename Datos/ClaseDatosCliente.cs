using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class ClaseDatosCliente
    {
        // VARIABLE MODELO DE LA BASE DE DATOS BANKING

        BANKINGEntities db = new BANKINGEntities();

        // **************************************************************************************************** //
        // **************************************************************************************************** //
        // **************************************************************************************************** //

        // INFORMACION DEL BALANCE
        public CUENTAS InformacionCuenta(int Numero)
        {
            return db.CUENTAS.Find(Numero);
        }

        // LOGIN
        public CUENTAS Balance(string Cedula)
        {
            return (from c in db.CUENTAS
                    where c.Cedula == Cedula
                    select c).FirstOrDefault();

        }

        // LISTA DE CUENTAS

        public List<CUENTAS> CuentaClient()
        {
            return db.CUENTAS.ToList();
        }


        // STORE PROCEDURE QUE ME REALIZA LA TRANSACCION

        public void Transaccion_Cuenta(int Cuenta_pago, int Cuenta_deposito, int Monto)
        {
            db.TRANSACCIONES(Cuenta_pago, Cuenta_deposito, Monto);
            db.SaveChanges();
        }

        // GUARDAR TRANSACCION
        public void GuardarTransaccion(TRANSACCION t)
        {
            db.TRANSACCION.Add(t);
            db.SaveChanges();
        }


        // STORE PROCEDURE QUE ME DEVUELVE UNA CONSULTA EN RANGO DE FECHAS

   

        // **************************************************************************************************** //
        // **************************************************************************************************** //
        // **************************************************************************************************** //

        // LISTA DE PRESTAMOS

        public List<PRESTAMO> PrestamoCliente()
        {
            return db.PRESTAMO.ToList();
        }

        // GUARDAR PAGO DE PRESTAMOS
        public void GuardarPago_Prestamos(PAGO_PRESTAMO p)
        {
            db.PAGO_PRESTAMO.Add(p);
            db.SaveChanges();
        }

        // INFORMACION DEL PRESTAMO
        public PRESTAMO InfoPrestamo(int id)
        {
            return (from c in db.PRESTAMO
                    where c.ID == id
                    select c).FirstOrDefault();

        }

        // PROCEDIMIENTO QUE ME GUARDA EL PAGO DEL PRESTAMO
        public void PagoPrestamos(int ID, int Cuenta, int Monto)
        {
            db.PAGOS_Prestamos(ID, Cuenta,Monto);
        }

        // HISTORIAL DE PAGO

        public List<PAGO_PRESTAMO> Hist_Pagos_Prestamos(int id)
        {
            return (from p in db.PAGO_PRESTAMO
                    where p.ID_PRESTAMO == id
                    select p).ToList();
        }

        // **************************************************************************************************** //
        // **************************************************************************************************** //
        // **************************************************************************************************** //

        // LISTA DE TARJETAS

        public List<TARJETAS> ListTarjetas()
        {
            return db.TARJETAS.ToList();
        }

        // INFORMACION DE LA TARJETA
        public TARJETAS InfoTarjeta(int id)
        {
            return (from c in db.TARJETAS
                    where c.Numero == id
                    select c).FirstOrDefault();

        }

       

        // GUARDAR INFORMACION EN LA TABLA DE PAGOS
        public void GuardarPagos_Tarjeta(PAGO_TARJETA p)
        {
            db.PAGO_TARJETA.Add(p);
            db.SaveChanges();
        }

        // PROCEDIMIENTO QUE ME GUARDA EL PAGO DE LA TARJETA
        public void PROC_Pago_Tarjeta(int Monto_Deuda, int Numero, int Cuenta_Descontar)
        {
            db.PAGO_DE_TARJETA(Monto_Deuda, Numero, Cuenta_Descontar);
            db.SaveChanges();
        }


        // LISTA DE PAGOS DE TARJETAS

        public List<PAGO_TARJETA> listPagosTarjetas()
        {
            return db.PAGO_TARJETA.ToList();
        }

        // REGISTRAR AVANCE DE EFECTIVO
        public void Guardar_AvanceEF(TRANSACCION_TARJETA tr)
        {
            db.TRANSACCION_TARJETA.Add(tr);
            db.SaveChanges();
        }

        // PROCEDIMIENTO QUE ME GUARDA EL AVANCE DE EFECTIVO
        public void PROC_Avance_EF(int NumerT, int CuentaDeposito, int Monto)
        {
            db.TRANSACCIONES_TARJETAS(NumerT, CuentaDeposito, Monto);
            db.SaveChanges();
        }
    }
}
