using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController mover;
    Vector3 input;

    float speed = 10;

    Vector3 lookDirection;



    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();

        mover.Move(input * Time.deltaTime * speed); //move player

        PlayerLook();

     
    }

    void PlayerInputs()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void PlayerLook()
    {
       
        lookDirection = new Vector3(Input.GetAxis("RightJoyStickX"), Input.GetAxis("RightJoyStickY"));
        lookDirection = Vector3.ClampMagnitude(lookDirection, 1);
        
        if (Mathf.Round(lookDirection.x) == 0 && Mathf.Round(lookDirection.y) == 0)
        {
            lookDirection.x = 0;
            lookDirection.y = 0;
        }
        angle = -(Vector3.SignedAngle(Vector3.up, lookDirection, transform.position));

        if (lookDirection.x < 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0,0, angle)); //rotate
    }
}
