using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = 0.1f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }

        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);   
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
