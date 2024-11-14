using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private float speed = 5;
    [SerializeField] private float speedRotation = 10;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject riffle;
    [SerializeField] private GameObject pistol;
    [Space] [SerializeField] private PlayerAimState playerAimState;
    
    private void Start()
    {
        joystick.OnIsPointerDown += Walking;
        joystick.OnIsPointerUp += Idle;
    }

    void Update()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        Vector3 moveVector = new Vector3(h, 0, v);
        Vector3 translate = transform.position + moveVector * Time.deltaTime * speed;
        transform.position = translate;

        if (moveVector != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchWeaponPistol();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwitchWeaponRiffle();
        }
    }

    private void Walking()
    {
        _animator.SetBool(playerAimState.ToString(), true);
    }

    private void Idle()
    {
        _animator.SetBool(playerAimState.ToString(), false);
    }

    private void SwitchWeaponPistol()
    {
        // _animator.SetBool("SwitchWeapon", true);
        // _animator.SetBool("IsPistolRun", true);
        _animator.SetTrigger("SwitchWeapon");
        //_animator.SetBool(playerAimState.ToString(), false);
        playerAimState = PlayerAimState.IsPistolRun;
        riffle.SetActive(false);
        pistol.SetActive(true); 
    }
    private void SwitchWeaponRiffle()
    {
        // _animator.SetBool("SwitchWeapon", false);
        // _animator.SetBool("IsPistolRun", false);
        _animator.SetTrigger("SwitchWeapon");
        //_animator.SetBool(playerAimState.ToString(), false);
        playerAimState = PlayerAimState.IsRiffleRun;
        riffle.SetActive(true);
        pistol.SetActive(false); 
    }
}

public enum PlayerAimState
{
    IsPistolRun,
    IsRiffleRun
}