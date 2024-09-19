using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CurdDeYoutube.Datos;
using CurdDeYoutube.Models;
namespace CurdDeYoutube.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public ActionResult Listar() {
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public ActionResult Guardar() {
            return View();
        }
        [HttpPost]
        public ActionResult Guardar( ContactoModel oContacto ) {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuest = _ContactoDatos.GuardarContacto(oContacto);

            if (respuest)
            {
                return RedirectToAction("Listar");
            } else
            {
                return View();
            }
        }

        public ActionResult Editar( int idContacto ) {
            var oContacto = _ContactoDatos.ObtenerContacto(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public ActionResult Editar( ContactoModel oContacto ) {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuest = _ContactoDatos.EditarContacto(oContacto);

            if (respuest)
            {
                return RedirectToAction("Listar");
            } else
            {
                return View();
            }
        }

        public ActionResult Eliminar( int idContacto ) {
            var oContacto = _ContactoDatos.ObtenerContacto(idContacto);
            return View(oContacto);
        }

        [HttpPost]
        public ActionResult Eliminar( ContactoModel oContacto ) {

            var respuest = _ContactoDatos.EliminarContacto(oContacto.IDContacto);

            if (respuest)
            {
                return RedirectToAction("Listar");
            } else
            {
                return View();
            }
        }
    }
}
