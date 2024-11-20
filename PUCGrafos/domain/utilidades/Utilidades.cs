using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PUCGrafos.domain.utilidades
{
    internal class Utilidades
    {
        public static int GetBinarySearchIndex<T>(T item, List<T> lista, ref bool found)
        {
            int index = lista.BinarySearch(item);
            
            found = (index >= 0);

            return (found) ? index : ~index;
        }

        public static int GetIDVerticeInterno(int id)
        {
            return id - 1;
        }

        public static int GetIDVerticeExterno(int id)
        {
            return id + 1;
        }
    }
}
