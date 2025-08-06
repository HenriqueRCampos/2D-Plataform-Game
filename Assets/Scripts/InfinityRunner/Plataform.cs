using UnityEngine;


namespace InfinityRunner
{
    public class Plataform : MonoBehaviour
    {
        [SerializeField]
        private Transform finalPoint;

        public Transform FinalPoint { get => finalPoint; }
    }
}