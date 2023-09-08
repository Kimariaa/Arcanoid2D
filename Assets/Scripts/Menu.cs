using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource audioControl;
    public GameDataScript gameData;
    public Toggle soundCheck;
    public Toggle musicCheck;
    public Slider soundSlider;
    public Slider musicSlider;
    public GameObject mainMenu;
    public GameObject startMenu;
    bool sound = true;
    bool music = true;
    // Start is called before the first frame update
    void Start()
    {
        if (gameData.firstStart)
        {
            Time.timeScale = 0;
            startMenu.SetActive(true);
        }
    }

    public void StartGame()
    {
        if (startMenu.active)
        {
            startMenu.SetActive(false);
            gameData.firstStart = false;
        }
        Time.timeScale = 1;
        gameData.Reset();
        Cursor.visible = false;
        mainMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueGame()
    {
        Time.timeScale = 0;
        startMenu.SetActive(false);
        Cursor.visible = false;
        gameData.firstStart = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().StartGameLevel();
    }

    public void Exit()
    {
        gameData.firstStart = true;
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void OffSoundSlider()
    {
        gameData.sound = !gameData.sound;
    }

    public void SoundChange()
    {
        Debug.Log(soundSlider.value);
        audioControl.volume = soundSlider.value;
    }

    public void MusicChange()
    {
        audioControl.volume = musicSlider.value;
    }

    public void OffMusicSlider()
    {
        gameData.music = !gameData.music;
        SetMusic();
    }

    void SetMusic()
    {
        if (gameData.music)
            audioControl.Play();
        else
            audioControl.Stop();
    }
}
