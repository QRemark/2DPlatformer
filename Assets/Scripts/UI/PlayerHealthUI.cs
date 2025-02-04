using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealthContainer _playerHealth;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Slider _percentHealthbar;
    [SerializeField] private Slider _gradualHealthbar;

    void Start()
    {
        _playerHealth.OnHealthChanged.AddListener(UpdateHealthText);
        UpdateHealthText(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);
    }

    private void UpdateHealthText(float currentHealth, float maxHealth)
    { 
        _healthText.text = $"{currentHealth} / {maxHealth}";
        _percentHealthbar.value = currentHealth / maxHealth;

        StopAllCoroutines();
        StartCoroutine(SmoothHealthChange(_percentHealthbar.value));
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
        _playerHealth.OnHealthChanged.RemoveListener(UpdateHealthText);
    }
}
