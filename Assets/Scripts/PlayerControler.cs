using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D _rBody;
    private Animator _animator;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Vector2 _moveInput;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _groundSensor;
    [SerializeField] private float _sensorRadius = 0.3f;

    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
    }

    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRun", true);
        }
        else if(_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }
        if(_jumpAction.WasPressedThisFrame() && IsGrauned())
        {
            Jump();
        }
        _animator.SetBool("IsJump", !IsGrauned());
    }

    void FixedUpdate()
    {
        _rBody.linearVelocityX = _moveInput.x * _moveSpeed;
    }

    void Jump()
    {
        _rBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrauned()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorRadius);

        foreach (Collider2D item in collider2Ds)
        {
            if(item.gameObject.layer == 6)
            {
                return true;
            }
        }
        return false;
    }
}
