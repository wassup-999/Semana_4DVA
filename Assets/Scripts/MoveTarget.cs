using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
public class MoveTarget : MonoBehaviour
{
    public InputActionAsset ActionAsset;
    private InputAction m_playerMove;
    private InputAction m_leftMousePress;
    private InputAction m_scrollHeight;

    private Vector2 m_position;
    private Vector2 m_height;

    private float m_minHeight = 10f;
    public float ZoomSpeed = 3;

    public CinemachineCamera MovingCamera;
    public CinemachineCamera RotateCamera;
    private void OnEnable()
    {
        ActionAsset.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        ActionAsset.FindActionMap("Player").Disable();
    }
    void Start()
    {
        m_playerMove = ActionAsset.FindAction("Move");
        m_leftMousePress = ActionAsset.FindAction("Attack");
        m_scrollHeight = ActionAsset.FindAction("Scroll");
    }

    
    void Update()
    {
        m_position = m_playerMove.ReadValue<Vector2>();
        if(transform.position.y > m_minHeight)
        {
            m_height = m_scrollHeight.ReadValue<Vector2>();           
        }
        else
        {
            m_height.y = m_minHeight;
        }
        transform.Translate(m_position.x , m_height.y * ZoomSpeed , m_position.y);
        if(m_leftMousePress.WasPressedThisFrame())
        {
            RotateCamera.Priority = 2;           
        }
        if(m_leftMousePress.WasReleasedThisFrame())
        {
            RotateCamera.Priority = 0;
        }
    }
}
