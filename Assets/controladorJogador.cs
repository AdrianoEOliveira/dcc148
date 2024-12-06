using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    private Light luzSpot;  // Componente de luz Spot

    public float velocidade = 0.001f;  // Velocidade de movimento da esfera

    // Start é chamado antes do primeiro frame
    void Start()
    {
        // Obtém o componente de luz Spot associado à esfera
        luzSpot = GetComponentInChildren<Light>();
        
        if (luzSpot == null)
        {
            Debug.LogError("Luz Spot não encontrada no objeto!");
        }
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Movimentação da esfera com as setas do teclado
        float movimentoX = Input.GetAxis("Horizontal");  // Movimento esquerdo/direito (setas para esquerda/direita)
        float movimentoY = Input.GetAxis("Vertical");    // Movimento para frente/trás (setas para cima/baixo)

        // Movimento da esfera com base na entrada do teclado
        Vector3 movimento = new Vector3(movimentoX, movimentoY, 0) * velocidade * Time.deltaTime;
        transform.Translate(movimento);

        // Opcional: Rotacionar a esfera com base na direção de movimento
        if (movimento.magnitude > 0)
        {
            Quaternion novaRotacao = Quaternion.LookRotation(movimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, 0.1f);
        }

        // Você pode adicionar mais funcionalidades aqui, como controlar a luz da esfera com o teclado (exemplo: alterar intensidade, cor, etc.)
    }
}
