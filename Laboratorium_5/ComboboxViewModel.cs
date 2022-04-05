using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Laboratorium_5
{
    public class ComboboxViewModel
    {
        public List<string> choiceCollection { get; set; }
        public List<Brush> brushCollection { get; set; }


        public ComboboxViewModel()
        {
            choiceCollection = new List<string> {
                "Yes",
                "No"
            };
            brushCollection= new List<Brush> {
                Brushes.Green,
                Brushes.Red
            };
        }
    }
}
