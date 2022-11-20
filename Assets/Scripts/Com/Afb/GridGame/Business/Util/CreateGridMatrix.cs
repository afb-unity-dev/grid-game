using System.Collections.Generic;
using Com.Afb.GridGame.Data.Model;

namespace Com.Afb.GridGame.Business.Util {
    public static class CreateGridMatrix {
        // Public Functions
        public static void Create(GridModel model) {
            int gridSize = model.GridSize;
            model.GridMatrix = new List<List<bool>>();
            for (int x = 0; x < gridSize; x++) {
                var horizontal = new List<bool>();
                model.GridMatrix.Add(horizontal);

                for (int y = 0; y < gridSize; y++) {
                    model.GridMatrix[x].Add(false);
                }
            }
        }
    }
}
