using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    [Header("Joy")]

    [SerializeField] private Joystick _joy;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    private Vector2 targetVelocity;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();




    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Определяем бег
        if (GameController.instance.isDesktop)
        {
            IsRunning = canRun && Input.GetKey(runningKey);
        }
        else
        {
            IsRunning = canRun && _joy.Vertical >= 0.7f;
        }

        // Вычисляем скорость движения
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Получаем целевую скорость
        if (GameController.instance.isDesktop)
        {
            targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
        }
        else
        {
            targetVelocity = new Vector2(_joy.Horizontal * targetMovingSpeed, _joy.Vertical * targetMovingSpeed);
        }

        // Проверка на минимальный ввод для джойстика
        if (Mathf.Abs(targetVelocity.x) < 0.1f && Mathf.Abs(targetVelocity.y) < 0.1f)
        {
            targetVelocity = Vector2.zero;
        }

        // Обновляем скорость Rigidbody
        Vector3 moveDirection = transform.right * targetVelocity.x + transform.forward * targetVelocity.y;
        rigidbody.velocity = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.z);
    }

}