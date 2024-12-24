
using BrewedInk.CRT;
using UnityEngine;
using YG;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    private float sensitivity;
    public float smoothing = 1.5f;
    public TouchPanel cameraControllerPanel;
    float mouseX = 0;
    float mouseY = 0;


    Vector2 velocity;
    Vector2 frameVelocity;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {

        if (GameController.instance.isDesktop)
        {
            Cursor.lockState = CursorLockMode.Locked;
            sensitivity = 1;
        }
        else
        {
            GetComponent<CRTCameraBehaviour>().enabled = false;
            sensitivity = 0.5f;
        }
    }

    void Update()
    {
        if (GameController.instance.isDesktop)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }
        else
        {
            if (cameraControllerPanel.pressed)
            {
                
                foreach (Touch touch in Input.touches)
                {
                    if (touch.fingerId == cameraControllerPanel.fingerId)
                    {
                        if (touch.phase == TouchPhase.Moved)
                        {
                            mouseY = touch.deltaPosition.y;
                            mouseX = touch.deltaPosition.x;
                        }

                        if (touch.phase == TouchPhase.Stationary)
                        {
                            mouseY = 0;
                            mouseX = 0;
                        }
                    }
                }
                smoothing = 2;
                Vector2 mouseDelta = new Vector2(-mouseX, -mouseY);
                Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
                frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
                velocity += frameVelocity;
                velocity.y = Mathf.Clamp(velocity.y, -90, 90);

                // Rotate camera up-down and controller left-right from velocity.

            }
            else
            {
                // Обнуляем только frameVelocity, но сохраняем velocity
                frameVelocity = Vector2.zero;
            }
            
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }



    }
}
