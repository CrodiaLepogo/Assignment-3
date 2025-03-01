﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Module
    {
        private int code;
        private string name;
        private string description;
        private string resources;


        public Module() { }

        public Module(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public Module(int code, string name, string description, string resources)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.Resources = resources;
        }

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Resources { get => resources; set => resources = value; }
    }
}
