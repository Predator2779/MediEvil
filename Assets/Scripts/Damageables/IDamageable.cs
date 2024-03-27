using Character.ValueStorages;

namespace Damageables
{
    public interface IDamageable
    { 
        public void DoDamage(float personDamage);
        public void DoDamage(Health health, float concreteDamage);
    }
}