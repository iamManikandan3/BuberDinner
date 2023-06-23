using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public MenuSection(MenuId menuSectionId, string name, string description) : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description);
        }
    }
}
