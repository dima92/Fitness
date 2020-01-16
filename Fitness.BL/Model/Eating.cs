using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Приём пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> Foods { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var products = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (products == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[products] += weight;
            }
        }
    }
}
