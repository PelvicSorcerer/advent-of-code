using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Elf
    {
        public Elf(List<int> calorieCounts)
        {
            foreach (var calorieCount in calorieCounts)
                Consumables.Add(new Consumable(calorieCount));
        }

        public List<Consumable> Consumables { get; } = new List<Consumable>();

        public int GetTotalCalories()
        {
            return Consumables.Sum(consumable => consumable.Calories);
        }
    }

    internal class Consumable
    {
        public Consumable(int calorieCount)
        {
            Calories = calorieCount;
        }

        public int Calories { get; }
    }
}
