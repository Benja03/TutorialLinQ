using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TutorialLinQ.Models
{
    public class AlumnoCLS
    {
        ITES_MVCEntities contexto;

        [Key]
        public int idAlumno { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public int edad { get; set; }
        public string mail { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string dni { get; set; }

        public AlumnoCLS()
        {
            contexto = new ITES_MVCEntities();
        }

        public List<Alumnos> GetAlumno()
        {
            var listaalu = (from datos in contexto.Alumnos  
                            select datos).ToList();
            return listaalu;
        }

        public void InsertarAlumno(String apellidos, String nombres, int edad, String mail, String domicilio, String telefono, String dni)
        {
            Alumnos alu = new Alumnos();
            alu.apellidos = apellidos;
            alu.nombres = nombres;
            alu.edad = edad;
            alu.mail = mail;
            alu.domicilio = domicilio;
            alu.telefono = telefono;
            alu.dni = dni;

            contexto.Alumnos.Add(alu);

            contexto.SaveChanges();
        }

        public void EditarAlumno(int lega, String apellidos, String nombres, int edad, String mail, String domicilio, String telefono, String dni)
        {
            Alumnos alu = this.DetalleAlumno(lega);

            alu.apellidos = apellidos;
            alu.nombres = nombres;
            alu.edad = edad;
            alu.mail = mail;
            alu.domicilio = domicilio;
            alu.telefono = telefono;
            alu.dni = dni;

            contexto.SaveChanges();
        }

        public Alumnos DetalleAlumno(int lega)
        {
            var alu = (from datos in contexto.Alumnos
                       where datos.idAlumno == lega
                       select datos).FirstOrDefault();

            return alu;
        }

        public void EliminarAlumno(int ID)
        {
            try
            {
                Alumnos alu = new Alumnos();
                alu = DetalleAlumno(ID);
                contexto.Alumnos.Remove(alu);
                contexto.Entry(alu).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}