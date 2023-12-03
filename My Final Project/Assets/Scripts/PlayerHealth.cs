using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    private int health;
    // Start is called before the first frame update
    public int maxArmor;
    private int armor;


    void Start()
    {
        health = maxHealth;
        CanvasMan.Instance.UpdateHealth(health);
        CanvasMan.Instance.UpdateArmor(armor);

    }

    // Update is called once per frame
    void Update()
    {



      if(Input.GetKeyDown(KeyCode.RightShift))  
      {
        DamagePlayer(30);
        Debug.Log("player hurt");
      }
    }

    public void DamagePlayer(int damage)
    {

        if(armor > 0)
        {
            if(armor >= damage)
            {
                armor -= damage;
            }
            else if(armor < damage)
            {
                int remainingDamage;

                remainingDamage = damage - armor;

                armor = 0;

                health -= remainingDamage;
            }
        }
        
        else
        {
           health -= damage; 
        }

        if(health <= 0)
        {

            Debug.Log("Player dead");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        CanvasMan.Instance.UpdateHealth(health);
        CanvasMan.Instance.UpdateArmor(armor);

    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if(health < maxHealth)
        {
            health += amount; 
            Destroy(pickup);
        }

        if(health >maxHealth)
        {
            health = maxHealth;
        }

        CanvasMan.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
           if(armor < maxArmor)
        {
            armor += amount; 
            Destroy(pickup);
        }

        if (armor >maxArmor)
        {
            armor = maxArmor;
        }

        CanvasMan.Instance.UpdateArmor(armor);
    }
}
