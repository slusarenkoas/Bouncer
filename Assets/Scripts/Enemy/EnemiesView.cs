using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Enemy
{
    public class EnemiesView : MonoBehaviour
    {
        [SerializeField] private Image[] _enemiesColors;
        [SerializeField] private TextMeshProUGUI[] _enemiesCounts;

        private Dictionary<Color, int> _enemiesDataView = new ();
        public void Initialize (ColorManager colorManager)
        {
            var colorsEnemies = colorManager.GetAllColors();

            for (var i = 0; i < colorsEnemies.Length; i++)
            {
                var colorEnemy = colorsEnemies[i];
                _enemiesColors[i].color = colorEnemy;
            }
        }

        public void SetCountOfEnemiesOnBoard(Dictionary <Color,int> enemiesSpawned)
        {
            _enemiesDataView = enemiesSpawned;

            PrintEnemiesOnTheBoardView();
        }

        public void SetCountsEnemiesAfterDied(Color color)
        {
            PrintEnemiesOnTheBoardView();
        }

        private void PrintEnemiesOnTheBoardView()
        {
            for (var i = 0; i < _enemiesColors.Length; i++)
            {
                var currentColor = _enemiesColors[i].color;

                if (_enemiesDataView.ContainsKey(currentColor))
                {
                    _enemiesCounts[i].text = _enemiesDataView[currentColor].ToString();
                }
            }
        }
    }
}
