using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public float speedRunning = 100f;

    public float speedRotate = 500f;

    private Animator anim;

    private Rigidbody rb;

    public GameObject citizenFollow;

    public GameObject PlayerPos;

    public GameObject spawnFollow;

    public Text Score;

    public int NumberScore;

    public GameObject PlayerAI;

    public int playerHP;

    public List<GameObject> PlayerSpawnNumber;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        playerHP = 100;

        NumberScore = 1;

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // movement when click mouse left
        {
            anim.SetBool("isRunning", true);

            transform.Translate(Vector3.forward * Time.deltaTime * speedRunning);

            float mouseX = Input.GetAxisRaw("Mouse X"); // Rotate the camera follow X axis

            transform.Rotate(0, mouseX * Time.deltaTime * speedRotate, 0);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Citizen")
        {
            NumberScore++;

            PlayerAI.gameObject.SetActive(true);

            Score.text = NumberScore.ToString();

            Destroy(other.gameObject);

            citizenFollowPlayer();
        }

        if(other.tag == "BlueTeam")
        {
            NumberScore++;

            BlueAIScripts.Instance.NumberScore--;

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore--.ToString();

            if(BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowPlayer();
        }

        if (other.tag == "GreenTeam")
        {
            NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowPlayer();
        }

        if (other.tag == "OrangeTeam")
        {
            NumberScore++;

            OrangeAIScripts.Instance.NumberScore--;

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore--.ToString();

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowPlayer();
        }

        if (other.tag == "YellowTeam")
        {
            NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowPlayer();
        }


    }

    public void citizenFollowPlayer()
    {
        

        Vector3 spawnFollowPos = new Vector3(spawnFollow.transform.position.x, spawnFollow.transform.position.y, spawnFollow.transform.position.z);

        GameObject NpcFollowPlayer = Instantiate(citizenFollow, spawnFollowPos, Quaternion.identity);

        PlayerSpawnNumber.Add(NpcFollowPlayer);

    }


}
