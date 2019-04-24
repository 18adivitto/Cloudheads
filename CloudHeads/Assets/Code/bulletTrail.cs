using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTrail : MonoBehaviour
{
    Vector3 startpos;
    Vector3 endpos;

    float radiusRange = .1f;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + new Vector3(Random.Range(-.3f, .3f), Random.Range(-.3f, .3f));
        endpos = CharacterAim.gizmoPoint;
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, endpos, Time.deltaTime * 30);

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
