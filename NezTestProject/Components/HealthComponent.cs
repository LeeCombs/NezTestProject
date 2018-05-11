
namespace NezTestProject {
    public class HealthComponent : Nez.Component {
        int _health, _maxHealth;

        public HealthComponent(int value) {
            _health = value;
            _maxHealth = _health;
        }

        public int damage(int value) {
            int damageDealt = _health > value ? _health : value;

            _health -= value;
            if (_health <= 0)
                entity.destroy();

            return damageDealt;
        }
    }
}
