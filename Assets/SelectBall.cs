using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppAdvisory.BallX
{
    public class SelectBall : MonoBehaviour {

        [SerializeField] private Transform lockedImage;
        [SerializeField] private Transform ballParticle;
        [SerializeField] private Toggle toggle;
        [SerializeField] private int id;
        [SerializeField] private int cost = 20;

        private static Toggle previousToggle;


        // Use this for initialization
        void Start()
        {
            if (!PlayerPrefs.HasKey("Ball_" + id))
            {
                if (id == 0)
                {
                    PlayerPrefs.SetInt("Ball_" + id, 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Ball_" + id, 0);
                }

            }
            if (PlayerPrefs.HasKey("Ball_" + id))
            {
                if (PlayerPrefs.GetInt("Ball_" + id) == 1)
                {
                    lockedImage.gameObject.SetActive(false);
                    ballParticle.gameObject.SetActive(true);
                    Debug.Log("Ball Shop Test");

                }
            }

            toggle.isOn = false;
            if (PlayerPrefs.GetInt("Ball") == id)
            {
                toggle.isOn = true;
                toggle.Select();
                previousToggle = toggle;
            }
        }

        public void ToggleBall()
        {
            if (PlayerPrefs.GetInt("Ball_" + id) == 1)
            {
                if (toggle.isOn)
                {
                    PlayerPrefs.SetInt("Ball", id);
                    GameManager.instance.SetBall(id);
                    Debug.Log(id + " ON");
                }
                else
                {

                    Debug.Log(id + " OFF");
                }
            }
            else
            {
                if (Utils.GetCoins() >= cost)
                {
                    lockedImage.gameObject.SetActive(false);
                    ballParticle.gameObject.SetActive(true);
                    Utils.AddCoins(-cost);
                    UIManager.UpdateShopCoins();
                    PlayerPrefs.SetInt("Ball_" + id, 1);
                    PlayerPrefs.SetInt("Ball", id);
                    GameManager.instance.SetBall(id);
                    AppsFlyerMMP.BallUnlocked();
                }
                else
                {
                    if (toggle.isOn)
                    {
                        previousToggle.isOn = true;
                    }
                }
                    

            }


        }
    }
}
