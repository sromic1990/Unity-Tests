using Sirenix.OdinInspector;
using UnityEngine;

namespace BasicTests._1.Clock.Scripts
{
    public class Clock : MonoBehaviour
    {
        [SerializeField] private bool isContinuous;
        
        [SerializeField] private Transform hoursTransform;
        [SerializeField] private Transform minutesTransform;
        [SerializeField] private Transform secondsTransform;

        [SerializeField][ReadOnly] private const float degreesPerHour = 30f;
        [SerializeField][ReadOnly] private const float degreesPerMinute = 6f;
        [SerializeField][ReadOnly] private const float degreesPerSecond = 6f;

        private void Start()
        {
            ViewClockTime();
        }

        private void Update()
        {
            if (isContinuous)
            {
                UpdateContinuous();
            }
            else
            {
                UpdateDiscreet();
            }
        }

        private void ViewClockTime()
        {
            System.DateTime time = System.DateTime.Now;
            
            hoursTransform.localRotation = Quaternion.Euler(0, time.Hour * degreesPerHour, 0);
            minutesTransform.localRotation = Quaternion.Euler(0, time.Minute * degreesPerMinute, 0);
            secondsTransform.localRotation = Quaternion.Euler(0, time.Second * degreesPerSecond , 0);
        }

        private void UpdateContinuous()
        {
            System.TimeSpan time = System.DateTime.Now.TimeOfDay;
            hoursTransform.localRotation = Quaternion.Euler(0, (float)time.TotalHours * degreesPerHour, 0);
            minutesTransform.localRotation = Quaternion.Euler(0, (float)time.TotalMinutes * degreesPerMinute, 0);
            secondsTransform.localRotation = Quaternion.Euler(0, (float)time.TotalSeconds * degreesPerSecond , 0);
        }

        private void UpdateDiscreet()
        {
            ViewClockTime();
        }
    }
}
