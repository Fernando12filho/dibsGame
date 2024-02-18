using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private Button play;
    [SerializeField] private Button quit;
    [SerializeField] private Button oneP;
    [SerializeField] private Button twoP;
    [SerializeField] private Button threeP;
    [SerializeField] private Button fourP;

    public bool player1Build = true;
    public bool player2Build = true;

    public bool isDropping = true;

    private InputSystemEditable playerControls;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }



        playerControls = new InputSystemEditable();

        Instance = this;
        gameManager = this;
        DontDestroyOnLoad(gameObject);

        play.onClick.AddListener(() =>
        {
            oneP.gameObject.SetActive(true); twoP.gameObject.SetActive(true);
            play.gameObject.SetActive(false); quit.gameObject.SetActive(false);

        });
        quit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        oneP.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("One Player Level");
            isDropping = true;
        });
        twoP.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        threeP.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        fourP.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            Application.Quit();
        }

        if (isDropping)
        {
            PlayerController[] players = FindObjectsByType<PlayerController>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            foreach (var player in players)
            {
                player.gameObject.SetActive(false);
            }
            if (!player1Build && GameObject.Find("PlayerDropper") != null)
            {
                GameObject.Find("PlayerDropper").SetActive(false);
            }
            if(!player2Build && GameObject.Find("PlayerDropper2") != null)
            {
                GameObject.Find("PlayerDropper2").SetActive(false);
            }
            if(!player1Build && !player2Build)
            {
                isDropping = false;
                player1Build = true;
                player2Build = true;
                Tile[] tiles = FindObjectsByType<Tile>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                foreach (Tile tile in tiles)
                {
                    tile.gameObject.SetActive(false);
                }
            }
        }

        if (!isDropping)
        {
            PlayerController[] players = FindObjectsByType<PlayerController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var player in players)
            {
                player.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropperController[] builders = FindObjectsByType<DropperController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                foreach (var builder in builders) 
                {
                    builder.gameObject.SetActive(true);
                }
                Tile[] tiles = FindObjectsByType<Tile>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                foreach (Tile tile in tiles)
                {
                    tile.gameObject.SetActive(true);
                }
                isDropping = true;
            }
        }
    }

}
