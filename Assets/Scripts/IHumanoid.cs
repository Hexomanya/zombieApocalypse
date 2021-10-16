using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    interface IHumanoid
    {
        public float maxHealth { get; set; }
        public float currentHealth { get; set; }
    }
}
