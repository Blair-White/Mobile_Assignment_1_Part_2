using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mPlayerGeneral : MonoBehaviour
{
    public int ShootThrottle;
    private int ShootCount;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootCount++;
        if(ShootCount > ShootThrottle)
        {
            Instantiate(projectile, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), Quaternion.identity);
            ShootCount = 0;
        }

    }
}
