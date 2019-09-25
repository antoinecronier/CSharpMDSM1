using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Class2
    {
        private int? id;

        [Key]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        private String item1;

        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public String Item1
        {
            get { return item1; }
            set { item1 = value; }
        }

        private Boolean item2;

        public Boolean Item2
        {
            get { return item2; }
            set { item2 = value; }
        }

        private DateTime item3;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Item3
        {
            get { return item3; }
            set { item3 = value; }
        }

        private Double item4;

        public Double Item4
        {
            get { return item4; }
            set { item4 = value; }
        }

        private Double? item4Bis;

        public Double? Item4Bis
        {
            get { return item4Bis; }
            set { item4Bis = value; }
        }

        private List<int> item5;

        public List<int> Item5
        {
            get { return item5; }
            set { item5 = value; }
        }

        private String[] item6;

        public String[] Item6
        {
            get { return item6; }
            set { item6 = value; }
        }

        private Dictionary<String,String> item7;

        public Dictionary<String,String> Item7
        {
            get { return item7; }
            set { item7 = value; }
        }

        private int? idClass1;
        
        public int? IdClass1
        {
            get { return idClass1; }
            set { idClass1 = value; }
        }

        private Class1 class1;

        [DisplayFormat(NullDisplayText = "No Class1")]
        [ForeignKey("IdClass1")]
        public Class1 Class1
        {
            get { return class1; }
            set { class1 = value; }
        }

        private int?[] class1sIds;

        public int?[] Class1sIds
        {
            get { return class1sIds; }
            set { class1sIds = value; }
        }

        private List<Class1> class1s;

        public List<Class1> Class1s
        {
            get { return class1s; }
            set { class1s = value; }
        }

        public Class2()
        {
            this.Class1s = new List<Class1>();
            this.Item5 = new List<int>();
            this.Item7 = new Dictionary<string, string>();
        }
    }
}