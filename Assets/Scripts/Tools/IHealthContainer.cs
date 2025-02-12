using System;

public interface IHealthContainer
{
    public float MaxHealth { get; }
    public float CurrentHealth { get; }

    public event Action<float, float> HealthChanged;

    void Increase(float volume);

    void Reduce(float volume);
}
