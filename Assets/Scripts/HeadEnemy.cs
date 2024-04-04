using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float power;

    private void OnTriggerEnter(Collider collider)
    {
        if (!(collider.tag.Contains("1") || collider.tag.Contains("2") || collider.tag.Contains("3") || collider.tag.Contains("4") || collider.tag.Contains("5") || collider.tag.Contains("6") || collider.tag.Contains("7") || collider.tag.Contains("8") || collider.tag.Contains("9") || collider.tag.Contains("0")))
        {
            return;
        }

        rigidbody.isKinematic = false;
        rigidbody.AddForce(Vector3.up* power);
    }


}
