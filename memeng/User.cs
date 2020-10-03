using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memeng
{
    class User
    {
        static string id, firstname;

        public static string Id { get => id; set => id = value; }
        public static string Firstname { get => firstname; set => firstname = value; }
    }
}
