using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform weaponpoint;
    public LineRenderer lineRenderer;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           StartCoroutine(Shoot());
            lineRenderer.enabled = true;
           

        }else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            lineRenderer.enabled = false;
        }
    }
    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(weaponpoint.position, weaponpoint.right);
        if(hitInfo)
        {
           EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();
            if(enemy != null)
            {
                enemy.TakeDamage(40);
            }
            lineRenderer.SetPosition(0, weaponpoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }else
        {
            lineRenderer.SetPosition(0, weaponpoint.position);
            lineRenderer.SetPosition(1, weaponpoint.position + weaponpoint.right * 100);
        }
        
        yield return new WaitForSeconds(0f);
        

    }
}
