using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace Scene
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject FirstSelected;

        private bool _isPaused;
        private GameObject _pauseOverlayCanvas;
        private float _previousTimeScale;
        private float _previousFixedDeltaTime;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            // ReSharper disable once PossibleNullReferenceException
            _pauseOverlayCanvas = GameObject.Find("Pause Menu").GetComponentsInChildren<Canvas>(true).SingleOrDefault(x => x.name == "Pause Menu Canvas").gameObject;
            _pauseOverlayCanvas.SetActive(false);
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            //pause the game on escape key press and when the game is not already paused
            if (Input.GetKeyUp(KeyCode.Escape) && !_isPaused)
            {
                PauseGame();
            }
            //unpause the game if its paused and the escape key is pressed
            else if (Input.GetKeyUp(KeyCode.Escape) && _isPaused)
            {
                UnpauseGame();
            }
        }

        //function to pause the game
        public void PauseGame()
        {
            if (!_isPaused)
            {
                _isPaused = true;
                PauseAllSound();
                PauseTime();
                ShowPauseScreen();
                SelectFirstSelectedAndAnimate();
            }
        }

        public void UnpauseGame()
        {
            if (_isPaused)
            {
                _isPaused = false;
                UnpauseAllSound();
                UnpauseTime();
                HidePauseScreen();
            }
        }

        private void HidePauseScreen()
        {
            _pauseOverlayCanvas.SetActive(false);
        }

        private void ShowPauseScreen()
        {
            _pauseOverlayCanvas.SetActive(true);
        }

        private void SelectFirstSelectedAndAnimate()
        {
            if (FirstSelected != null)
            {
                var selectable = FirstSelected.GetComponent<Selectable>();
                selectable.Select();
                selectable.animator.SetBool("Normal", false);
                selectable.animator.SetBool("Highlighted", true);
            }
        }

        private void PauseTime()
        {
            _previousTimeScale = Time.timeScale;
            _previousFixedDeltaTime = Time.fixedDeltaTime;

            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
        }

        private void UnpauseTime()
        {
            Time.timeScale = _previousTimeScale;
            Time.fixedDeltaTime = _previousFixedDeltaTime;
        }

        private void PauseAllSound()
        {
            AudioListener.pause = true;
        }

        private void UnpauseAllSound()
        {
            StopAllCoroutines();
            AudioListener.pause = false;
        }
    }
}