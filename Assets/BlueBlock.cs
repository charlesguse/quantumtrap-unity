using Player;
using UnityEngine;

namespace Assets
{
    public class BlueBlock : MonoBehaviour
    {
        private static Movement _movement;
        private static ChangeColor _player;
        private SpriteRenderer _renderer;
        private Color _blockColor;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            if (_movement == null)
                _movement = GameObject.Find("GameSceneScripts").GetComponent<Movement>();
            if (_player == null)
                _player = GameObject.Find("Player").GetComponent<ChangeColor>();
            _renderer = GetComponent<SpriteRenderer>();
            _blockColor = _renderer.color;
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (_player.CurrentColor == CharacterColor.Blue)
                _renderer.color = new Color(_blockColor.r, _blockColor.g, _blockColor.b, .3f);
            else
                _renderer.color = new Color(_blockColor.r, _blockColor.g, _blockColor.b, 1f);
        }

        // ReSharper disable once UnusedMember.Local
        void OnCollisionEnter2D(Collision2D col)
        {
            //var color = col.gameObject.GetComponent<ChangeColor>();
            if (col.gameObject.name == "Player" && _player.CurrentColor != CharacterColor.Blue)
                _movement.OnPlayerCollisionEnter2D(col);
            else if (col.gameObject.name == "Lepton" && _player.CurrentColor != CharacterColor.Blue)
                _movement.OnLeptonCollisionEnter2D(col);
        }
    }
}
