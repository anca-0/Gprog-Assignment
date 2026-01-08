using UnityEngine;

public class PlayerHealth : Health
{
   public override void TakeDamage(float damage)
   {
       base.TakeDamage(damage);
    }

    protected override void Die()
    {
        base.Die();
    }
}
