using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] AudioSource MasterSource;
    [SerializeField] AudioSource Test;
    

    [Header("------Audio Clip------")]

    [Header("|Music|")]
    [SerializeField] public AudioClip menu_theme;
    [SerializeField] public AudioClip Main_Theme;
    [SerializeField] public AudioClip Intermission;
    [SerializeField] public AudioClip Victory;
    [SerializeField] public AudioClip Defeat;

    [Header("|Towers|")]
    
    [SerializeField] public AudioClip laser_shoot;
    
    [SerializeField] public AudioClip tower_placement;

    [Header("|Others|")]
    [SerializeField] public AudioClip Wave_Start;
    [SerializeField] public AudioClip base_ability;
    [SerializeField] public AudioClip basic_shoot;
    [SerializeField] public AudioClip pause;
    [SerializeField] public AudioClip unpause;
    [SerializeField] public AudioClip buff_tower;
    [SerializeField] public AudioClip wave_horn;
    
    private void Start()
    {
        MasterSource.clip = menu_theme;
        MasterSource.Play();
    }

    public void DefeatSound()
    {
        MasterSource.clip = Defeat;
        MasterSource.Play();
    }  
    
    public void VictorySound()
    {
        MasterSource.clip = Victory;
        MasterSource.Play();
    }

    public void WavesSound()
    {
        MasterSource.clip = wave_horn;
        MasterSource.Play();
    }

    public void TowerPlacementSound()
    {
        MasterSource.clip = tower_placement;
        MasterSource.Play();
    }

    public void base_abilitySound()
    {
        MasterSource.clip = base_ability;
        MasterSource.Play();
    }    
    
    public void buff_abilitySound()
    {
        MasterSource.clip = buff_tower;
        MasterSource.Play();
    }
}
