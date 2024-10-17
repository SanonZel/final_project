using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private const float Jump_Speed = 10.0f;
    private const float MovementSpeed = 3.0f;
    private const float FallTime = 1.3f;

    private float CurrentTimeFall = 0.0f;
    private int jumpCount = 0;
    private Coroutine resetJump;


    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Animator _anim;
    [SerializeField] private ScoreManager scoreManager;

    [Header("Audio Components:")]
    [SerializeField] private AudioClip _jumpAudio;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Rigidbody2D PlayerRb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Batuts batuts = collision.gameObject.GetComponent<Batuts>();
        if (batuts != null)
        {
            DoJump();
            if (batuts.isPassed == false)
            {
                batuts.GetComponent<SpriteRenderer>().color = Color.red;
                scoreManager.OnAddScore();
                batuts.IsPlatformTrigger();  
            }
        }
    }

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        InitCamera();
        _spriteRenderer.material.color = Color.green;

    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(hor, 0f) * MovementSpeed * Time.deltaTime);
        CurrentTimeFall += Time.deltaTime;
        if (hor < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (hor > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount < 1)
            {
                DoJump();
                jumpCount++;
                if (resetJump != null)
                {
                    StopCoroutine(resetJump);
                }
                resetJump = StartCoroutine(AwaitJumpCount());
            }
        }

    }
    private void InitCamera()
    {
        CameraPlease cameraPlease = Camera.main.GetComponent<CameraPlease>();
        if (cameraPlease != null)
            cameraPlease.SetTarget(transform);
    }

    private void DoJump()
    {
        float hor = PlayerRb.velocity.x;
        PlayerRb.velocity = new Vector2(hor, Jump_Speed);
        _anim.SetTrigger("on_jump");
        _particle.Play();
        if (_audioSource.isPlaying) return;

        _audioSource.clip = _jumpAudio;
        _audioSource.Play();
    }
    private IEnumerator AwaitJumpCount()
    {
        _spriteRenderer.material.color = Color.red ;
        yield return new WaitForSeconds(5f); 
        jumpCount = 0;

        _spriteRenderer.material.color = Color.green ;
    }
}
