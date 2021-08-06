using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private bool moveright = true;
    public Transform groundDetect;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 2f);
        Debug.DrawRay(groundDetect.position, Vector2.down, Color.red);
        if (groundInfo.collider == false)
        {
            if (moveright)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveright = false;
            }
            else if (!moveright)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveright = true;
            }
        }
    }
}
