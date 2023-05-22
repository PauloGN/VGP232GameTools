using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 5f;
    public float minYAngle = -30f;
    public float maxYAngle = 70f;

    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 targetPosition = target.position - rotation * Vector3.forward * distance;

        transform.position = targetPosition;
        transform.LookAt(target);
    }
}
