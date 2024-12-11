using System.Collections;
using UnityEngine;

public class PlayerWeaponAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _laserSprite;
    [SerializeField] private Transform _shooterPoint;

    private float _laserAnimationTime = 0.5f;

    private Vector3 _laserScale = new Vector3(2f, 3f, 1f);

    private void Awake()
    {
        _laserSprite.enabled = false;
    }

    public void PlayLaserAnimation()
    {
        StartCoroutine(AnimateLaser());
    }

    private IEnumerator AnimateLaser()
    {
        _laserSprite.enabled=true;
        _laserSprite.transform.position = _shooterPoint.position;
        _laserSprite.transform.localScale = new Vector3(0f, _laserScale.y, _laserScale.z);

        float elapsedTime = 0.0f;

        while (elapsedTime < _laserAnimationTime / 2)
        {
            elapsedTime += Time.deltaTime;
            float scale = Mathf.Lerp(0f, _laserScale.y, elapsedTime/ (_laserAnimationTime / 2));
            _laserSprite.transform.localScale = new Vector3(_laserScale.x, scale, _laserScale.z);

            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        elapsedTime = 0.0f;
        
        while(elapsedTime<_laserAnimationTime / 2)
        {
            elapsedTime += Time.deltaTime;
            float scale = Mathf.Lerp(_laserScale.y, 0f, elapsedTime / (_laserAnimationTime / 2));
            _laserSprite.transform.localScale = new Vector3(_laserScale.x, scale, _laserScale.z);

            yield return null;
        }

        _laserSprite.enabled = false ;
    }
}
