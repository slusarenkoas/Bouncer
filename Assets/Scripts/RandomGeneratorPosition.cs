using UnityEngine;

public static class RandomGeneratorPosition
{
    public static Vector3 GetRandomPositionOnBoard(Vector2 gameBoard)
    { 
        return new Vector3(Random.Range(-gameBoard.x, gameBoard.x), 0,
            Random.Range(-gameBoard.y, gameBoard.y));
    }
}