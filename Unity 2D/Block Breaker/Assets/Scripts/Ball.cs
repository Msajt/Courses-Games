using UnityEngine;
// COMENTAR O CÓDIGO DEPOIS
public class Ball : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] Paddle paddle1; // variavel para depositar objeto do tipo paddle
    [SerializeField] AudioClip[] ballSounds; // vetor de sons usados quando a bola atinge o bloco
    [SerializeField] float randomFactor = 0.2f; // float para evitar que a bola fique em loop infinito

    // Cached Component Reference, para audio e rigidbody
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // States
    Vector2 paddleToBallVector; // distancia entre o paddle e a bola
    bool hasStarted; // verifica se houve o clique do mouse para acionar a bola

    // Função Start()
    void Start()
    {
        hasStarted = false; // caso verdadeira irá acionar a bola
        paddleToBallVector = transform.position - paddle1.transform.position; // distancia entre a bola e o paddle
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enquanto não cliquei no mouse ainda
        if (!hasStarted)
        {
            LockBalltoPaddle(); // mantem a bola presa
            LaunchBallOnMouseClick(); // lança a bola
        } 
    }

    // Função para lançar a bola
    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true; // quando clica a função se torna verdadeira
            myRigidBody2D.velocity = new Vector2(2f, 15f); // lança a bola pra cima
        }
    }

    // Mantem a bola presa no paddle
    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    // Quando há colisão liga o som aleatório da bolinha
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), 
                                            Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
