﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public class PC : Product
    {
        public PC() : base(1000.00f, 20.0f)
        {
        }

        public new float Price { get { return base.Price; } }
        public new float Tva { get { return base.Tva; } }
    }
}
