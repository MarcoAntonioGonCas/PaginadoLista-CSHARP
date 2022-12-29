using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _095_Math
{
    public class PageList<T>:IEnumerable<T>
    {

        public PageList(IEnumerable<T> enumElementos,int elementosPorPagina) {

            this.enumElementos = enumElementos;
            
            this.elementosPorPagina = elementosPorPagina;
            this.totalElementos = enumElementos.Count();
            this.totalPaginas = CalcularTotalPaginas(totalElementos, elementosPorPagina);
            this.paginaActual = 1;

        }
        

        #region Helpers
        private int CalcularTotalPaginas(int totalElementos,int elementosPorPagina)
        {
            return (int)Math.Ceiling((double)totalElementos / (double)elementosPorPagina);
        }

#endregion
        public IEnumerable<T> ObtenerPaginado(int pagina)
        {
            if(pagina < 1 || pagina>this.totalPaginas)
            {
                throw new IndexOutOfRangeException(nameof(pagina));
            }    

            int elementosPasado = (pagina - 1) * elementosPorPagina;

            return this.Skip(elementosPasado).Take(elementosPorPagina);

        }
        public IEnumerator<T> GetEnumerator()
        {
            return enumElementos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumElementos.GetEnumerator();
        }


        private int totalPaginas;
        private int paginaActual;
        private int elementosPorPagina;
        private int totalElementos;
        private IEnumerable<T> enumElementos;



        public int TotalPaginas
        {
            get => totalPaginas;
        }

        public int PaginaActual
        {
            get => paginaActual;
        }


    }

    public static class PageListExtensio
    {
        public static PageList<T> ToPageList<T>(this IEnumerable<T> enumerable,int elementosPorPagina)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }
            if (elementosPorPagina < 1)
            {
               throw new IndexOutOfRangeException($"El numeor de elementos no puede ser menor a 1 {nameof(elementosPorPagina)}");
            }




            var page = new PageList<T>(enumerable, elementosPorPagina);


            return page;
        }
    }
}
