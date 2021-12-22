using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandRotate : MonoBehaviour
{
    public Joystick joystick;
    public Joystick aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isMobilePlatform)
        {
            aim.gameObject.gameObject.SetActive(true);
            if (aim.Vertical >= 0.05 || aim.Horizontal >= 0.05)
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(aim.Vertical, -aim.Horizontal) * 180 / Mathf.PI, 0);
        } else
        {
            aim.gameObject.SetActive(false);
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-angle + 180, Vector3.up);
        }
        
    }
}
