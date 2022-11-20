using System.Collections.Generic;
using Com.Afb.GridGame.Data.Model;
using Com.Afb.GridGame.Util;

namespace Com.Afb.GridGame.Business.Util {
    public static class CheckGrid {
        // Public Functions
        public static bool CheckCellNeighbors(GridModel model, (int x, int y) point) {
            List<List<bool>> visitMatrix = new List<List<bool>>();
            for (int x = 0; x < model.GridSize; x++) {
                var horizontal = new List<bool>();
                visitMatrix.Add(horizontal);

                for (int y = 0; y < model.GridSize; y++) {
                    visitMatrix[x].Add(false);
                }
            }

            var list = CheckCellRecursive(model, visitMatrix, point);

            bool isMatch = list.Count >= Constants.MATCH_NUMBER;

            if (isMatch) {
                model.Count += list.Count;
                foreach (var pt in list) {
                    model.GridMatrix[pt.x][pt.y] = false;
                }
            }

            return isMatch;
        }

        // Private Functions
        private static List<(int x, int y)> CheckCellRecursive(GridModel model,
                List<List<bool>> visitMatrix,
                (int x, int y) point) {

            var list = new List<(int x, int y)>();

            // If point is out of bounds
            if (point.x < 0 || point.y < 0 ||
                point.x >= model.GridSize || point.y >= model.GridSize) {

                return list;
            }

            // If visited do not proceed
            if (visitMatrix[point.x][point.y]) {
                return list;
            }

            // If point is marked
            if (model.GridMatrix[point.x][point.y]) {
                list.Add(point);
                visitMatrix[point.x][point.y] = true;
            }
            else {
                return list;
            }

            // Left
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x - 1, point.y)));
            // Right
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x + 1, point.y)));
            // Bottom
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x, point.y - 1)));
            // Top
            list.AddRange(CheckCellRecursive(model, visitMatrix, (point.x, point.y + 1)));

            return list;
        }
    }
}
