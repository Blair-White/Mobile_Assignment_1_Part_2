using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timedmovetomain : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count > 300)
        {
            SceneManager.LoadScene(0);
        }    
    }
}
