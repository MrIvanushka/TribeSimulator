using System;

namespace TribeToSurvive.Model
{
    public class CameraMovement : ISceneObject, IUpdatable
    {
        private const float _freeAcceleration = 0.99f;
        private const float _holdAcceleration = 0.5f;
        private const float _sensitivity = 20f;
        private readonly IVector3 _minPosition = new Vector3(0, 0, -4);
        private readonly IVector3 _maxPosition = new Vector3(60, 0, 60);

        private Vector3 _position;
        private Vector3 _velocity;
        private float _acceleration;

        public UnityEngine.Vector3 Position => new UnityEngine.Vector3(_position.X, _position.Y, _position.Z);

        public Action Destroying;
        public Action Moved;

        public CameraMovement(UnityEngine.Vector3 position)
        {
            _position = new Vector3(position);
            _velocity = new Vector3(0, 0, 0);
            _acceleration = _freeAcceleration;
        }

        public void Update(float deltaTime)
        {
            _position += _velocity * -1 * _sensitivity * deltaTime;
            FitPosition();
            _velocity *= _acceleration;
            Moved?.Invoke();
        }

        public void StartMoving()
        {
            _acceleration = _holdAcceleration;
        }

        public void EndMoving()
        {
            _acceleration = _freeAcceleration;
        }

        public void Accelerate(UnityEngine.Vector2 delta)
        {
            if (delta.magnitude > 0.00001f)
            {
                delta = delta.normalized;
                _velocity = new Vector3(delta.x, 0, delta.y);
            }
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }

        private void FitPosition()
        {
            if (_position.X < _minPosition.X)
                _position = new Vector3(_minPosition.X, _position.Y, _position.Z);
            if (_position.Z < _minPosition.Z)
                _position = new Vector3(_position.X, _position.Y, _minPosition.Z);
            if (_position.X > _maxPosition.X)
                _position = new Vector3(_maxPosition.X, _position.Y, _position.Z);
            if (_position.Z > _maxPosition.Z)
                _position = new Vector3(_position.X, _position.Y, _maxPosition.Z);
        }
    }
}