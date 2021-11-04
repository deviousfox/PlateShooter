using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    [SerializeField] private Transform targetTrasform;
    [SerializeField] private Transform[] spawnTrasforms;
    [SerializeField] private Rigidbody Plate;
    [SerializeField] private float throwForce = 10;
    public void Spawn()
    {
        Rigidbody rb =  Instantiate(Plate, spawnTrasforms[Random.Range(0, spawnTrasforms.Length)].position, Quaternion.identity);
        rb.AddForce(( targetTrasform.position- rb.position).normalized * throwForce, ForceMode.Impulse);
        FindObjectOfType<AimingComponent>().SetTarget(rb.GetComponent<PlateComponent>());
    }
}
