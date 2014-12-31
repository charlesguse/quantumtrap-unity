using System;
using UnityEngine;
using UnityEngine.EventSystems;

// ReSharper disable once CheckNamespace
namespace Scene
{
    [Obsolete("Only kept to see how event triggers work. Do not use this in the game.")]
    public class CanvasHelper : EventTrigger
    {
        private const float MaxSize = 1.2f;
        private const float ResizeSpeed = 1f;

        private Vector3 _originalScale;
        private Vector3 _newScale;
        private bool _firstCall = true;
        private float _startTime;
        private bool _grow;

        public void GrowAndShrinkText()
        {
            if (GameObjectScalingDown())
                return;

            if (_firstCall)
            {
                _originalScale = gameObject.transform.localScale;
                _newScale = _originalScale * MaxSize;
                _grow = true;
                _startTime = Time.time;
                _firstCall = false;
            }
            var delta = (Time.time - _startTime) * ResizeSpeed;

            if (_grow)
            {
                gameObject.transform.localScale = Vector3.Lerp(_originalScale, _newScale, delta);
            }
            if (!_grow)
            {
                gameObject.transform.localScale = Vector3.Lerp(_newScale, _originalScale, delta);
            }
            if ((gameObject.transform.localScale == _newScale && _grow)
                || (gameObject.transform.localScale == _originalScale && !_grow))
            {
                _grow = !_grow;
                _startTime = Time.time;
            }
        }

        public void ReturnTextToOriginalScale()
        {
            if (!GameObjectScalingDown())
                ScaleDownOnDeselect.SetValues(gameObject, _originalScale);
            _firstCall = true;
        }

        private bool GameObjectScalingDown()
        {
            return gameObject.GetComponent<ScaleDownOnDeselect>() != null;
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class ScaleDownOnDeselect : MonoBehaviour
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            private const float ResizeSpeed = 5.0f;

            private Vector3 _originalScale;
            private Vector3 _newScale;
            private float _startTime;

            public static void SetValues(GameObject @object, Vector3 originalScale)
            {
                var component = @object.AddComponent<ScaleDownOnDeselect>();
                component._originalScale = originalScale;
                component._newScale = @object.transform.localScale;
                component._startTime = Time.time;
            }

            // ReSharper disable once UnusedMember.Local
            private void Update()
            {
                var delta = (Time.time - _startTime) * ResizeSpeed;
                transform.localScale = Vector3.Lerp(_newScale, _originalScale, delta);

                if (transform.localScale == _originalScale)
                    Destroy(this);
            }
        }
    }
}