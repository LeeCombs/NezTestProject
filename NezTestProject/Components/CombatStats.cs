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

        #region Helpers

        /// <summary>
        /// Deal damage and returns the total damage dealt
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Total damage dealt</returns>
        public int DealDamage(int value) {
            // Apply defense
            int reducedDamage = value - Defense;
            if (reducedDamage <= 0)
                return 0;

            // Return whichever value is lower: current health or damageValue
            int damageDealt = _health > value ? _health : value;
            _health -= value;
            if (_health <= 0)
                _health = 0;
            return damageDealt;
        }

        #endregion
    }
}
