using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private int scorevalue;
    
    protected override void Die()
    {
        Debug.Log(gameObject.name + " died and player earned " + scorevalue + " points!");
        base.Die();
       // ScoreManager.instance.AddScore(scorevalue);
    }

}
