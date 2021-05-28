using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerNeeds : MonoBehaviour, IDamagable
{
    public Need health;
    public Need power;

    public float noPowerHealthDecay;

    public UnityEvent onTakeDamage;

    void Start ()
    {
        // set the start values
        health.curValue = health.startValue;
        power.curValue = power.startValue;
    }

    void Update ()
    {
        // decay needs over time
        power.Subtract(power.decayRate * Time.deltaTime);

        // decay health over time if no power
        if(power.curValue == 0.0f)
            health.Subtract(noPowerHealthDecay * Time.deltaTime);

        // check if player is dead
        if(health.curValue == 0.0f)
        {
            Die();
        }

        // update UI bars
        health.uiBar.fillAmount = health.GetPercentage();
        power.uiBar.fillAmount = power.GetPercentage();
    }

    // adds to the player's health
    public void Heal (float amount)
    {
        health.Add(amount);
    }

    // adds to the player's power
    public void Eat (float amount)
    {
        power.Add(amount);
    } 

  
    // called when the player takes physical damage (enemy)
    public void TakePhysicalDamage (int amount)
    {
        health.Subtract(amount);
        onTakeDamage?.Invoke();
    }

    // called when the player's health reaches 0
    public void Die ()
    {
        Debug.Log("Player is dead");
    }
}

[System.Serializable]
public class Need
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    // add to the need
    public void Add (float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    // subtract from the need
    public void Subtract (float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    // return the percentage value (0.0 - 1.0)
    public float GetPercentage ()
    {
        return curValue / maxValue;
    }
}

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}