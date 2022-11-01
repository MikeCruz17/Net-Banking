using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocio
{
    public class ClaseNegocioCliente
    {
        ClaseDatosCliente Datos = new ClaseDatosCliente();

        // **************************************************************************************************** //
        // **************************************************************************************************** //
        // **************************************************************************************************** //


        // LOGIN
        public CUENTAS BalanceInfo(string Cedula)
        {
            return Datos.Balance(Cedula);
        }

        // LISTA DE CUENTAS

        public List<CUENTAS> CuentasCliente()
        {

            return Datos.CuentaClient();
        }

        // STORE PROCEDURE QUE ME GUARDA LOS CAMBIOS DE LA TRANSACCION
        public void TransaccionCuenta(int Cuenta_pago, int Cuenta_deposito, int Monto)
        {
            Datos.Transaccion_Cuenta(Cuenta_pago, Cuenta_deposito, Monto);
        }

        // GUARDAR TRANSACCION
        public void GuardarTransaccion(TRANSACCION T)
        {
            Datos.GuardarTransaccion(T);
        }

        // STORE PROCEDURE QUE ME DEVUELVE UNA CONSULTA EN RANGO DE FECHAS
       

        // **************************************************************************************************** //
        // **************************************************************************************************** //
        // **************************************************************************************************** //


        public List<PRESTAMO> PrestamosCliente()
        {

            return Datos.PrestamoCliente();
        }

        // INFORMACION DEL PRESTAMO

        public PRESTAMO InfoPrestamo (int id)
        {

            return Datos.InfoPrestamo(id);
        }

        // STORE PROCEDURE QUE ME GUARDA Y REALIZA LAS OPERACIONES LOGICAS
        public void PagoPrestamo(int ID, int Cuenta, int Monto)
        {
            Datos.PagoPrestamos(ID, Cuenta, Monto);
        }

        // GUARDAR DATOS A LA TABLA DE PAGOS DE PRESTAMOS

        public void GuardarPagosPrestamos(PAGO_PRESTAMO T)
        {
            Datos.GuardarPago_Prestamos(T);
        }

        // HISTORIAL DE PAGOS
        public List<PAGO_PRESTAMO> Hist_Pagos_Prestamos(int id)
        {

            return Datos.Hist_Pagos_Prestamos(id);
        }

        // **************************************************************************************************** //
        // **************************************************************************************************** //
        // **************************************************************************************************** //

        // LISTA DE TARJETA
        public List<TARJETAS> ListTarjetas()
        {

            return Datos.ListTarjetas();
        }

        // INFORMACION DEL/ DE LAS TARJETAS

        public TARJETAS InfoTarjeta(int id)
        {

            return Datos.InfoTarjeta(id);
        }

        // GUARDAR DATOS A LA TABLA DE PAGOS DE TARJETAS
        public void Guarcar_Pago_Tarjeta(PAGO_TARJETA p)
        {
            Datos.GuardarPagos_Tarjeta(p);
        }

        // STORE PROCEDURE QUE ME GUARDA Y REALIZA LAS OPERACIONES LOGICAS DEL PAGO DE LA TARJETA
        public void EST_PAGO_TARJETA(int Monto_Desc, int Numero, int Cuenta_desc)
        {
            Datos.PROC_Pago_Tarjeta(Monto_Desc, Numero, Cuenta_desc);
        }

        // INFORMACION DEL/ DE LOS PAGOS DE LA TARJETA
        public List<PAGO_TARJETA> ListPagoTarjeta()
        {

            return Datos.listPagosTarjetas();
        }

        // GUARDAR DATOS DEL AVANCE DE EFECTIVO
        public void Guardar_Avance_EF(TRANSACCION_TARJETA TR)
        {
            Datos.Guardar_AvanceEF(TR);
        }


        // STORE PROCEDURE QUE ME GUARDA Y REALIZA LAS OPERACIONES LOGICAS DEL AVANCE DE EFECTIVO
        public void EST_AVANCE_EFECTIVO(int NumeroT, int Cuenta_Deposito, int Monto)
        {
            Datos.PROC_Avance_EF(NumeroT, Cuenta_Deposito, Monto);
        }


    }
}
