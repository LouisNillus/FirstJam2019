using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BlinkingMode { Standard, Neon, RandomOftenIn, RandomOftenOut }
public enum RandomColorMode { All, AlphaFull, FlashyOnly, GreyScale, RandomSaturation, RandomValue }

namespace UI_Pack
{
    public class UITools : MonoBehaviour
    {
        public static bool isRunning; //Permet de vérifier si une des Coroutines est terminée ou non.

        /// <summary>
        /// Permet d'afficher un texte lettre par lettre à une vitesse choisie.
        /// </summary>
        /// <param name="textComponent"></param>
        /// <param name="message"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static IEnumerator LetterByLetter(Text textComponent, string message, float delay)
        {
            isRunning = true;
            yield return new WaitForSeconds(0); // A DEGAGER
            textComponent.text = "";

            foreach (char letter in message.ToCharArray())
            {
                textComponent.text += letter;
                yield return new WaitForSeconds(delay);
            }
            isRunning = false;
        }

        /// <summary>
        /// Permet de faire clignoter un texte en fonction de modes prédéfinis
        /// </summary>
        /// <param name="textComponent"></param>
        /// <param name="howManyTimes"></param>
        /// <param name="blinkingMode"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static IEnumerator Blinking(Text textComponent, int howManyTimes, BlinkingMode blinkingMode, float speed)
        {
            isRunning = true;
            yield return new WaitForSeconds(3f);  // A DEGAGER
            string message = textComponent.text;

            for(int i = 0; i < howManyTimes; i++)
            {
                switch(blinkingMode)
                {
                    case BlinkingMode.Standard:
                            textComponent.text = "";
                            yield return new WaitForSeconds(1/speed);
                            textComponent.text = message;
                            yield return new WaitForSeconds(1/speed);
                        break;

                    case BlinkingMode.Neon:
                            textComponent.text = "";
                            yield return new WaitForSeconds(0.2f/speed);
                            textComponent.text = message;
                            yield return new WaitForSeconds(0.3f/speed);
                            textComponent.text = "";
                            yield return new WaitForSeconds(0.3f/speed);
                            textComponent.text = message;
                            yield return new WaitForSeconds(0.7f/speed);
                            textComponent.text = "";
                            yield return new WaitForSeconds(0.5f/speed);
                            textComponent.text = message;
                            yield return new WaitForSeconds(1/speed);
                        break;

                    case BlinkingMode.RandomOftenIn:
                            textComponent.text = "";
                            yield return new WaitForSeconds(Random.Range(0f, 0.5f) / speed);
                            textComponent.text = message;
                            yield return new WaitForSeconds(Random.Range(0f, 1.5f) / speed);
                        break;

                    case BlinkingMode.RandomOftenOut:
                            textComponent.text = "";
                            yield return new WaitForSeconds(Random.Range(0f, 1.5f) / speed);
                            textComponent.text = message;
                            yield return new WaitForSeconds(Random.Range(0f, 0.5f) / speed);
                        break;
                }
            }
            isRunning = false;
        }

        /// <summary>
        /// Permet de renvoyer une couleur aléatoire en fonction de modes prédéfinis.
        /// </summary>
        /// <param name="randomColorMode"></param>
        /// <param name="chosenColor"></param>
        /// <returns></returns>
        public static Color32 GetRandomColor(RandomColorMode randomColorMode, Color32 chosenColor = default)
        {
            float colorH;
            float colorS;
            float colorV;

            switch (randomColorMode)
            {
                case RandomColorMode.All:
                    return new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255));
                case RandomColorMode.AlphaFull:
                    return new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                case RandomColorMode.FlashyOnly:
                    return Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);                    
                case RandomColorMode.GreyScale:
                    return Color.HSVToRGB(0f, 0f, Random.Range(0f, 1f));
                case RandomColorMode.RandomSaturation:
                    Color.RGBToHSV(chosenColor, out colorH, out colorS, out colorV);
                    return Color.HSVToRGB(colorH, Random.Range(0f, colorS), colorV);
                case RandomColorMode.RandomValue:
                    Color.RGBToHSV(chosenColor, out colorH, out colorS, out colorV);
                    return Color.HSVToRGB(colorH, colorS, Random.Range(0f, colorV));
            }
            return Color.white; //Si aucun mode n'a été choisi, retourne blanc.
        }
    }
}