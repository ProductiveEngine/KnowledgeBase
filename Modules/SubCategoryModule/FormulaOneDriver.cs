using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubCategoryModule
{
    public class FormulaOneDriver
    {
        public string Name { get; set; }   
        public int TeamId { get; set; }
        public int PolePositions { get; set; }
        public DateTime LatestVictory { get; set; }

        public FormulaOneDriver()
        {
            this.Name = "<Name>";
        }
    }
}
