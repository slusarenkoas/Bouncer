using System.Linq;
using UnityEngine;

public static class Extensions
{
        public static bool HasCollision(this Vector3 position, float radius)
        {
                //Метод принидутельно синхронизирует два представления (колайдер и трансформ) гарантируя,что положение коллайдеров в физ мире соответствует трансформу их объектов
                Physics.SyncTransforms();
                
                //Создаем сферу на заданной позиции с заданным радиусом и получаем все еоллайдеры с кем она соприкасается
                var collider = Physics.OverlapSphere(position, radius);

                //Уберем колайдер пола
                var colliderExceptGameBoard = collider.Where(currentCollider =>
                        !currentCollider.CompareTag(GlobalConstants.GAME_BOARD_TAG)).ToList();
                
                //Если хоть 1 колайдер пересек - вернем true
                return colliderExceptGameBoard.Any();
                
        }

        public static Material GetColoredMaterial(this Material[] materials)
        { 
                return materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));
        }
}