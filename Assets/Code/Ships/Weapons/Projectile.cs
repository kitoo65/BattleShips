using System;
using System.Collections;
using UnityEngine;

namespace Ships.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;

        private void Start()
        {
            _rigidbody2D.velocity = transform.up*_speed;
            StartCoroutine(DestroyIn(4));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            //No habría problema, debido a que Unity detendría la corrutina si se destruye antes.
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}