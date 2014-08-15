using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public int FlashLightCharge = 100;
    public float healthBarLength;

    public static float FlashLightIntensity = 0.8f; 
    float AddTimeFlashLight;
    float AddTimeFlashLightLowCharge;
    float AddTime;
    public Light Light1;
    public Light Light2;

    void Start()
    {
        AddTimeFlashLight = Time.time + 5;
        healthBarLength = Screen.width / 2;
        //AddTimeFlashLightLowCharge = Time.time;
    }

    void Update()
    {
        AddjustCurrentHealth(0);
        AddjustFlashLightBar();
    }


    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
        GUI.Box(new Rect(Screen.width / 2 + 500, Screen.height / 2 - 300, 100, 20), FlashLightCharge + " %");
    }


    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }


    void AddjustFlashLightBar()
    {
        //Light1.intensity = FlashLightIntensity;
        //Light2.intensity = FlashLightIntensity+5;

        float b = FlashLightIntensity;
        if (FlashLightCharge <= 30 && FlashLightCharge >= 1)
        {
            if (Time.time < AddTimeFlashLightLowCharge)
            {

                b = FlashLightIntensity;
                Light1.intensity = 0;
                Light2.intensity = 0;

            }
            else
            {
                if(AddTime <Time.time)
                {
                float a = Random.Range(0.1f, 1.5f);
                AddTimeFlashLightLowCharge = Time.time + a;
                AddTime = Time.time + Random.Range(FlashLightIntensity > 20 ? 1.5f:0.5f , 2);
                }

                Light1.intensity = FlashLightIntensity;
                Light2.intensity = FlashLightIntensity+5;
            }
        }
        if (Time.time > AddTimeFlashLight)
        {
            FlashLightCharge -= 10;
            if (FlashLightCharge <= 50 && FlashLightCharge >= 30)
            {
                FlashLightIntensity -= 0.05f;
                Light1.intensity = FlashLightIntensity;
                Light2.intensity -= FlashLightIntensity;
            }
            
            AddTimeFlashLight = Time.time + 5;
        }
    }
}