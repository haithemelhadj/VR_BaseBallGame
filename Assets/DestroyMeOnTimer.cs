using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeOnTimer : MonoBehaviour
{
    public float initTimer;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = initTimer;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0 )
        {
            Destroy(gameObject);
        }
    }
}
