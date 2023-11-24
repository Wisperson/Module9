using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(5);
            list.Add(true);
            list.Add("test");

            Queue<int> tay = new Queue<int>();
            for (int i = 0; i < 10;  i++)
            {
                tay.Enqueue(i);
            }
            Console.WriteLine("Queue: ");
            foreach (var item in tay)
            {
                Console.WriteLine(item);
            }

            //---------------

            Stack<int> st = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                st.Push(i);
            }
            foreach(var item in st)
            {
                Console.WriteLine(item);
            }

            //--------------

            Hashtable ht = new Hashtable();
            for (int i = 0; i < 10; i++)
            {
                if (!ht.ContainsKey(i)) { ht.Add(i, i); }
            }

            //----------------

            Dictionary<int, int> dck = new Dictionary<int, int>();

            //----------------

            List<student> students = new List<student>();
            students.Add(new student(0, "Ivan"));
            students.Add(new student(1, "Bober"));

        }
    }

    public class student
    {
        public int id { get; set; }
        public string name { get; set; }

        public student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
