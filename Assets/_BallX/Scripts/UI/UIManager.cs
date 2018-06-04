
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
		private RectTransform titlecard;
		[SerializeField]
		private RectTransform gameOver;

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
        public Action ReturnButtonClicked;
        public Action ReplayButtonClicked;
		public Action MainMenuButtonClicked;


		void Start() {
			DisplayTitlecard (true);
			DisplayGameOver (false);
			DisplayHUD (false);
            DisplayShop(false);
		}

		public void DisplayTitlecard(bool isShown) 
		{
			titlecard.gameObject.SetActive (isShown);
		}

		public void DisplayGameOver(bool isShown) 
		{
			gameOver.gameObject.SetActive (isShown);
		}

		public void DisplayHUD(bool isShown) 
		{
			hud.gameObject.SetActive (isShown);
		}

        public void DisplayShop(bool isShown)
        {
            shop.gameObject.SetActive(isShown);
        }

        public void SetGameOverBestScore (int score) {

			gameOverBestScore.text = "BEST " + score.ToString ();
		}

		public void SetGameOverCurrentScore(int score) {
			gameOverCurrentScore.text = score.ToString ();
		}

		public void SetHUDBestScore (int score) {

			hudBestScore.text = score.ToString ();
		}

		public void SetHUDCurrentScore(int score) {
			hudCurrentScore.text = score.ToString ();
		}

		public void SetHUDCoins(int coins) {
			hudCoins.text = coins.ToString ();
		}

		public void OnPlayButton() 
		{
			if (PlayButtonClicked != null)
				PlayButtonClicked ();

			DisplayTitlecard (false);
		}


		public void OnWatchAdButton() 
		{
			if (WatchAdButtonClicked != null)
				WatchAdButtonClicked ();
		}

		public void OnShopButton()
		{
			if (ShopButtonClicked != null)
				ShopButtonClicked ();

            DisplayShop(true);
            DisplayTitlecard(false);
		}

		public void OnRateButton() 
		{
			if (RateButtonClicked != null)
				RateButtonClicked ();
		}

        public void OnReturnMenuButton()
        {
            if (ReturnButtonClicked != null)
                ReturnButtonClicked();

            DisplayShop(false);
            DisplayTitlecard(true);
        }

        public void OnReplayButton() 
		{
			if (ReplayButtonClicked != null)
				ReplayButtonClicked ();
		}

		public void OnMainMenuButton()
		{
			if (MainMenuButtonClicked != null)
				MainMenuButtonClicked ();
		}
	}
}