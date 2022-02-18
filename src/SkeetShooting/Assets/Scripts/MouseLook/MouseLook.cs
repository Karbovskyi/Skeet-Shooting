using SimpleInputNamespace;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Joystick _joystick;
    

    private float xRotation;

    void Update()
    {
        float mouseX =  _joystick.xAxis.value * _mouseSensitivity * Time.deltaTime;
        float mouseY = _joystick.yAxis.value * _mouseSensitivity * Time.deltaTime;
        
       // float mouseX =  Input.GetAxis("Horizontal") * _mouseSensitivity * Time.deltaTime;
       // float mouseY = Input.GetAxis("Vertical") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0,0 );
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}