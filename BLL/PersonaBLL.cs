using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Blazor_Detalle.Models;
using Blazor_Detalle.DAL;

namespace Blazor_Detalle.BLL
{
    public class PersonaBLL
    {
        public static bool Guardar(Persona persona)
        {
            if(!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Persona.Any(p => p.PersonaId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(Persona persona)
        {
            Contexto contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Persona.Add(persona);
                insertado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return insertado;
        }

        public static bool Modificar(Persona persona)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var buscando = contexto.Persona.Find(id);
                contexto.Entry(buscando).State = EntityState.Deleted;
                eliminado = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona persona = new Persona();

            try
            {
                persona = contexto.Persona.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return persona;
        }


        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            Contexto contexto = new Contexto();
            List<Persona> listado = new List<Persona>();

            try
            {
                listado = contexto.Persona.Where(persona).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listado;
        }
    }
}