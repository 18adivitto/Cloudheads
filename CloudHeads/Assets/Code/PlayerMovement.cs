using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    CharacterController mover;
    Vector3 input;

    float speed = 10;

    public Vector3 lookDirection;



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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainGame");
        }
     
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

        if (Mathf.Abs(lookDirection.x) > 0 || Mathf.Abs(lookDirection.y) > 0)
        {
            angle = -(Vector3.SignedAngle(Vector3.up, lookDirection, transform.position));
            lookDirection = Vector3.ClampMagnitude(lookDirection, 1);
        }

        if (lookDirection.x < 0)
        {
            Debug.Log("flipped" + Time.deltaTime);

            angle = (Vector3.SignedAngle(Vector3.up, lookDirection, transform.position));
            lookDirection = Vector3.ClampMagnitude(lookDirection, 1);

        }
        else if (lookDirection.x > 0)
        {
            Debug.Log("not flipped" + Time.deltaTime);
            angle = -(Vector3.SignedAngle(Vector3.up, lookDirection, transform.position));
            lookDirection = Vector3.ClampMagnitude(lookDirection, 1);
        }
       
        

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * 30); //rotate
    }
}
