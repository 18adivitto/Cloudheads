using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    Vector3 gizmoPoint;

    Color debugColor;

    public GameObject explosion;

    public static Transform player1LockPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit.collider != null)
        {
            //Debug.Log(hit.point);
            gizmoPoint = hit.point;

           
        }

        if (Input.GetButton("shoot"))
        {
            Debug.Log("bang!");
            Instantiate(explosion, hit.point, Quaternion.identity);
            debugColor = Color.green;
        }
        else
        {
            debugColor = Color.red;
        }

        

    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = debugColor;
        Gizmos.DrawRay(new Ray(transform.position, transform.up));

        Gizmos.DrawWireSphere(gizmoPoint, .2f);

        
    }


}
