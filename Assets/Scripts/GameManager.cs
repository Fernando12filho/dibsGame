using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button quit;
    [SerializeField] private Button oneP;
    [SerializeField] private Button twoP;
    [SerializeField] private Button threeP;
    [SerializeField] private Button fourP;

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
        DontDestroyOnLoad(gameObject);

        play.onClick.AddListener(() =>
        {
            oneP.gameObject.SetActive(true); twoP.gameObject.SetActive(true); threeP.gameObject.SetActive(true); fourP.gameObject.SetActive(true);
            play.gameObject.SetActive(false); quit.gameObject.SetActive(false);

        });
        quit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        oneP.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Feature Testing Scene");
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
    }

}
