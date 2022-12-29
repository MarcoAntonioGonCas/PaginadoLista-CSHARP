using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _095_Math
{
    internal class Program
    {
        static void LlenarEnum(List<int> enumerable,int min,int max)
        {
            for(int i=min;i<=max;i++)
            {
                enumerable.Add(i);
            }
        }
        static void Main(string[] args)
        {

            List<int> list = new List<int>();


            LlenarEnum(list, 1, 101);



            PageList<int> listPaginada = list.ToPageList(10);
            
            int pagina;
            

            do
            {
                Console.WriteLine("0.- Salir");


                for (int i = 0; i < listPaginada.TotalPaginas; i++)
                {
                    Console.WriteLine($"Pagina {i + 1}");
                }
                Console.Write("Selecciona la pagina: ");
                pagina = Convert.ToInt32(Console.ReadLine());

                if(pagina >0&& pagina <= listPaginada.TotalPaginas)
                {
                    Console.Clear();
                    Console.WriteLine("\tMostrando paginado\n");
                    List<int> lstCortada = listPaginada.ObtenerPaginado(pagina).ToList();
                    lstCortada.ForEach(item =>
                    {
                        Console.WriteLine(item);
                    });
                    Console.WriteLine("\n=======================\n");
                }

            } while (pagina != 0);


        }
    }
}
