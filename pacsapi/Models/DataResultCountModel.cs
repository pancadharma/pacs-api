using Mahas.Components;

namespace pacsapi.Models
{
    public class DataResultModel<T> where T : new()
    {
        public DataResultModel() { }
        public DataResultModel(int totalcount, T data)
        {
            TotalCount = totalcount;
            Data = data;
        }

        public int TotalCount { get; set; }
        public T Data { get; set; }
    }

    public class DataResultModelList<T> where T : new()
    {
        public DataResultModelList() { }
        public DataResultModelList(int totalcount, IEnumerable<T> data)
        {
            TotalCount = totalcount;
            Data = data;
        }

        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
