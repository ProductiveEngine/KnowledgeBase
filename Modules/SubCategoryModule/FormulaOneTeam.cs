using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubCategoryModule
{
    public class FormulaOneTeam
    {
        /// <summary>
        /// The list of all Formula 1 Teams.
        /// </summary>
        private static Dictionary<int, FormulaOneTeam> getAll;

        /// <summary>
        /// Initializes static members of the FormulaOneTeam class.
        /// </summary>
        static FormulaOneTeam()
        {
            getAll = new Dictionary<int, FormulaOneTeam>()
                {
                    { 0, new FormulaOneTeam { TeamId = 0, Name = "Unknown" } },
                    { 1, new FormulaOneTeam { TeamId = 1, Name = "Nintendo" } },
                    { 2, new FormulaOneTeam { TeamId = 2, Name = "Top Gear" } },
                    { 3, new FormulaOneTeam { TeamId = 3, Name = "Wacky Races" } }
                };
        }

        /// <summary>
        /// Gets or sets the id of the Formula 1 Team.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Formula 1 Team.
        /// </summary>
        public string Name { get; set; }

        public static ObservableCollection<FormulaOneDriver> GetAll
        {
            get
            {
                ObservableCollection<FormulaOneDriver> drivers =
                    new ObservableCollection<FormulaOneDriver>()
                    {
                new FormulaOneDriver(){ Name = "Super Mario",
                                        TeamId = 1,
                                        PolePositions = 2 },
                new FormulaOneDriver(){ Name = "The Stig",
                                        TeamId = 2,
                                        PolePositions = 20,
                                        LatestVictory = DateTime.Today },
                new FormulaOneDriver(){ Name = "Dick Dastardley",
                                        TeamId = 3,
                                        PolePositions = 0 },
                new FormulaOneDriver(){ Name = "Luigi",
                                        TeamId = 1,
                                        PolePositions = 2 }
                    };

                return drivers;
            }
        }
       
    }
}
