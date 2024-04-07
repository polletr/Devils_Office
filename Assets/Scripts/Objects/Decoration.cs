using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : BaseObject
{
    [SerializeField]
    List<GameObject> objects = new List<GameObject>();

    private void Awake()
    {
        if (objects.Count > 0)
        {
            int randomObj = Random.Range(0, objects.Count);
            Instantiate(objects[randomObj], transform);
        }
    }

}
