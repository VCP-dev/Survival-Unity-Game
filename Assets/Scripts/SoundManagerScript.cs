using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playergettingeaten,playerdeathmusic,bossdeathsound,playerwalkingsound,gunfiresound,jumpingsound, contactwithcratesound, projhitplayer,enemykillsound,bosshit,playerdeath;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerwalkingsound=Resources.Load<AudioClip>("character-walking-sound-1");
        gunfiresound=Resources.Load<AudioClip>("gun-firing-sound-2");
        jumpingsound=Resources.Load<AudioClip>("jump-1");
        contactwithcratesound=Resources.Load<AudioClip>("contact-with-crate-sound-1");
        projhitplayer=Resources.Load<AudioClip>("projectile-hit-player-2");
        enemykillsound=Resources.Load<AudioClip>("enemy-kill-sound-1 - Copy");
        bosshit=Resources.Load<AudioClip>("Boss-hit-sound-1");
        playerdeath=Resources.Load<AudioClip>("player-death-sound-1");
        bossdeathsound=Resources.Load<AudioClip>("boss-death-sound-1");
        playerdeathmusic=Resources.Load<AudioClip>("player-death-music-1");
        playergettingeaten=Resources.Load<AudioClip>("player-getting-eaten");
        audioSrc=GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "gunfire":
            audioSrc.PlayOneShot(gunfiresound);
            break;
            case "walk":
            audioSrc.PlayOneShot(playerwalkingsound);
            break;
            case "jump":
            audioSrc.PlayOneShot(jumpingsound);
            break;
            case "cratesound":
            audioSrc.PlayOneShot(contactwithcratesound);
            break;
            case "projhitplayer":
            audioSrc.PlayOneShot(projhitplayer);
            break;
            case "enemykilled":
            audioSrc.PlayOneShot( enemykillsound);
            break;
            case "bosshit":
            audioSrc.PlayOneShot(bosshit);
            break;
            case "playerdeath":
            audioSrc.PlayOneShot(playerdeath);
            break;
            case "bossdeath":
            audioSrc.PlayOneShot(bossdeathsound);
            break;
            case "playerdeathmusic":
            audioSrc.PlayOneShot(playerdeathmusic);
            break;
           
        }
    }
}
