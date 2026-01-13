using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private int scorevalue;
    
    protected override void Die()
    {
        //Debug.Log(gameObject.name + " died and player earned " + scorevalue + " points!");
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scorevalue);
            Debug.Log("added the points");
        }
        base.Die();
    }

}
