﻿using System;
using System.Collections.Generic;

namespace P03.Detail_Printer
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Documents: " + string.Join(", ", this.Documents);
        }
    }
}
