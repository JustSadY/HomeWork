using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : GetStats
{
    private CinemachineImpulseSource cinemachineImpulseSource;
    public static Vector3 playerLocation;
    private Ray MousePositionRay;
    private Vector3 movement;
    public Weapon weapon;
    private float defaultSpeed;

    private void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        _Rigidbody = GetComponent<Rigidbody>();
        _Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        defaultSpeed = GetSpeed();
    }

    void Update()
    {
        if (Die()) return;
        MousePositionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        playerLocation = this.gameObject.transform.position;
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        Fire();
        SwitchRifle();
    }

    public void TakingDamage(float damage)
    {
        base.TakingDamage(damage);
        if (Die()) _Animator.SetBool("Death", true);
    }

    private void FixedUpdate()
    {
        Move(movement);
        RotateTowardsMouse(MousePositionRay);
    }

    private void SwitchRifle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon.SwitchWeapon(0);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon.SwitchWeapon(1);
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SetSpeed(7f);
            _Animator.SetBool("Shooting", true);
        }

        if (Input.GetButtonUp("Jump"))
        {
            SetSpeed(defaultSpeed);
            _Animator.SetBool("Shooting", false);
        }

        if (Input.GetButton("Jump") && weapon.CurrentWeapon != null && _Animator.GetBool("Shooting"))
        {
            weapon.CurrentWeapon.Fire(cinemachineImpulseSource);
        }
    }

    private void Move(Vector3 moveVector3)
    {
        if (movement.x != 0 || movement.z != 0)
        {
            _Animator.SetBool("Moving", true);
            _Rigidbody.linearVelocity = moveVector3 * GetSpeed();
        }
        else _Animator.SetBool("Moving", false);
    }

    private void RotateTowardsMouse(Ray mousePos)
    {
        if (Physics.Raycast(mousePos, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0;

            if (direction.sqrMagnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedTime * 10f);
            }
        }
    }
}