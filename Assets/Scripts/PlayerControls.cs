using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float rotateSpeed = 0.8f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody rb;
    private Transform playerCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>().transform;

        // Запрещаем Rigidbody движение под воздействием Physics
        rb.freezeRotation = true;

        // Скрыть курсор
        Cursor.visible = false;

        // Зафиксировать курсор в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        playerCamera.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
        moveDirection = transform.TransformDirection(moveDirection);

        if (IsGrounded())
        {
            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
            else moveDirection.y = rb.velocity.y; // Сохраняем вертикальную скорость
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        rb.velocity = moveDirection;
    }

    private bool IsGrounded()
    {
        // Простая проверка на соприкосновение с землёй
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
//using UnityEngine;

//public class PlayerControls : MonoBehaviour
//{
//    public float speed = 6.0f;
//    public float jumpSpeed = 8.0f;
//    public float rotateSpeed = 0.8f;
//    public float gravity = 20.0f;

//    private Vector3 moveDirection = Vector3.zero;

//    private CharacterController controller;
//    private Transform playerCamera;

//    private void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        playerCamera = GetComponentInChildren<Camera>().transform;
//    }

//    void Update()
//    {
//        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

//        playerCamera.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
//        if (playerCamera.localRotation.eulerAngles.y != 0)
//        {
//            playerCamera.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
//        }

//        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);
//        moveDirection = transform.TransformDirection(moveDirection);

//        if (controller.isGrounded)
//        {
//            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
//            else moveDirection.y = 0;
//        }

//        moveDirection.y -= gravity * Time.deltaTime;
//        controller.Move(moveDirection * Time.deltaTime);
//    }
//}