using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackingController : MonoBehaviour
{
    private Material mat;
    private Vector2 offset;
    public float xVelocity, yVelocity;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {

        mat.mainTextureOffset += offset * Time.deltaTime;
        
    }
}
