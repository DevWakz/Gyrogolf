using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mate.Clase.Maze;
using TMPro;


public class MovementManager : MonoBehaviour
{
    public GameObject player1, player2, mazeRestarter, invisibility, speed;
    public MazeGenerator mazeMethods;

    private bool player1Spawned = false;
    private bool player2Spawned = false;
    public bool restarterSpawned = false;

    public bool invisibilitySpawned = false;
    public bool speedSpawned = false;
    public bool p1CanMove = true;
    public bool p2CanMove = true;
    

    public int[] score = new int[2];
    public TextMeshProUGUI[] txtScore;
    public GameObject WinScreen = default;
    public int maxScore = 3;
    private GameObject restaterInstance = null;
    private GameObject invisibilityInstance = null;
    private GameObject speedInstance = null;
    [SerializeField] float extraSpeed = 5;
    bool[] HasExtraSpeed = new bool[] { false, false };

    public void Enable_ExtraSpeed(int idx) => HasExtraSpeed[idx] = true;
    public void Disable_ExtraSpeed(int idx) => HasExtraSpeed[idx] = false;

    public float this[int i]
    {
        get 
        { 
            if (HasExtraSpeed[i])
                return extraSpeed;

            return 1;
        }
    }

    private void Awake()
    {
        
        foreach (var txt in FindObjectsOfType <TextMeshProUGUI>())
        {
            if (txt.name.Contains("1"))
                txtScore[0] = txt;
            else if (txt.name.Contains("2"))
                txtScore[1] = txt;

        }
    }

    void Start()
    {
        txtScore[0].text = "Player 1: " + score[0].ToString();
        txtScore[1].text = "Player 2: " + score[1].ToString();
    }

   
    void Update()
    {
        PlayerOneMovement();
        PlayerTwoMovement();
        SpawnPlayers();
        SpawnRestarter();
        SpawnInvisibility();
        SpawnSpeed();

        Check_Score();
    }

    private void Check_Score()
    {
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i] >= maxScore)
            {
                Time.timeScale = 0;
                WinScreen.SetActive(true);
            }
        }
    }

    public void PlayerOneMovement()
    {
        if (Input.GetKey(KeyCode.W) && p1CanMove == true)
            player1.transform.Translate(Vector3.up * Time.deltaTime * this[0]);
        if (Input.GetKey(KeyCode.A) && p1CanMove == true)
            player1.transform.Translate(Vector3.left * Time.deltaTime * this[0]);
        if (Input.GetKey(KeyCode.S) && p1CanMove == true)
            player1.transform.Translate(Vector3.down * Time.deltaTime * this[0]);
        if (Input.GetKey(KeyCode.D) && p1CanMove == true)
            player1.transform.Translate(Vector3.right * Time.deltaTime * this[0]);
    }

    public void PlayerTwoMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) && p2CanMove == true)
            player2.transform.Translate(Vector3.up * Time.deltaTime * this[1]);
        if (Input.GetKey(KeyCode.LeftArrow) && p2CanMove == true)
            player2.transform.Translate(Vector3.left * Time.deltaTime * this[1]);
        if (Input.GetKey(KeyCode.DownArrow) && p2CanMove == true)
            player2.transform.Translate(Vector3.down * Time.deltaTime * this[1]);
        if (Input.GetKey(KeyCode.RightArrow) && p2CanMove == true)
            player2.transform.Translate(Vector3.right * Time.deltaTime * this[1]);
    }

    void SpawnPlayers()
    {
        if (Input.GetKey(KeyCode.Space) && player1Spawned != true && player2Spawned != true)
        {
            var p1SpawnRandomizer = new System.Random();
            int i = p1SpawnRandomizer.Next(0, mazeMethods.graph.nodes.Count);
            Vector2 p1SpawnPoint = mazeMethods.graph.nodes[i];

            var p2SpawnRandomizer = new System.Random();
            int j = p2SpawnRandomizer.Next(0, mazeMethods.graph.nodes.Count);
            Vector2 p2SpawnPoint = mazeMethods.graph.nodes[j];

            player1 = Instantiate(player1, new Vector3(p1SpawnPoint.x, p1SpawnPoint.y, 0), Quaternion.identity);
            player1Spawned = true;
            player1.GetComponent<PlayerCollisions>().OnScore += Set_Score1;
            player2 = Instantiate(player2, new Vector3(p2SpawnPoint.x, p2SpawnPoint.y, 0), Quaternion.identity);
            player2Spawned = true;
            player2.GetComponent<PlayerCollisions>().OnScore += Set_Score2;
        }
        
    }

    void Set_Score1()
    {
        score[0]++;
        txtScore[0].text = "Player 1: " + score[0].ToString();
        print("entro1");
    }
    void Set_Score2()
    {
        score[1]++;
        txtScore[1].text = "Player 2:" + score[1].ToString();
        print("entro2");
    }

    void SpawnRestarter()
    {
        if (mazeMethods.graph == null || mazeMethods.graph.nodes == null) return;

        if ( restarterSpawned == false)
        {
            var MR_SpawnRandomizer = new System.Random();
            int i = MR_SpawnRandomizer.Next(0, mazeMethods.graph.nodes.Count);
            Vector2 MR_SpawnPoint = mazeMethods.graph.nodes[i];

            restaterInstance= Instantiate(mazeRestarter, new Vector3(MR_SpawnPoint.x, MR_SpawnPoint.y, 0), Quaternion.identity);
            
            restarterSpawned = true;
        }  
    }
    void SpawnInvisibility()
    {
        if (mazeMethods.graph == null || mazeMethods.graph.nodes == null) return;

        if (invisibilitySpawned == false)
        {
            var MR_SpawnRandomizer = new System.Random();
            int i = MR_SpawnRandomizer.Next(0, mazeMethods.graph.nodes.Count);
            Vector2 MR_SpawnPoint = mazeMethods.graph.nodes[i];

            invisibilityInstance = Instantiate(invisibility, new Vector3(MR_SpawnPoint.x, MR_SpawnPoint.y, 0), Quaternion.identity);

            invisibilitySpawned = true;
        }
    }

    void SpawnSpeed()
    {
        if (mazeMethods.graph == null || mazeMethods.graph.nodes == null) return;

        if (speedSpawned == false)
        {
            var MR_SpawnRandomizer = new System.Random();
            int i = MR_SpawnRandomizer.Next(0, mazeMethods.graph.nodes.Count);
            Vector2 MR_SpawnPoint = mazeMethods.graph.nodes[i];

            speedInstance = Instantiate(speed, new Vector3(MR_SpawnPoint.x, MR_SpawnPoint.y, 0), Quaternion.identity);

            speedSpawned = true;
        }
    }

    public void RestarterDestroyed()
    {
        restarterSpawned = false;
    }
    public void InvisibilityDestroyed()
    {
        invisibilitySpawned = false;
    }
    public void SpeedDestroyed()
    {
        speedSpawned = false;
    }
}
