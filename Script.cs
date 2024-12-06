using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    // variáveis usadas
    public GameObject deathCube;
    public GameObject niceCube;

    private GameObject activeCube;
    private int points = 0;
    private float tempo = 0;
    private float maxTempo = 5;
    private int cutPoints = 10;

    void Start()
    {
        activeCube = Instantiate(niceCube);
    }

    void Update()
    {

        tempo += Time.deltaTime;

        if (tempo >= maxTempo)
        {
            if (activeCube.tag == "Nice")
                points = points - 1;
            else
                Debug.Log("Points: " + points);
            NewCube();
            tempo = 0;


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (activeCube.tag == "Death")
                Debug.Log("Points: " + points);
            else
                points++;
                if(points== cutPoints)
                {
                    maxTempo = maxTempo/2;
                }
                

            NewCube();
        }
    }


    void NewCube()
    {
        Destroy(activeCube);

        float randVal = Random.Range(0.0f, 1.0f);
        if (randVal > 0.8)
            activeCube = Instantiate(deathCube);
        else
            activeCube = Instantiate(niceCube);

        float randX = Random.Range(-6.0f, 6.0f);
        float randY = Random.Range(-3.0f, 3.0f);
        Vector3 pos = new Vector3(randX, randY, 0);
        activeCube.transform.position = pos;


    }
}

