using TMPro;
using UnityEngine;

namespace Player
{
    public class ScorePlayerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countsMoving;

        public void SetPlayerMovingCountsText(int count)
        {
            _countsMoving.text = count.ToString();
        }
    }
}
