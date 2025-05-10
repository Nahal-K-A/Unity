using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip jump;
    public AudioClip crash;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    private Animator anime;
    private Rigidbody playerRb;
    private bool isOnGround = true;
    public bool gameOver = false;
    private float gravityModifier = 2.5f;
    public float jumpForce;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        // Don't change Physics.gravity globally
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anime.SetTrigger("Jump_trig");
            dirt.Stop();
            audio.PlayOneShot(jump, 1.0f);
        }
        if (gameOver == true)
        {
            dirt.Stop();
        }
    }

    void FixedUpdate()
    {
        // Apply custom gravity manually
        playerRb.AddForce(Physics.gravity * (gravityModifier - 1), ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.Translate(Vector3.back * 0.1f);
            Debug.Log("Game Over");
            gameOver = true;
            anime.SetBool("Death_b", true);
            anime.SetInteger("DeathType_int", 1);
            explosion.Play();
            audio.PlayOneShot(crash, 2.0f);
        }
    }
}

