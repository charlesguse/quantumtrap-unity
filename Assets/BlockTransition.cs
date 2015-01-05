using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

namespace Assets
{
    public class BlockTransition : MonoBehaviour
    {
        private static string _sceneName;
        private static readonly List<BlockTransition> Blocks = new List<BlockTransition>();
        private static Movement _movement;
        private static GameObject _player;
        private static GameObject _lepton;

        private CharacterColor _blockColor;
        private Animator _animator;
        private bool _passable;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            if (_sceneName == null || _sceneName != Application.loadedLevelName)
            {
                _sceneName = Application.loadedLevelName;
                ResetStaticVariables();
            }
            if (_movement == null)
                _movement = GameObject.Find("GameSceneScripts").GetComponent<Movement>();
            if (_player == null)
                _player = GameObject.Find("Player");
            if (_lepton == null)
                _lepton = GameObject.Find("Lepton");
            var spriteRenderer = GetComponent<SpriteRenderer>();
            _blockColor = ParseColor(spriteRenderer.sprite);

            Blocks.Add(this);
            _animator = GetComponent<Animator>();
        }

        private void ResetStaticVariables()
        {
            Blocks.Clear();
            _movement = null;
            _player = null;
            _lepton = null;
        }

        CharacterColor ParseColor(Sprite sprite)
        {
            var parsedColor = sprite.name.Split('-')[0];
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            parsedColor = parsedColor.First().ToString().ToUpper() + parsedColor.Substring(1);

            return (CharacterColor)Enum.Parse(typeof(CharacterColor), parsedColor);
        }

        public static void Transition(CharacterColor to)
        {
            foreach (var block in Blocks)
            {
                if (to == block._blockColor && !block._passable)
                    block.TransitionToPassable();
                else if (to != block._blockColor && block._passable)
                    block.TransitionToImpassable();
            }
        }

        private void TransitionToPassable()
        {
            _animator.Play("Fade Out");
            _passable = true;
            UnityEngine.Physics2D.IgnoreCollision(_player.collider2D, collider2D, true);
            UnityEngine.Physics2D.IgnoreCollision(_lepton.collider2D, collider2D, true);
        }

        private void TransitionToImpassable()
        {
            if (!_player.collider2D.bounds.Intersects(collider2D.bounds)
                && !_lepton.collider2D.bounds.Intersects(collider2D.bounds))
            {
                _animator.Play("Fade In");
                _passable = false;
                UnityEngine.Physics2D.IgnoreCollision(_player.collider2D, collider2D, false);
                UnityEngine.Physics2D.IgnoreCollision(_lepton.collider2D, collider2D, false);
            }
        }
    }
}
