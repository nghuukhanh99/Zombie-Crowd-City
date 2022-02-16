using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GreenAiScripts : MonoBehaviour
{
    public static GreenAiScripts Instance;

    public GameObject citizenFollow;

    public GameObject greenPlayerPos;

    public GameObject spawnFollow;

    public Text Score;

    public int NumberScore;

    public int ScoreAfterCollision;

    public GameObject GreenTeamAI;

    private void Awake()
    {
        Instance = this;
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

            GreenTeamAI.gameObject.SetActive(true);

            Score.text = NumberScore.ToString();

            Destroy(other.gameObject);

            citizenFollowGreenPlayer();
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

            citizenFollowGreenPlayer();
        }

        if (other.tag == "YellowTeam")
        {
            NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowGreenPlayer();
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

            citizenFollowGreenPlayer();
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

            citizenFollowGreenPlayer();
        }

    }

    public void citizenFollowGreenPlayer()
    {

        Vector3 spawnFollowPos = new Vector3(spawnFollow.transform.position.x, spawnFollow.transform.position.y, spawnFollow.transform.position.z);

        GameObject NpcFollowPlayer = Instantiate(citizenFollow, spawnFollowPos, Quaternion.identity);

    }
}
