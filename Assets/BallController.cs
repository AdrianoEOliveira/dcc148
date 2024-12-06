using UnityEngine;

public class BallController : MonoBehaviour
{
    // Velocidade de movimento horizontal
    public float velocidade= 5f;
    
    // Força de quique vertical
    public float gravidade = 10f;

    // Variáveis internas para o Rigidbody2D
    private Rigidbody2D rb;

    // Variáveis para o controle de movimento
    private float movimentoHorizontal;

    void Start()
    {
        // Pegando o componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float dx = Input.GetAxis("Horizontal"); 
    
        x+= dx *velocidade * Time.deltaTime;

        y+= gravidade * Time.deltaTime
        

        transform.position = new Vector2(x,y);

        if (transform.position.y <= -4f)
        {
            


        }


    }

    // Método para aplicar o movimento horizontal
    void MovimentoHorizontal()
    {
        // Calculando a velocidade horizontal com base no input do jogador
        rb.linearVelocity = new Vector2(movimentoHorizontal * velocidade, rb.linearVelocity.y);
    }

    // Método para aplicar o quique vertical
    void QuicarVertical()
    {
        // Aplicando uma força para cima para fazer a bola quicar (somente se a bola está se movendo para baixo)
        if (rb.linearVelocity.y <= 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaQuique);
        }
    }
}
