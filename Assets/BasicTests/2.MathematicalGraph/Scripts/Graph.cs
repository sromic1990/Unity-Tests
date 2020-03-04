using UnityEngine;

namespace BasicTests._2.MathematicalGraph.Scripts
{
    public class Graph : MonoBehaviour
    {
        [SerializeField] private Transform pointPrefab;
        [SerializeField] private Transform holder;
        [SerializeField, Range(10, 100)] private int totalPoints = 10;

        private Transform[] points;

        void Start()
        {
            float step = 2f / totalPoints;
            Vector3 scale = Vector3.one * step;
            Vector3 position = Vector3.zero;
            points = new Transform[totalPoints];
            for (int i = 0; i < totalPoints; i++)
            {
                Transform point = Instantiate(pointPrefab, holder, true);
                points[i] = point;
                position.x = (i + 0.5f) * step - 1f;
                // position.y = position.x * position.x * position.x;
                point.localPosition = position;
                point.localScale = scale;
            }
        }

        
        void Update()
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                Vector3 position = point.localPosition;
                position.y = Mathf.Sin((position.x + Time.time) * Mathf.PI);
                point.localPosition = position;
            }
        }
    }
}
