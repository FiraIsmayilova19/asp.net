using intro.entity;
using System.Collections.Generic;

namespace Intro.Models
{
    public class RestaurtantViewModel
    {
        public IEnumerable<Drink> Drink { get; set; }
        public IEnumerable<FastFood> FastFood { get; set; }
        public IEnumerable<HotMeal> HotMeal { get; set; }
    }
}
