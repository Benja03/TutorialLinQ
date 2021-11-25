using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorialLinQ.Models;

namespace TutorialLinQ.Controllers
{
    public class AlumnosController : Controller
    {
        AlumnoCLS modelo;

        public AlumnosController()
        {
            modelo = new AlumnoCLS();
        }

        // GET: Lista
        public ActionResult Lista()
        {
            List<Alumnos> listaalu = modelo.GetAlumno();

            return View(listaalu);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(String APELLIDOS, String NOMBRES, int EDAD, String MAIL, String DOMICILIO, String TELEFONO, String DNI)
        {
            modelo.InsertarAlumno(APELLIDOS, NOMBRES, EDAD, MAIL, DOMICILIO, TELEFONO, DNI);
            return RedirectToAction("Lista");
        }

        // GET: Delete
        public ActionResult Delete(int ID)
        {

            modelo.EliminarAlumno(ID);
            return RedirectToAction("Lista");
        }

        // GET: Edit
        public ActionResult Edit(int ID)
        {
            Alumnos alu = modelo.DetalleAlumno(ID);
            return View(alu);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(int ID, String APELLIDOS, String NOMBRES, int EDAD, String MAIL, String DOMICILIO, String TELEFONO, String DNI)
        {
            modelo.EditarAlumno(ID, APELLIDOS, NOMBRES, EDAD, MAIL, DOMICILIO, TELEFONO, DNI);
            return RedirectToAction("Lista");
        }

        // GET: Details
        public ActionResult Details(int ID)
        {
            Alumnos alu = modelo.DetalleAlumno(ID);
            return View(alu);
        }

        // GET: Alumnos
        public ActionResult Index()
        {
            return View();
        }

        //Convert Index Page as PDF
        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Lista");
            return report;
        }

        //Convert partial Page as PDF
        public ActionResult PrintPartialViewToPdf(int id)
        {
            using (ITES_MVCEntities db = new ITES_MVCEntities())
            {
                Alumnos alumno = modelo.DetalleAlumno(id);
                var report = new PartialViewAsPdf("~/Views/Shared/DetailEmployee.cshtml", alumno);
                return report;
            }
        }

    }
}