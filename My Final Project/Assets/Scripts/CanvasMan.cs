using UnityEngine;
using UnityEngine.UI;
using TMPro;


   public class CanvasMan : MonoBehaviour
   {
        public TextMeshProUGUI health;
        public TextMeshProUGUI armor;
        public TextMeshProUGUI ammo; 

        public Image HealthNum;

        public Sprite health1; //fine
        public Sprite health2;
        public Sprite health3;
        public Sprite health4;  //dead


        private static CanvasMan _instance;
        public static CanvasMan Instance 
        {
            get {return _instance;}
            
        }

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);

            }
            else
            {
                _instance = this; 
            }


        }


    public void UpdateHealth(int healthValue)
    {
        health.text= healthValue.ToString() + "%";
        UpdateHealthNum(healthValue);

    }
     public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
       
    }
     public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }


    public void UpdateHealthNum(int healthValue)
    {
            if(healthValue >= 66)
        {
            HealthNum.sprite = health1;

        }
        if(healthValue < 66 && healthValue >= 33)
        {
            HealthNum.sprite = health2;

        }
        if(healthValue < 33 && healthValue >= 0)
        {
            HealthNum.sprite = health3;

        }
        if(healthValue <= 0)
        {
            HealthNum.sprite = health4;

        }
    }


   }
