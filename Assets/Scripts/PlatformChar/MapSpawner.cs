using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.PlatformChar;



namespace Assets.Scripts.PlatformChar
{

    [RequireComponent(typeof(TemplatesLoader))]

    public class MapSpawner : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TemplatesLoader templatesLoader;

        [Header("Settings")]
        [Tooltip("Templates count on scene in one moment.")]
        [SerializeField] private int templatesPoolSize;

        [Tooltip("Templates on scene.")]
        [SerializeField] private List<GameObject> spawnedTemplates;

        [Tooltip("Templates size.")]
        [SerializeField] private Vector3 templatesSize;

        [Tooltip("Map parent transform")]
        [SerializeField] private Transform templatesParentTransorm;


        private void Update()
        {
            if (this.spawnedTemplates.Count < this.templatesPoolSize)
            {
                SpawnTemplate();

            }
        }

        private void SpawnTemplate()

        {
            GameObject template = this.templatesLoader.GetRandomTemplate();
            GameObject spawnedTemplate = Instantiate(template, this.templatesParentTransorm);
                     
            GameObject lastSpawnedTemplate = this.spawnedTemplates.Last();
            Vector3 lastSpawnedTemplatePosition = lastSpawnedTemplate.transform.localPosition;
            Vector3 templatePosition = lastSpawnedTemplatePosition + this.templatesSize;

            spawnedTemplate.transform.localPosition = templatePosition; //todo
            this.spawnedTemplates.Add(spawnedTemplate);

        }

        private void Awake()
        {
            if (this.templatesLoader == null) this.templatesLoader = GetComponent <TemplatesLoader>();

         }

        public void DeleteTemplate(GameObject template)
        {

            this.spawnedTemplates.Remove(template);
            Destroy(template);
        }

    }
}