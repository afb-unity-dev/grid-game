using System.Collections.Generic;

namespace Com.Afb.GridGame.Data.Dto {
    public class GridModel {
        public int GridSize { get; set; }
        public List<List<bool>> GridMatrix { get; set;}
        public int Count { get; set; }
    }
}
