using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] MovePaddle paddle;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomAngle = 0.2f;
    bool hasLauched = false;
    Vector2 distanceToPaddle;
    Rigidbody2D rigidBall;
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        distanceToPaddle = transform.position - paddle.transform.position;
        rigidBall = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLauched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLauched = true;
            rigidBall.velocity = new Vector2(velocityX, velocityY);

        }
    }

    private void LockBallToPaddle()
    {

        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        this.transform.position = paddlePos + distanceToPaddle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
                                (Random.Range(0, randomAngle), 
                                Random.Range(0, randomAngle));


        if (hasLauched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            rigidBall.velocity += velocityTweak;
        }
    }

    public bool HasStarted()
    {
        return hasLauched;
    }
}
