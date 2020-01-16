﻿using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name">Имя пола</param>

        public Gender() { }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}