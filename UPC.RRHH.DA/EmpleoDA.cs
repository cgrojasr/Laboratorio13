using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.RRHH.BE;
using UPC.RRHH.EF;

namespace UPC.RRHH.DA
{
    public class EmpleoDA
    {
        private readonly ddRRHHEntities db;

        public EmpleoDA()
        {
            db = new ddRRHHEntities();
        }

        public int Registrar(EmpleoBE objEmpleoBE) {
            var objEmpleo = new empleo { 
                nombre = objEmpleoBE.nombre,
                salario_minimo = objEmpleoBE.salario_minimo,
                salario_maximo = objEmpleoBE.salario_minimo
            };

            db.empleos.Add(objEmpleo);
            db.SaveChanges();

            return objEmpleo.codigo;
        }

        public List<EmpleoBE> ListarEmpleosPorNombre(string nombre) {
            var query = from emp in db.empleos
                        where emp.nombre.Contains(nombre)
                        select new EmpleoBE
                        {
                            codigo = emp.codigo,
                            nombre = emp.nombre,
                            salario_minimo = emp.salario_minimo,
                            salario_maximo = emp.salario_maximo
                        };

            return query.ToList();
        }

        public List<EmpleoBE> ListarEmpleosPorRangoSalario(decimal salario_minimo, decimal salario_maximo)
        {
            var query = from emp in db.empleos
                        where emp.salario_minimo >= salario_minimo && emp.salario_maximo <= salario_maximo
                        select new EmpleoBE
                        {
                            codigo = emp.codigo,
                            nombre = emp.nombre,
                            salario_minimo = emp.salario_minimo,
                            salario_maximo = emp.salario_maximo
                        };

            return query.ToList();
        }

        public bool Actualizar (EmpleoBE objEmpleoBE)
        {
            var objEmpleo = (from emp in db.empleos
                            where emp.codigo.Equals(objEmpleoBE.codigo)
                            select emp).SingleOrDefault();

            objEmpleo.salario_minimo = objEmpleoBE.salario_minimo;
            objEmpleo.salario_maximo = objEmpleoBE.salario_maximo;
            objEmpleo.nombre = objEmpleoBE.nombre;

            db.SaveChanges();

            return true;
        }

        public bool Eliminar(int codigo)
        {
            var objEmpleo = (from emp in db.empleos
                             where emp.codigo.Equals(codigo)
                             select emp).SingleOrDefault();

            db.empleos.Remove(objEmpleo);
            db.SaveChanges();

            return true;
        }

        public EmpleoBE BuscarPorCodigo(int codigo)
        {
            var objEmpleoBE = (from emp in db.empleos
                               where emp.codigo.Equals(codigo)
                               select new EmpleoBE
                               {
                                   codigo = emp.codigo,
                                   nombre = emp.nombre,
                                   salario_minimo = emp.salario_minimo,
                                   salario_maximo = emp.salario_maximo
                               }).SingleOrDefault();

            return objEmpleoBE;
        }
    }
}
