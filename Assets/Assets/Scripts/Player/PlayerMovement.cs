using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerStatus status;
    PlayerHealthHandler playerHealthHandler;
    public Rigidbody2D rbPlayer;
    public Vector3 direction;
    public Vector3 directionKnockedBack;

    private PlayerAimWeapon playerAim;
    public bool isShooting = false;
    public Vector3 KnockBackDir;
    public float knockBackForce;
    // Start is called before the first frame update
    [SerializeField] public AudioClip steepFootAudio;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        status = GetComponent<PlayerStatus>();
        rbPlayer = GetComponent<Rigidbody2D>();
        playerHealthHandler = GetComponent<PlayerHealthHandler>();
        playerAim = GameObject.Find("RotatePoint").GetComponent<PlayerAimWeapon>();
    }

    float stepSoundFrec = 0.25f;
    float stepSoundFrecCount = 0.25f;
    // Update is called once per frame
    void Update()
    {

        if (isMoving)
        {
            stepSoundFrecCount -= Time.deltaTime;
            if (stepSoundFrecCount <= 0)
            {
                stepSoundFrecCount = stepSoundFrec;
                SoundController.instance.PlaySound(steepFootAudio);
            }
        }
        else
        {
            stepSoundFrecCount = 0f;
        }

        if (playerStats.life <= 0)
        {
            Destroy(this);
        }
        float horizontalMoveInput;
        float verticalMoveInput;
        //condicional para el debuffo de controles invertidos
        if (!status.isConfused) {
             horizontalMoveInput = Input.GetAxisRaw("Horizontal");
             verticalMoveInput = Input.GetAxisRaw("Vertical");
        }
        else {
            horizontalMoveInput = -Input.GetAxisRaw("Horizontal");
            verticalMoveInput = -Input.GetAxisRaw("Vertical");
        }

        direction = new Vector2(horizontalMoveInput, verticalMoveInput).normalized;

        //Retroceso en cada arma
        if (GameManager.instance.currentWeaponID == 0)
        {
            knockBackForce = 300f;
        }
        else if (GameManager.instance.currentWeaponID == 1)
        {
            knockBackForce = 700f;

        }
        else if (GameManager.instance.currentWeaponID == 2)
        {
            knockBackForce = 0f;

        }

    }

    bool isMoving = false;
    
    private void FixedUpdate()
    {
       transform.position += direction * playerStats.speed * Time.fixedDeltaTime;

        if(direction.magnitude != 0)
        {
            if(!isMoving)
            {
                //FoostepsSound.instance.StartPlayFoostepSound();
                isMoving = true;
            }
        }else
        {
            if(isMoving)
            {
                //FoostepsSound.instance.StopMoveSound();
                isMoving = false;
            }
        }

        if (isShooting && knoickingBack)
        {
            if(KnockBackDir.magnitude == 0)
                KnockBackDir = (gameObject.transform.position - playerAim.mousePos).normalized;
            rbPlayer.AddForce(KnockBackDir * knockBackForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }else
        {
            KnockBackDir = Vector2.zero;
        }
    }

    bool knoickingBack = false;
    public void KnockBack(float duration)
    {
        StartCoroutine(KnockBackRoutine(duration));

    }
    IEnumerator KnockBackRoutine(float duration)
    {
        knoickingBack = true;
        yield return new WaitForSeconds(duration);
        knoickingBack = false;
    }
}
