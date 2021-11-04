using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateComponent : MonoBehaviour
{
    public Vector3 position => transform.position;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            FindObjectOfType<AimingComponent>().LuckyShoot();

            Invoke(nameof(OnFall), 0.1f);
        }
    }

    public void OnFall()
    {
        FindObjectOfType<GroundCallback>().OnCallback();
    }
}
