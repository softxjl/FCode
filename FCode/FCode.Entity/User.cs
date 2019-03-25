using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCode.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool Sex { get; set; }
    }

    public class Test
    {
        [Key]
        public int Id { get; set; }

        public int UserId{ get; set; }

        public string TestName { get; set; }
    }
}
