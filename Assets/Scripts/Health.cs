using System;

public class Health
{
    public const float INVULNERABILITY_TIME = 5.0f;

    public event Action Die = delegate () { };
    public event Action HealthsChange = delegate () { };

    private bool _canChargeHealth;

    public int MaxHealth { get; }
    public int CurrentHealth { get; private set; }

    public bool CanChangeHealth => _canChargeHealth;

    public Health(int maxHealth)
    {
        _canChargeHealth = true;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void GetGamage(int damage)
    {
        if (CanChangeHealth)
        {
            _canChargeHealth = false;
            HealthsChange?.Invoke();
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Die?.Invoke();
            }
        }
    }

    public void GetHealth(int healValue)
    {
        CurrentHealth += healValue;
    }

    public void IsCanChangeHealth(bool value)
    {
        _canChargeHealth = value;
    }
}