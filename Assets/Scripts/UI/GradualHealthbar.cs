using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GradualHealthbar : MonoBehaviour
{
    [SerializeField] private PlayerHealthContainer _playerHealth;
    [SerializeField] private Slider _gradualHealthbar;

    private void Start()
    {
        _playerHealth.HealthChanged += UpdateGradualHealthbar;
        UpdateGradualHealthbar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);
    }

    private void UpdateGradualHealthbar(float currentHealth, float maxHealth)
    {
        float targetValue = currentHealth / maxHealth;
        StopAllCoroutines();
        StartCoroutine(SmoothHealthChange(targetValue));
    }

    private IEnumerator SmoothHealthChange(float targetHealth)
    {
        float startValue = _gradualHealthbar.value;
        float elapsedTime = 0f;
        float animationTime = 1f;

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime / animationTime;
            _gradualHealthbar.value = Mathf.Lerp(startValue, targetHealth, elapsedTime);

            yield return null;
        }

        _gradualHealthbar.value = targetHealth;
    }

    private void OnDestroy()
    {
        _playerHealth.HealthChanged -= UpdateGradualHealthbar;
    }
}
