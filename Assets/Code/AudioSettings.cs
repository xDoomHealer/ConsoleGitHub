using UnityEngine;
using System.Collections;

public static class AudioSettings 
{
    static float MusicVolume, SoundVolume;

    
    static AudioSettings()
    {
        MusicVolume = 100;
        SoundVolume = 100;
    }

    // Update is called once per frame
    static void Update()
    {
         Debug.Log(MusicVolume);
         Debug.Log(SoundVolume);
    }

    public static float getMusicVol()
    {
        return MusicVolume;
    }

    public static void setMusicVol(float vol)
    {
        MusicVolume = vol;
    }

    public static float getSoundVol()
    {
        return SoundVolume;
    }

    public static void setSoundVol(float vol)
    {
        SoundVolume = vol;
    }
}
