using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] CharacterStats character;

    public event Action<int> OnHealthChange;
    public event Action OnDie;

    private int life;
    private DateTime lastTimeDamage;

    public int Life
    {
        get { return life; }

        set
        {
            if (life < 0) return;
            life = value;
            OnHealthChange?.Invoke(life);

            if (life <= 0) OnDie?.Invoke();
        }
    }   

    public bool IsFullLife()
    {
        return life == character.fullLife;
    }
    public float GetLifeNormalized()
    {
        return (float)life /character.fullLife;
    }
    void Start()
    {
        Life = character.fullLife;
    }

    public bool TakeDamage(int amount)
    {
        if (!CanTakeDamage()) return true;            
        
        this.Life -= amount;

        lastTimeDamage = DateTime.UtcNow;
        return true;
    }

    public bool CanTakeDamage()
    {
        if(!character.invulnerable) return true;

        if(character.timeBetweenDamage > 0)
        {
            TimeSpan timeSpan = DateTime.UtcNow - lastTimeDamage; 
            return timeSpan.TotalSeconds > character.timeBetweenDamage;
        }

        return true;
    }

}
