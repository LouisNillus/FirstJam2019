using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundMode { Normal, ExcludeAfterPlay }
public enum OverrideMode { Replace, Queue, Simultaneous }

namespace Sound_Pack
{
    public class SoundTools : MonoBehaviour
    {
        public static List<AudioClip> audioQueue = new List<AudioClip>();
        private static int orderedSoundsIndex;

        /// <summary>
        /// Permet de renvoyer des sons aléatoires d'une liste et les exclure ou non au fur et à mesure.
        /// </summary>
        /// <param name="audioClips"></param>
        /// <param name="soundMode"></param>
        /// <returns></returns>
        public static AudioClip RandomSounds(List<AudioClip> audioClips, SoundMode soundMode = SoundMode.Normal)
        {
            if (audioClips.Count > 0)
            {
                AudioClip audio;

                switch (soundMode)
                {
                    case SoundMode.Normal:
                        audio = audioClips[Random.Range(0, audioClips.Count)];
                        return audio;
                    case SoundMode.ExcludeAfterPlay:
                        audio = audioClips[Random.Range(0, audioClips.Count)];
                        audioClips.Remove(audio);
                        return audio;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Permet de renvoyer des sons dans l'ordre d'une liste et les exclure ou non au fur et à mesure.
        /// </summary>
        /// <param name="audioClips"></param>
        /// <param name="soundMode"></param>
        /// <returns></returns>
        public static AudioClip OrderedSounds(List<AudioClip> audioClips, SoundMode soundMode = SoundMode.Normal)
        {
            if (audioClips.Count > 0)
            {
                AudioClip audio;

                switch (soundMode)
                {
                    case SoundMode.Normal:
                        audio = audioClips[orderedSoundsIndex];
                        orderedSoundsIndex++;
                        if(orderedSoundsIndex > audioClips.Count)
                        {
                            orderedSoundsIndex = 0;
                        }
                        return audio;
                    case SoundMode.ExcludeAfterPlay:
                        audio = audioClips[0];
                        audioClips.Remove(audio);
                        return audio;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Permet de jouer des sons par dessus les autres ou de les mettre en liste d'attente avant de les jouer. 
        /// </summary>
        /// <param name="audioSource"></param>
        /// <param name="audio"></param>
        /// <param name="overrideMode"></param>
        public static void PlayAudioWithOverrideMode(AudioSource audioSource, AudioClip audio, OverrideMode overrideMode = OverrideMode.Replace)
        {
            if(audioSource == null || audio == null)
            {
                return;
            }

            switch(overrideMode)
            {
                case OverrideMode.Replace:
                    audioSource.clip = audio;
                    audioSource.Play();
                    break;
                case OverrideMode.Queue:
                    if(audioSource.isPlaying == true)
                    {
                        audioQueue.Add(audio);
                    }
                    else if(audioQueue.Count > 0)
                    {
                        audioSource.PlayOneShot(audioQueue[0]);
                        audioQueue.Remove(audioQueue[0]);
                    }
                    else
                    {
                        audioSource.PlayOneShot(audio);
                    }
                    break;
                case OverrideMode.Simultaneous:
                    audioSource.PlayOneShot(audio);
                    break;
            }
        }
    }
}

