using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Blazor_Detalle
{
    public class MorasBLL
    {
        public static bool Guardar(Moras mora)
        {
            if(!Existe(mora.MoraId))
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Moras.Any(m => m.MoraId == id);
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

        private static bool Insertar(Moras mora)
        {
            Contexto contexto = new Contexto();
            bool insertado = false;

            try
            {
                contexto.Moras.Add(mora);
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

        private static bool Modificar(Moras mora)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId = {mora.MoraId}");

                foreach (var item in mora.MoraDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(mora).State = EntityState.Modified;
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
                var buscando = contexto.Moras.Find(id);
                
                if (buscando != null)
                {
                    contexto.Moras.Remove(buscando);//remover la entidad
                    eliminado = contexto.SaveChanges() > 0;
                }
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

        public static Moras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Moras mora = new Moras();
            
            try
            {
                mora = contexto.Moras
                    .Where(m => m.MoraId == id)
                    .Include(m => m.MoraDetalle)
                    .FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return mora;
        }


        public static List<Moras> GetList(Expression<Func<Moras, bool>> mora)
        {
            Contexto contexto = new Contexto();
            List<Moras> listado = new List<Moras>();

            try
            {
                listado = contexto.Moras.Where(mora).ToList();
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