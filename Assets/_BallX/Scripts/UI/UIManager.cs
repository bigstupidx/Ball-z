
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AppAdvisory.BallX
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [SerializeField]
        private Camera menuCamera;

        [SerializeField]
        private Camera gameCamera;

        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private RectTransform titlecard;
        [SerializeField]
        private RectTransform gameOver;
        [SerializeField]
        private RectTransform pause;

        [SerializeField]
        private Image continuePlayingImage;

        [SerializeField]
        private Transform gameOverMenuItems;

        [SerializeField]
        private RectTransform hud;

        [SerializeField]
        private RectTransform shop;

        [SerializeField]
        private Text gameOverCurrentScore;
        [SerializeField]
        private Text gameOverBestScore;

        [SerializeField]
        private Text hudCurrentScore;
        [SerializeField]
        private Text hudBestScore;
        [SerializeField]
        private Text hudCoins;
        [SerializeField]
        private static Text shopCoins;
        public Text shopCoinsp;

        public Action PlayButtonClicked;
        public Action WatchAdButtonClicked;
        public Action ShopButtonClicked;
        public Action RateButtonClicked;
        public Action RestartButtonClicked;
        public Action ReturnButtonClicked;
        public Action ReplayButtonClicked;
        public Action MainMenuButtonClicked;
        public Action PauseButtonClicked;
        public Action ContinuePlayingButtonClicked;
        public Action MusicButtonClicked;

        public AudioListener audioListener;
        public Image musicIcon;
        public Color32 musicOnColor;
        public Color32 musicOffColor;
        private bool isContinuePlaying = true;

        public Transform removeAdLockedImage;
        public int removeAdCost = 900;

        void Start()
        {
            instance = this;
            shopCoins = shopCoinsp;
            DisplayTitlecard(true);
            DisplayGameOver(false);
            DisplayHUD(false);
            DisplayShop(false);
            canvas.worldCamera = menuCamera;
            menuCamera.enabled = true;
            gameCamera.enabled = false;

            if(PlayerPrefs.GetInt("AdsRemoved") == 1)
            {
                removeAdLockedImage.gameObject.SetActive(false);
            }
        }

        public void DisplayTitlecard(bool isShown)
        {
            titlecard.gameObject.SetActive(isShown);
            
        }

        public void DisplayGameOver(bool isShown)
        {
            gameOver.gameObject.SetActive(isShown);
            if(isContinuePlaying)
            {
                isContinuePlaying = false;
                continuePlayingImage.gameObject.SetActive(true);
                gameOverMenuItems.gameObject.SetActive(false);
            }
            if (isShown)
            {
                canvas.worldCamera = menuCamera;
                menuCamera.enabled = true;
                gameCamera.enabled = false;
                continuePlayingImage.fillAmount = 0;
                StartCoroutine(ContinuePlaying());
            }
            else
            {
                canvas.worldCamera = gameCamera;
                menuCamera.enabled = false;
                gameCamera.enabled = true;
            }

        }

        public void DisplayHUD(bool isShown)
        {
            hud.gameObject.SetActive(isShown);
        }

        public void DisplayPause(bool isShown)
        {
            pause.gameObject.SetActive(isShown);
        }

        public void DisplayShop(bool isShown)
        {
            shop.gameObject.SetActive(isShown);
            shopCoins.text = Utils.GetCoins().ToString();
        }

        public void SetGameOverBestScore(int score)
        {

            gameOverBestScore.text = "BEST " + score.ToString();
        }

        public void SetGameOverCurrentScore(int score)
        {
            gameOverCurrentScore.text = score.ToString();
        }

        public void SetHUDBestScore(int score)
        {

            hudBestScore.text = score.ToString();
        }

        public void SetHUDCurrentScore(int score)
        {
            hudCurrentScore.text = score.ToString();
        }

        public void SetHUDCoins(int coins)
        {
            hudCoins.text = coins.ToString();
        }

        public void OnPlayButton()
        {
            if (PlayButtonClicked != null)
                PlayButtonClicked();
            isContinuePlaying = true;
            DisplayTitlecard(false);
            canvas.worldCamera = gameCamera;
            menuCamera.enabled = false;
            gameCamera.enabled = true;
        }


        public void OnWatchAdButton()
        {
            if (WatchAdButtonClicked != null)
                WatchAdButtonClicked();
        }

        public void OnMusicButton()
        {
            if (MusicButtonClicked != null)
                MusicButtonClicked();

            if(AudioListener.volume == 0)
            {
                AudioListener.volume = 1;
                musicIcon.color = musicOnColor;
            }
            else
            {
                AudioListener.volume = 0;
                musicIcon.color = musicOffColor;
            }

        }

        public void OnShopButton()
        {
            if (ShopButtonClicked != null)
                ShopButtonClicked();

            DisplayShop(true);
            DisplayGameOver(false);
            DisplayTitlecard(false);
            canvas.worldCamera = menuCamera;
            menuCamera.enabled = true;
            gameCamera.enabled = false;
        }

        public void OnRateButton()
        {
            if (RateButtonClicked != null)
                RateButtonClicked();

            Application.OpenURL("https://play.google.com/store/apps/details?id=com.belizard.ballz");
        }

        public void OnRestartButton()
        {
            if (RestartButtonClicked != null)
                RestartButtonClicked();
            Time.timeScale = 1;
            canvas.sortingOrder = 0;
            DisplayPause(false);
            DisplayShop(false);
            canvas.worldCamera = gameCamera;
            menuCamera.enabled = false;
            gameCamera.enabled = true;
        }

        public void OnReturnMenuButton()
        {
            if (ReturnButtonClicked != null)
                ReturnButtonClicked();

            DisplayShop(false);
            DisplayTitlecard(true);
            canvas.worldCamera = menuCamera;
            menuCamera.enabled = true;
            gameCamera.enabled = false;

        }

        public void OnReplayButton()
        {
            if (ReplayButtonClicked != null)
                ReplayButtonClicked();
            isContinuePlaying = true;
        }

        public void OnMainMenuButton()
        {
            if (MainMenuButtonClicked != null)
                MainMenuButtonClicked();
            Time.timeScale = 1;
            canvas.sortingOrder = 0;
            DisplayHUD(false);
            DisplayGameOver(false);
            DisplayPause(false);
            DisplayTitlecard(true);
            canvas.worldCamera = menuCamera;
            menuCamera.enabled = true;
            gameCamera.enabled = false;

        }

        public void OnPauseButton()
        {
            if (PauseButtonClicked != null)
                PauseButtonClicked();
            canvas.sortingOrder = 1;
            Time.timeScale = 0;        
            DisplayPause(true);
            canvas.worldCamera = menuCamera;
            menuCamera.enabled = true;
            gameCamera.enabled = false;

        }

        public void OnContinuePlayingButton()
        {
            if (ContinuePlayingButtonClicked != null)
                ContinuePlayingButtonClicked();
            Time.timeScale = 1;
            canvas.sortingOrder = 0;
            DisplayHUD(true);
            DisplayShop(false);
            DisplayGameOver(false);
            DisplayPause(false);
            canvas.worldCamera = gameCamera;
            menuCamera.enabled = false;
            gameCamera.enabled = true;
        }

        private IEnumerator ContinuePlaying()
        {
            continuePlayingImage.fillAmount += Time.deltaTime * 0.25f;

            yield return new WaitForSeconds(0);

            if(continuePlayingImage.fillAmount < 1)
            {
                StartCoroutine(ContinuePlaying());
            }
            else
            {
                continuePlayingImage.gameObject.SetActive(false);
                gameOverMenuItems.gameObject.SetActive(true);
            }
        }

        public void SelectBall(int id)
        {
            Debug.Log(id);
        }

        public static void UpdateShopCoins()
        {
            shopCoins.text = Utils.GetCoins().ToString();
        }

        public void ShowLeaderboard()
        {
            Social.ShowLeaderboardUI();
        }

        public void RemoveAds()
        {
            if(!PlayerPrefs.HasKey("AdsRemoved"))
            {
                PlayerPrefs.SetInt("AdsRemoved", 0);
            }
            else if (Utils.GetCoins() >= removeAdCost && PlayerPrefs.GetInt("AdsRemoved") == 0)
            {
                removeAdLockedImage.gameObject.SetActive(false);
                Utils.AddCoins(-900);
                UpdateShopCoins();
                PlayerPrefs.SetInt("AdsRemoved", 1);
                AppsFlyerMMP.AdsRemoved();
            }
        }
    }
}