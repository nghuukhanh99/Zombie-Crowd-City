using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrangeAiNpcFollow : MonoBehaviour
{
    public Transform playerPos;

    UnityEngine.AI.NavMeshAgent agent;

    Animator anim;

    Rigidbody rb;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        agent.destination = playerPos.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Citizen")
        {
            OrangeAIScripts.Instance.NumberScore++;

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore.ToString();

            Destroy(other.gameObject);

            OrangeAIScripts.Instance.citizenFollowOrangePlayer();
        }

        if (other.tag == "GreenTeam")
        {
            OrangeAIScripts.Instance.NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            OrangeAIScripts.Instance.citizenFollowOrangePlayer();
        }

        if (other.tag == "YellowTeam")
        {
            OrangeAIScripts.Instance.NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            OrangeAIScripts.Instance.citizenFollowOrangePlayer();
        }

        if (other.tag == "BlueTeam")
        {
            OrangeAIScripts.Instance.NumberScore++;

            BlueAIScripts.Instance.NumberScore--;

            if (BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore--.ToString();

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            OrangeAIScripts.Instance.citizenFollowOrangePlayer();
        }

        

        if (other.tag == "Bot Player")
        {
            OrangeAIScripts.Instance.NumberScore++;

            PlayerController.Instance.NumberScore--;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore--.ToString();

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            OrangeAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            OrangeAIScripts.Instance.citizenFollowOrangePlayer();
        }

    }
}
