using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float mouseSensivityX = 3f;
    
    [SerializeField]
    private float mouseSensivityY = 3f;
    
    private PlayerMotor _playerMotor;
    // Start is called before the first frame update
    void Start()
    {
        _playerMotor = GetComponent<PlayerMotor>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Move player
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector3 horizontalMove = transform.right * xMove;
        Vector3 verticalMove = transform.forward * yMove;

        Vector3 velocity = (horizontalMove + verticalMove).normalized * speed;
        
        _playerMotor.Move(velocity);

        //Rotate player
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensivityX;

        _playerMotor.Rotate(rotation);
        
        //Rotate cam
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0, 0) * mouseSensivityY;

        _playerMotor.RotateCamera(camRotation);
    }
}
