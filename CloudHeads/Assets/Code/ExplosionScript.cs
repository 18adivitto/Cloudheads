using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DieDieDie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DieDieDie()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(this.gameObject);
    }
}
