using System.Collections.Generic;

namespace Com.Afb.GridGame.Data.Model {
    public class GridModel {
        // Public Properties
        public int GridSize { get; set; }
        public List<List<bool>> GridMatrix { get; set;}
        public int Count { get; set; }
    }
}
