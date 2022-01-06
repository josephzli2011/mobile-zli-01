using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public string doneScreen = "GameOver";
    Rigidbody rb;
    float horizontal = 0f;
    float vertical = 0f;
    public float speed = 10f;
    public Joystick joystick;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
        {
            joystick.gameObject.SetActive(false);
            horizontal = Input.GetAxisRaw("Horizontal") * speed;
            vertical = Input.GetAxisRaw("Vertical") * speed;
        }
        else
        {
            joystick.gameObject.SetActive(true);
            horizontal = joystick.Direction.x * speed;
            vertical = joystick.Direction.y * speed;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(doneScreen);
    }

    private void FixedUpdate()
    {
        rb.velocity = horizontal * transform.right + vertical * transform.forward;
    }
}
