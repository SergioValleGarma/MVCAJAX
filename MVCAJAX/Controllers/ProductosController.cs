using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ExamenContext _examenContext;

        public ProductosController(ExamenContext examenContext)
        {
            _examenContext = examenContext;
        }

        [HttpGet]
        public IActionResult GetProductos(string Nombre, decimal Precio)
        {
            string nombre = Nombre != null ? Nombre : "" ;
            decimal precio = Precio;
                      

            if (nombre != "" || precio != 0)
            {
                var productos = _examenContext.Productos.Where(X => (X.Nombre==nombre) || (X.Precio==precio)).ToList();
                return Json(productos);
            }else
            {
                var productos = _examenContext.Productos.ToList();
                return Json(productos);
            }

            
            
        }

        public IActionResult CreateProductos()
        {
            return PartialView("_CreateProductoPartial"); 
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(string Nombre, decimal Precio, DateTime FechaVencimiento)
        {
            var producto = new Productos
            {
                Nombre = Nombre,
                Precio = Precio,
                FechaVencimiento = FechaVencimiento
            };
            _examenContext.Productos.Add(producto);
            await _examenContext.SaveChangesAsync();
            return Json(new { message = "Producto registrado con exito"});
        }

        // GET: ProductosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
