using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyMode { Continuous, DownOnce, Up }

namespace LON_Tools
{
    public class MainPack : MonoBehaviour
    {
        // FixedUpdate
        void FixedUpdate()
        {
            //RBController(this.gameObject, 4, "z", "s", "q", "d");
        }

        /// <summary>
        /// Controller ultra basique fonctionnant avec la physique pour prototyper rapidement.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="speed"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="rb"></param>
        public static void RBController(GameObject player, int speed, string up, string down, string left, string right, Rigidbody2D rb = null)
        {
            if(player.GetComponent<Rigidbody2D>() != null)
            {
                if(rb == null)
                {
                    rb = player.GetComponent<Rigidbody2D>();
                }

                if (up != null && Input.GetKey(up))
                {
                    rb.velocity = Vector2.up * speed;
                }
                else if(down != null && Input.GetKey(down))
                {
                    rb.velocity = Vector2.down * speed;
                }
                else if(left != null && Input.GetKey(left))
                {
                    rb.velocity = Vector2.left * speed;
                }
                else if(right != null && Input.GetKey(right))
                {
                    rb.velocity = Vector2.right * speed;
                }
            }
        }

        /// <summary>
        /// Permet d'appeler une fonction un certain nombre de fois, toutes les X secondes.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="howManyCalls"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        //Ne pas oublier le StartCoroutine pour l'appeler
        public IEnumerator ClampedInvoke(string methodName, int howManyCalls = 15, float delay = 0f)
        {
            if (methodName != null && howManyCalls != 0)
            {
                for (int i = 0; i < howManyCalls; i++)
                {
                    Debug.Log("oooh");
                    Invoke(methodName, 0f);
                    yield return new WaitForSeconds(delay);
                }
            }         
        }

        /// <summary>
        /// Permet à une liste de touches d'effectuer la même action enfonction d'un mode d'appui.
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <param name="keyMode"></param>
        /// <returns></returns>
        public static bool MultipleKey(List<KeyCode> keyCodes, KeyMode keyMode = KeyMode.DownOnce)
        {
            if(keyCodes.Count > 0 && Input.anyKey)
            {
                foreach(KeyCode kc in keyCodes)
                {
                    switch (keyMode)
                    {
                        case KeyMode.Continuous:
                            if (Input.GetKey(kc))
                            {
                                return true;
                            }
                            break;
                        case KeyMode.DownOnce:
                            if (Input.GetKeyDown(kc))
                            {
                                return true;
                            }
                            break;
                    }
                }
            }
            else if(keyCodes.Count > 0 && keyMode == KeyMode.Up)
            {
                foreach (KeyCode kc in keyCodes)
                {
                    if (Input.GetKeyUp(kc))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
