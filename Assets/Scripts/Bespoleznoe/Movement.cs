using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private float _speed=5;
    Rigidbody rb;
    Camera cam;

    public CharacterController CharacterController;
    private Vector3 _movementVector;

    private void Update()
    {
        float zInput = Input.GetAxis("Vertical");

        float xInput = Input.GetAxis("Horizontal");

        _movementVector = new Vector3(xInput, 1, zInput);

        _movementVector = _movementVector.normalized;
        //----------------------

        _movementVector.y *= -9.81f;
        CharacterController.Move(_movementVector * (_speed * Time.deltaTime));


        //Зависит от Rigidbody
       // ------------------------------------------

    //transform.Translate(_movementVector * (_speed * Time.deltaTime));
        //Не зависит от Rigidbody
       //------------------------------------------
}


}
