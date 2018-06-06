
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

        private bool isContinuePlaying = true;

        void Start()
        {
            DisplayTitlecard(true);
            DisplayGameOver(false);
            DisplayHUD(false);
            DisplayShop(false);
            canvas.worldCamera = menuCamera;
            menuCamera.enabled = true;
            gameCamera.enabled = false;
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

        public void OnShopButton()
        {
            if (ShopButtonClicked != null)
                ShopButtonClicked();

            DisplayShop(true);
            DisplayTitlecard(false);
        }

        public void OnRateButton()
        {
            if (RateButtonClicked != null)
                RateButtonClicked();
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
    }
}