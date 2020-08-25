using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int healthMaxTop = 5; 
    public int maxHealth;
    public static int vidasTop = 2;
    public static int vidasActuales;
    public static int currentHealth;
    public GameObject player;
    public Slider healthBar;
    public Text vidasText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        vidasActuales = vidasTop;
             
        

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
        vidasText.text = vidasActuales.ToString();
        //Debug.Log(currentHealth);

        if (currentHealth == 0 && vidasActuales > 0)
        {

            vidasActuales--;
            currentHealth = healthMaxTop;
            Debug.Log(vidasActuales);


        }
        else
        {
            GameOver();
        }

              

       
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

    }
    public void HealthPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    } 
    public void VidaPlayer(int vidaAmount)
    {
        vidasTop += vidaAmount;
        if (vidasActuales > vidasTop)
        {
            vidasActuales = vidasTop;
        }
    }
    public void GameOver()
    {
        if (currentHealth == 0 && vidasActuales == 0)
        {
            print("GameOver");
            
        }
    }
    
}
