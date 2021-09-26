using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource background;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource loseSound;

    private void Start()
    {
        EventManager.YouLose += PlayLoseSound;
        EventManager.YouWin += PlayWinSound;
    }

    private void PlayLoseSound()
    {
        background.Pause();
        loseSound.Play();
    }

    private void PlayWinSound()
    {
        background.Pause();
        winSound.Play();
    }

    public void UnpauseBackground()
    {
        winSound.Stop();
        loseSound.Stop();
        background.UnPause();
    }
}
