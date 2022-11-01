using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usuario.Controllers;

namespace Usuario.Filters
{
    public class VeficacionAttribute: ActionFilterAttribute
    {

        // VARIABLE TIPO ROL QUE ALMACENARA LOS DATOS INGRESADOS A TRAVES DEL METODO.
        private int ROL;

        // VARIABLE TIPO USUARIP
        private Usuarios user;

        // CONSTRUCTOR
        public VeficacionAttribute()
        {
        }

        // METODO QUE ME TRAE POR PARAMETRO EL IDROL
        public VeficacionAttribute(int _idrol)
        {
            ROL = _idrol;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // LA VARIABLE TIPO USUARIO QUE ALMACENA LOS QUE SE ENCUENTRA EN LA SESSION DEL CONTROLADOR LOGIN
            user = (Usuarios)HttpContext.Current.Session["user"];
            Usuarios usuario = HttpContext.Current.Session["user"] as Usuarios;

            // SI EL USUARIO ES NULO
            if (user == null)
            {

                if ((filterContext.Controller is LoginController) == false)
                {
                    // RETORNO A LA VISTA LOGIN
                    filterContext.Result = new RedirectResult("/Login/Inicio");

                }

                base.OnActionExecuting(filterContext);

            }


            // SI EL USUARIO NO ES NULO PERO TIENE UN ROL DIFERENTE EN LA VISTA QUE QUIERE ACCEDER
            // ESTO PREVIENE LA ENTRADA A UNA VISTA QUE NO LE CORRESPONDE SEGUN SU ROL DE USUARIO.
            else if (usuario.ID_Rol != ROL)
            {

                if ((filterContext.Controller is LoginController) == false)
                {
                    // LIMPIAR LA SESSSION
                    HttpContext.Current.Session["usuario"] = null;

                    // RETORNO A LA VISTA LOGIN.
                    filterContext.Result = new RedirectResult("/Login/Inicio");

                }

            }

        }
    }

}
