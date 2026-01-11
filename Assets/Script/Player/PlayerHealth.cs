using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
   public override void TakeDamage(float damage)
   {
        Debug.Log("Player took " + damage + " damage.");
        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        if(ScoreManager.instance != null)
        {
            PlayerPrefs.SetInt("LastScore", ScoreManager.instance.GetScore());
        }
        SceneManager.LoadScene("GAMEOVER");
        
        
    }
}
