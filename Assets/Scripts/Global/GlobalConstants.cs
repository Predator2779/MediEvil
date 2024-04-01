using UnityEngine;

namespace Global
{
    public static class GlobalConstants
    {
        // Damage
        public const float KnockdownDamage = 12;
        public const float VelocityDamageCoef = 0.5f;

        // Move Speed
        public const float CoefPersonSpeed = 1;
        public const float HorizontalJumpCoef = 0.5f;
        public const float HorizontalFallMoveSpeed = CoefPersonSpeed;
        public const float FallSpeed = 0.2f;

        // Anims
        public const float SpeedCrossfadeAnim = 0;
        public const float AnimDelay = 0.45f;
        
        // Ground Offsets
        public const float MaxGroundOffset = 0.2f;
        public const float CollisionOffset = 0.05f;
        public const float PointOffset = 0.05f;
        
        // Stamina
        public const float RunStaminaUsageCoef = 0.8f;
        public const float JumpStaminaUsageCoef = 50;
        public const float RollStaminaUsageCoef = 20;
        
        // Colldowns
        public const int SlideCooldown = 1000;
        public const int FallDownDelay = 1500;

        // Saves
        public static Vector2 StartPointPosition = new Vector2(-49.75f, -0.58f);

        // AI
        public const int RollChanceAI = 35;
    }
}