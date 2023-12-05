using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Color _colorOne = Color.blue;
    [SerializeField] private Color _colorTwo = Color.green;
    [SerializeField] private Color _colorThird = Color.red;
    
    
    private readonly List<Color> _colors = new List<Color>();

    private void Awake()
    {
        _colors.Add(_colorOne);
        _colors.Add(_colorTwo);
        _colors.Add(_colorThird);
    }

    public Color GetRandomColor()
    {
        var random = new Random();
        var index = random.Next(0, _colors.Count);

        return _colors[index];
    }
}
