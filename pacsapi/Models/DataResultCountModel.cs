using Mahas.Components;

namespace pacsapi.Models
{
    public class DataResultModel<T> where T : new()
    {
        public DataResultModel(int totalcount, T data, bool success)
        {
            TotalCount = totalcount;
            Data = data;
            Success = success;
        }

        public int TotalCount { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }
    }

    public class DataResultModelList<T> where T : new()
    {
        public DataResultModelList(int totalcount, IEnumerable<T> data, bool success)
        {
            TotalCount = totalcount;
            Data = data;
            Success = success;
        }

        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
        public bool Success { get; set; }
    }
}
