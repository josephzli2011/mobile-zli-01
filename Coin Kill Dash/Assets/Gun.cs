using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunTip;
    public float rapidFireSecs = 0.5f;
    float timer;
    float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = rapidFireSecs;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextTime)
        {
            Shoot();
            nextTime = nextTime + rapidFireSecs;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
        Destroy(bullet, 3f);
    }
}
