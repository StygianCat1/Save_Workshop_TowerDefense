using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    
    //ref to the AudioMixer 
    [SerializeField] public AudioMixer mixer;
    
    //ref to a TextMeshPro_DropDown
    [SerializeField] public Dropdown resolutionDropdown;
    
    //ref to resolution List
    [SerializeField] private Resolution[] resolutions;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set resolutions as this screen resolution
        resolutions = Screen.resolutions;
        //clear all options in the dropdown
        resolutionDropdown.ClearOptions();
        //set local variable as a new list
        List<string> options = new List<string>();
        //set local var int as an index
        int currentResolutionIndex = 0;
        //get the resolutions lenght
        for (int i = 0; i < resolutions.Length; i++)
        {
            //set in the options string the size for the player to know
            string option = resolutions[i].width + " x " + resolutions[i].height;
            //add the string in the list
            options.Add(option);
            //if any i resolution is equal to current screen resolution
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                //then i is the current index
                currentResolutionIndex = i;
            }
        }
        //add the options list in the resolutions drop down
        resolutionDropdown.AddOptions(options);
        //set the index as the current dropdown value
        resolutionDropdown.value = currentResolutionIndex;
        //refresh to show value to player
        resolutionDropdown.RefreshShownValue();
    }

    //function for volume settings
    public void SetVolume (float volume)
    {
        //set the current volume settings as volume
        mixer.SetFloat("volume",volume);
    }

    //function for the resolution settings
    public void SetResolution(int resolutionIndex)
    {
        //set resolutions with the index as the resolution
        Resolution resolution = resolutions[resolutionIndex];
        //apply the resolution to the screen
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
