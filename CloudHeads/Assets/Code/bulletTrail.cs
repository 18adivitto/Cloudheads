using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTrail : MonoBehaviour
{
    Vector3 startpos;
    Vector3 endpos;

    float radiusRange = .2f;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        endpos = CharacterAim.gizmoPoint;
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, endpos, Time.deltaTime * 20);

        //if ((transform.position == endpos))
        //{
        //    //Debug.Log("boomer");
        //    Instantiate(explosion, transform.position, Quaternion.identity);
        //    Destroy(this.gameObject);
        //}

        if ((transform.position.x >= endpos.x - radiusRange && transform.position.x <= endpos.x + radiusRange) &&
            (transform.position.y >= endpos.y - radiusRange && transform.position.y <= endpos.y + radiusRange))
        {
            
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
