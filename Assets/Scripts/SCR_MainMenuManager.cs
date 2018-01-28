using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_MainMenuManager : MonoBehaviour {

    [Header("Scene to Load")]
    public string sceneToLoad;

    [Header("Main Menu Elements")]
    public GameObject GO_MainMenu;
    public GameObject GO_AboutScreen;
    public GameObject GO_ControlsScreen;
    public GameObject GO_OptionsScreen;

    [Header("Transittion")]
    public AudioClip FX_RecordScratch;

    [Header("Intro Songs")]
    public AudioClip [] AC_Songs;

    [Header("Disk Images")]
    public Sprite[] sprDisk;

    private int DiskIndex = 0;
    private Image IMG_Disk;
    private AudioSource audioSrc;
    private bool canChangeSong = true;

    private void Start()
    {
        IMG_Disk = GameObject.Find("IMG_Disc1").GetComponent<Image>();
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = AC_Songs[DiskIndex];
        audioSrc.Play();
    }

    public void OnSliderValueChange(float _value)
    {
        audioSrc.volume = _value;
    }

    public void OnChangeSongClicked()
    {
        if (!canChangeSong)
            return;

        FindObjectOfType<SCR_MoveCrane>().RotateCrane();

        DiskIndex++;

        if(DiskIndex > sprDisk.Length - 1)
        {
            DiskIndex = 0;
        }

        IMG_Disk.sprite = sprDisk[DiskIndex];

        StartCoroutine(WaitTillSoundPlays());
    }

    IEnumerator WaitTillSoundPlays()
    {
        canChangeSong = false;
        audioSrc.clip = FX_RecordScratch;
        audioSrc.Play();
        yield return new WaitWhile(() => audioSrc.isPlaying);

        canChangeSong = true;
        audioSrc.clip = AC_Songs[DiskIndex];
        audioSrc.Play();
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

	public void OnBackClicked()
    {
        GO_AboutScreen.SetActive(false);
        GO_ControlsScreen.SetActive(false);
        GO_OptionsScreen.SetActive(false);
        GO_MainMenu.SetActive(true);
    }

    public void OnAboutClicked()
    {
        GO_AboutScreen.SetActive(true);
        GO_MainMenu.SetActive(false);
    }

    public void OnControlsClicked()
    {
        GO_ControlsScreen.SetActive(true);
        GO_MainMenu.SetActive(false);
    }

    public void OnOptionsClicked()
    {
        GO_OptionsScreen.SetActive(true);
        GO_MainMenu.SetActive(false);
    }

    public void OnFullScreenClicked()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
