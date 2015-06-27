using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickUnion
{
    class Program
    {
        public class QuickFindUF
        {
            public int[] id;
            public int[] sz;

            public QuickFindUF(int N)
            {
                id = new int[N];
                sz = new int[N];
                for (int i = 0; i < N; i++)
                {
                    id[i] = i;
                    sz[i] = 1;
                }
            }

            private int root(int i)
            {
                while (i != id[i])
                {
                    i = id[i];
                }
                return i;
            }

            public bool connected(int p, int q)
            {
                return root(p) == root(q);
            }

            public void union(int p, int q)
            {
                int i = root(p);
                int j = root(q);
                if (sz[i] < sz[j])
                {
                    id[i] = j;
                    sz[j] += sz[i];
                }
                else
                {
                    id[j] = i;
                    sz[i] += sz[j];
                }
            }

        }

        static void Main(string[] args)
        {
            var qu = new QuickFindUF(10);

            var line = Console.ReadLine();
            foreach (var par in line.Split(' '))
            {
                qu.union(int.Parse(par.Split('-')[0]), int.Parse(par.Split('-')[1]));
            }

            foreach (var _id in qu.id)
            {
                Console.Write(_id);
                Console.Write(" ");
            }

            Console.ReadLine();
        }
    }
}
