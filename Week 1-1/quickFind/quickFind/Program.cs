using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickFind
{
    class Program
    {
        public class QuickFindUF
        {
            public int[] id;

            public QuickFindUF(int N)
            {
                id = new int[N];
                for (int i = 0; i < N; i++)
                {
                    id[i] = i;
                }
            }

            public bool connected(int p, int q)
            {
                return id[p] == id[q];
            }

            public void union(int p, int q)
            {
                int pid = id[p];
                int qid = id[q];
                for (int i = 0; i < id.Count(); i++)
                {
                    if (id[i] == pid)
                    {
                        id[i] = qid;
                    }
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
