using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_users
{
    class Program
    {
        static void Main(string[] args)
        {
            var dep = new Department();
            dep["u4"] = new User { ID = "u4", Name = "Ann" };
            var user = dep["u4"];
        }
        interface IFigure
        {
            double Area { get; }
        }
        class Circle:IFigure
        {
            public double Area
            {
                get;
                set;
            }
        }
    }
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Department
    {
        private User[] users =
        {
            new User{ID="u1", Name="Jhon"},
            new User{ID="u2",Name="smith"},
        };
        public User this[string id]
        {
            get
            {
                return users.FirstOrDefault(u => u.ID == id);
            }
            set
            {
                if (this[id] != null)
                {
                    users[2] = value;
                }
            }
        }
    }
}
