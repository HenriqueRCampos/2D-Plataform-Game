using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


namespace InfinityRunner
{
    public class SpawnPlataform : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> plataforms = new List<GameObject>();
        private List<Transform> plataformsPool = new List<Transform>();

        [SerializeField]
        private float spawnDistanceOffSet = 30f;
        private float nextOffSet;

        [SerializeField]
        private float distanceToResetPlataform = 3f;

        private Transform playerTransform;
        private Transform currentPlataformPoint;
        private int plataformIndex;

        private int PlataformIndex
        {
            get { return plataformIndex; }
            set
            {
                if (value > plataformsPool.Count - 1)
                {
                    plataformIndex = 0;
                }
                else
                {
                    plataformIndex = value;
                }
            }
        }

        void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Spawn();
        }

        private void Update()
        {
            ResetPlataformPosition();
        }

        private void Spawn()
        {
            for (int i = 0; i < plataforms.Count; i++)
            {
                GameObject plataform = plataforms[i];
                Vector2 position = new Vector2(spawnDistanceOffSet * i, 0);

                GameObject plataformInstance = Instantiate(plataform, position, transform.rotation);

                plataformsPool.Add(plataformInstance.transform);

                nextOffSet += spawnDistanceOffSet;
            }

            currentPlataformPoint = GetCurrentPlataform().FinalPoint;
        }

        private void Pooling(GameObject plataform)
        {
            plataform.transform.position = new Vector2(nextOffSet, 0);
            nextOffSet += spawnDistanceOffSet;
        }

        private void ResetPlataformPosition()
        {
            float playerDistanceToPlataformFinalPoint = playerTransform.position.x - currentPlataformPoint.position.x;

            if (playerDistanceToPlataformFinalPoint >= distanceToResetPlataform)
            {
                Pooling(plataformsPool[PlataformIndex].gameObject);
                PlataformIndex++;

                currentPlataformPoint = GetCurrentPlataform().FinalPoint;
            }
        }

        private Plataform GetCurrentPlataform()
        {
            return plataformsPool[PlataformIndex].GetComponent<Plataform>();
        }
    }
}
