using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroys the empty gameobject when it spawns in
        Destroy(gameObject);
    }
}
