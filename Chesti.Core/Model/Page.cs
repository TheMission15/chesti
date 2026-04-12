namespace Chesti.Core.Model
{
    public class Page<T>
    {
        public int PageNum { get; set; }
        public int InPage { get; set; }
        public T[] Items { get; set; }
        public Page(int pageNum, int inPage, T[] items)
        {
            PageNum = pageNum;
            InPage = inPage;
            Items = items;
        }
    }
}
