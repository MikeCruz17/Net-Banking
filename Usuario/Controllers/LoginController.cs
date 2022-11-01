using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace Usuario.Controllers
{
    public class LoginController : Controller
    {

        ClaseNegocio Neg = new ClaseNegocio();
        ClaseNegocioCliente neg = new ClaseNegocioCliente();

        // LOGIN
        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inicio(Usuarios s)
        {
            string email;
            string cont;

            email = s.Correo;
            cont = s.Contraseña;


            var Login = Neg.Login(email, cont);
 

            try
            {
                if (Login == null)
                {
                    ViewBag.Error = "El correo y la contraseña son inválidos";
                    return View();
                }
                else if (Login.Correo == email && Login.Contraseña == cont)
                {
                    if (Login.ID_Rol == 1)
                    {
                        if(Login.Estatus == "Habilitado")
                        {

                        Session["user"] = Login;
                        Session["Cedula"] = Login.Cedula;
                        Session["Nombre"] = Login.Nombre;
                        return RedirectToAction("Administracion", "Home");
                        }
                    }

                    else if (Login.ID_Rol == 2)
                    {
                        if (Login.Estatus == "Habilitado")
                        {
                            Session["user"] = Login;
                            Session["Cedula"] = Login.Cedula;
                            Session["Nombre"] = Login.Nombre;
                            return RedirectToAction("Index", "Cliente");
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult Registro()
        {
 

            return View();
        }

        [HttpPost]

        public ActionResult Registro(Usuarios user)
        {
            user.ID_Rol = 2;
            user.Estatus = "Habilitado";

            Neg.InsertarUsuario(user);

            return RedirectToAction("Inicio", "Login");
        }

        public ActionResult CerrarSesion()
        {
            Session["user"] = null;

            return RedirectToAction("Inicio", "Login");
        }

        //****************************************************************************************************************//


        // GET: Login/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
