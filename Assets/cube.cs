using UnityEngine;

public class BotaoController : MonoBehaviour
{
    private AudioSource audioClip;
    private Light luzPontual;
    private float tempoDecorrido = 0;
    public bool botaoPressionado = false;



    // Start é chamado antes do primeiro frame
    void Start()
    {
        // Obtém o componente AudioSource e o componente Light
        audioClip = GetComponent<AudioSource>();

        GameObject luzObj = GameObject.Find("luz");  // Encontra o GameObject da luz (certifique-se de que o nome seja correto)
        if (luzObj != null)
        {
            luzPontual = luzObj.GetComponent<Light>();
        }
        else
        {
            Debug.LogError("Luz não encontrada!");
        }
    }
    void Update()
    {
        if (botaoPressionado)
        {
            tempoDecorrido += Time.deltaTime; // Conta o tempo desde o botão ser pressionado
            if (tempoDecorrido >= 1f )
            {
                DesabilitarLuz(); // Desabilita a luz
                tempoDecorrido = 0; // Conta o tempo desde o botão ser pressionado
                botaoPressionado = false;
                PressionaBotao();
            }
        }
    }

    public void DesabilitarLuz()
    {
        if (luzPontual != null)
        {
            luzPontual.enabled = false;  // Desativa a luz
        }
    }

    // Método público que será chamado quando o botão for pressionado
    public void PressionaBotao()
    {
        // Toca o áudio associado ao botão
        if (audioClip != null)
        {
            audioClip.Play();
        }
        else
        {
            Debug.LogError("Áudio não encontrado!");
        }

        // Posiciona a luz na frente do botão
        if (luzPontual != null)
        {
            luzPontual.transform.position = transform.position;

        }

        // Habilita a luz e marca o botão como pressionado
        if (luzPontual != null)
        {
            luzPontual.enabled = true;  // Ativa a luz
        }

        botaoPressionado = false;  // Marca o botão como pressionado
    }
}
