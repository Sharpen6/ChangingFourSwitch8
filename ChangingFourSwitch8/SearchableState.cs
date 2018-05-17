using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGamesSolver
{
    abstract class SearchableState
    {
        public SearchableState Origin { get; set; }
        public abstract List<SearchableState> GetAllNeighbors();
    }
}