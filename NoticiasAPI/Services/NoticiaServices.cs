using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class NoticiaServices
    {
        private readonly NoticiaDBContext _noticiaDBContext;
        public NoticiaServices(NoticiaDBContext noticiaDBContext)
        {
            _noticiaDBContext = noticiaDBContext;
        }

        public List<Noticia> ObtenerNoticia()
        {
          var resultado = _noticiaDBContext.Noticia.Include(x => x.autor).ToList();
          return resultado;
        }



        public Boolean AgregarNoticia(Noticia _noticia)
        {
            try
            {
                _noticiaDBContext.Noticia.Add(_noticia);
                _noticiaDBContext.SaveChanges();

                return true;
            }
            catch (Exception error)
            {

                return false;
            }

            
        }


        public Boolean EditarNoticia(Noticia _noticia)
        {
            try
            {
                var noticiaBD = _noticiaDBContext.Noticia.Where(x => x.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBD.Titulo = _noticia.Titulo;
                noticiaBD.Descripcion = _noticia.Descripcion;
                noticiaBD.Contenido = _noticia.Contenido;
                noticiaBD.Fecha = _noticia.Fecha;
                noticiaBD.AutorID = _noticia.AutorID;
                _noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception error)
            {

                return false;
            }
        }

        public Boolean EliminarNoticia(int noticiaID)
        {
            try
            {
                var noticiaBD = _noticiaDBContext.Noticia.Where(x => x.NoticiaID == noticiaID).FirstOrDefault();
                _noticiaDBContext.Noticia.Remove(noticiaBD);
                _noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception error)
            {

                return false;
            }
        }

        public List<Autor> listadoAutor()
        {
            try
            {
                var autores = _noticiaDBContext.Autor.ToList();
                return autores;
            }
            catch (Exception)
            {
                return new List<Autor>();
                
            }
        }

    }
}
