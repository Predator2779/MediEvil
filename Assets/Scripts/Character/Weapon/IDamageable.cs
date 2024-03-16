using Character.ValueStorages;

namespace Character.Weapon
{
    public interface IDamageable
    {
        public void DoDamage(Health health, float damage);
    }
}