using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlatformChar
{


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]


    public class TemplatesDestroyer : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField] private MapSpawner spawner;

        private void Awake()
        {

            if (this.spawner == null) this.spawner = FindObjectOfType<MapSpawner>();

        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.gameObject.tag)

            {

                case "LocationTemplate":
                    this.spawner.DeleteTemplate(other.transform.parent.gameObject);
                    break;
            }
        }


    }
}