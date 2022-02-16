using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class YellowAIScripts : MonoBehaviour
{
    public static YellowAIScripts Instance;

    public GameObject citizenFollow;

    public GameObject yellowPlayerPos;

    public GameObject spawnFollow;

    public Text Score;

    public int NumberScore;

    public int ScoreAfterCollision;

    public GameObject YelllowTeamAI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        NumberScore = 1;

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Citizen")
        {
            NumberScore++;

            YelllowTeamAI.gameObject.SetActive(true);

            Score.text = NumberScore.ToString();

            Destroy(other.gameObject);

            citizenFollowYellowPlayer();
        }

        if (other.tag == "GreenTeam")
        {
            NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowYellowPlayer();
        }

        if (other.tag == "OrangeTeam")
        {
            NumberScore++;

            OrangeAIScripts.Instance.NumberScore--;

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore--.ToString();

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowYellowPlayer();
        }

        if (other.tag == "BlueTeam")
        {
            NumberScore++;

            BlueAIScripts.Instance.NumberScore--;

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore--.ToString();

            if (BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowYellowPlayer();
        }

        
        if (other.tag == "Bot Player")
        {
            NumberScore++;

            PlayerController.Instance.NumberScore--;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore--.ToString();

            if (PlayerController.Instance.NumberScore <= 0)
            {
                PlayerController.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowYellowPlayer();
        }

    }

    public void citizenFollowYellowPlayer()
    {

        Vector3 spawnFollowPos = new Vector3(spawnFollow.transform.position.x, spawnFollow.transform.position.y, spawnFollow.transform.position.z);

        GameObject NpcFollowPlayer = Instantiate(citizenFollow, spawnFollowPos, Quaternion.identity);

    }
}
