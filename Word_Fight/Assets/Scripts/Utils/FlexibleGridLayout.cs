using UnityEngine;
using UnityEngine.UI;

namespace LGAMES.WordFight
{
    public enum FitType
    { 
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }

    public class FlexibleGridLayout : LayoutGroup
    {
        public FitType fitType;
        public int rows;
        public int columns;
        public Vector2 cellSize;
        public Vector2 spacing;
        public bool fitX;
        public bool fitY;

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            columns = Mathf.CeilToInt(sqrRt);

            if (fitType == FitType.Width)
            {
                rows = Mathf.CeilToInt(transform.childCount / columns);
            }
            
            if (fitType == FitType.Height)
            {
                columns = Mathf.CeilToInt(transform.childCount / rows);
            }

            float parentWidth = rectTransform.rect.width;
            float parentHeight = rectTransform.rect.height;

            float cellWidth = (parentWidth / columns) - ((spacing.x / columns) * 2) 
                - (padding.left / columns) - (padding.right / columns);
            float cellHeight = (parentHeight / rows) - ((spacing.y / rows) * 2)
                - (padding.top / rows) - (padding.bottom / rows);

            cellSize.x = cellWidth;
            cellSize.y = cellHeight;

            int columnCount;
            int rowCount;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / columns;
                columnCount = i % columns;

                var item = rectChildren[i];

                var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
                var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.right;

                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }
        }

        public override void CalculateLayoutInputVertical()
        {

        }

        public override void SetLayoutHorizontal()
        {

        }

        public override void SetLayoutVertical()
        {

        }
    }
}
