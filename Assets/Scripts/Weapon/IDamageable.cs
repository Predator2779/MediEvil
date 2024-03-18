using Character.ValueStorages;

namespace Weapon
{
    public interface IDamageable
    {
        public void DoDamage(Health health, float damage);
    }
}