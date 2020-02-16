using System.Collections.Generic;

namespace SortArray.Data
{
    public interface ISortArrayService
    {
        List<SortArrayModel> GetSortArray(string inputType, string input);
    }
}