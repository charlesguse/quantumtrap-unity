using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeColor : MonoBehaviour
    {
        private Sprite _white;
        public Sprite Blue;
        public Sprite Red;
        public Sprite Yellow;
        public Sprite Green;

        public CharacterColor CurrentColor { get { return Choices[_colorIndex]; } }
        private CharacterColor[] Choices { get; set; }
        private int _colorIndex;

        private SpriteRenderer _renderer;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _white = _renderer.sprite;

            _colorIndex = 0;
            var list = new List<CharacterColor> { CharacterColor.White };

            if (Blue != null)
                list.Add(CharacterColor.Blue);
            if (Red != null)
                list.Add(CharacterColor.Red);
            if (Yellow != null)
                list.Add(CharacterColor.Yellow);
            if (Green != null)
                list.Add(CharacterColor.Green);

            Choices = list.ToArray();
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.E))
                IncrementColor();
            else if (Input.GetButtonUp("Fire2") || Input.GetKeyUp(KeyCode.Q))
                DecrementColor();
        }

        private void IncrementColor()
        {
            ChangeCharacterColor(1);
        }

        private void DecrementColor()
        {
            ChangeCharacterColor(-1);
        }

        private void ChangeCharacterColor(int increment)
        {
            _colorIndex = (_colorIndex + increment) % Choices.Length;

            if (_colorIndex == -1)
                _colorIndex = Choices.Length - 1;

            if (Choices.Length > 1)
            {
                switch (CurrentColor)
                {
                    case CharacterColor.White:
                        _renderer.sprite = _white;
                        break;
                    case CharacterColor.Blue:
                        _renderer.sprite = Blue;
                        break;
                    case CharacterColor.Red:
                        _renderer.sprite = Red;
                        break;
                    case CharacterColor.Yellow:
                        _renderer.sprite = Yellow;
                        break;
                    case CharacterColor.Green:
                        _renderer.sprite = Green;
                        break;
                }
            }
        }
    }

    public enum CharacterColor
    {
        White,
        Blue,
        Red,
        Yellow,
        Green,
    }
}