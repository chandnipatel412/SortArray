using System.Collections.Generic;
using SortArray.Helpers;

namespace SortArray.Data
{
    public class SortArrayService : ISortArrayService
    {
        public List<SortArrayModel> GetSortArray(string inputType, string input)
        {
            List<SortArrayModel> sortArray = new List<SortArrayModel>();
            sortArray = inputType == "Numbers" ? NumberSortingAlgorithm.SortAlgorithm(input) : 
                        StringSortingAlgorithm.SortAlgorithm(inputType,input);
            return sortArray;
        }
    }
}
