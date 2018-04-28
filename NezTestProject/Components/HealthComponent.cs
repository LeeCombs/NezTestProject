using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NezTestProject.Components
{
    class HealthComponent : Nez.Component
    {
        int _health, _maxHealth;

        public HealthComponent(int value = 0)
        {
            _health = value;
            _maxHealth = _health;
        }
    }
}
