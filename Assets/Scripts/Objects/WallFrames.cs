using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFrames : BaseObject
{
    [SerializeField]
    List<GameObject> frames = new List<GameObject>();
    [SerializeField]
    List<GameObject> images = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var frame in frames)
        {
            int randomCheck = Random.Range(0, 10);

            if (randomCheck >= 8 && images.Count > 0)
            {
                int random = Random.Range(0, images.Count);
                Instantiate(images[random], frame.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
