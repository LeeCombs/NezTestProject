namespace NezTestProject {
    class CombatStats : Nez.Component {

        int _health, _maxHealth;
        public int Health {
            get { return _health; }
            set {
                // Enforce caps
                _health = value > 0 ? value : 0;
                if (_health > _maxHealth)
                    _health = _maxHealth;
            }
        }

        int _strength;
        public int Strength {
            get { return _strength; }
            set { _strength = value > 0 ? value : 0; }
        }

        int _defense;
        public int Defense {
            get { return _defense; }
            set { _defense = value > 0 ? value : 0; }
        }

        public CombatStats(int health, int strength, int defense) {
            _health = health;
            _maxHealth = _health;
            _strength = strength;
            _defense = defense;
        }
    }
}
