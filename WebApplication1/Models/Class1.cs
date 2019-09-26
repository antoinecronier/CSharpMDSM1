using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class Class1
    {
        private int? id;

        [Key]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        private String data;

        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        private List<Class2> class2s;

        public List<Class2> Class2s
        {
            get { return class2s; }
            set { class2s = value; }
        }

    }
}