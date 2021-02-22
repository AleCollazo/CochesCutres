using CochesCutres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CochesCutres.Controllers
{
    public class ClientesController : Controller
    {

        public ActionResult Listado()
        {
            MantenimientoClientes matenimiento = new MantenimientoClientes();

            return View(matenimiento.Listar());
        }

        public ActionResult Alta(Cliente cliente)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            Cliente cliente = new Cliente();
            MantenimientoClientes mantenimiento = new MantenimientoClientes();

            cliente.NIF = collection["NIF"];
            cliente.Nombre = collection["Nombre"];
            cliente.Apellidos = collection["Apellidos"];
            cliente.Telefono = int.Parse(collection["Telefono"]);
            cliente.Direccion = collection["Direccion"];
            cliente.Email = collection["Email"];

            mantenimiento.Alta(cliente);

            return RedirectToAction("Listado");
        }

        public ActionResult Modificar(int idCliente)
        {
            MantenimientoClientes mantenimiento = new MantenimientoClientes();

            return View(mantenimiento.Obtener(idCliente));
        }

        [HttpPost]
        public ActionResult Modificar(FormCollection collection)
        {
            Cliente cliente = new Cliente();
            MantenimientoClientes matenimiento = new MantenimientoClientes();

            cliente.NIF = collection["NIF"];
            cliente.Nombre = collection["Nombre"];
            cliente.Apellidos = collection["Apellidos"];
            cliente.Telefono = int.Parse(collection["Telefono"]);
            cliente.Direccion = collection["Direccion"];
            cliente.Email = collection["Email"];
            cliente.IdCliente = int.Parse(collection["IdCliente"]);

            matenimiento.Modificar(cliente);

            return RedirectToAction("Listado");
        }
    }
}