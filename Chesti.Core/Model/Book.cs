using Chesti.Core.Result;
using System.Numerics;

namespace Chesti.Core.Model
{
    public class Book<T>
    {
        public List<Page<T>> Pages { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int Size { get; set; }
        public Book(List<T> inventory, int itemsPerPage = 9)
        {
            Pages = [];
            Page = 1;
            ItemsPerPage = itemsPerPage;
            int count = inventory.Count;
            Size = 0;
            int max = (int)Math.Ceiling(count / (double)itemsPerPage);
            for (int page = 1; page <= max; page++)
            {
                int inpage = (count % itemsPerPage == 0 || page != max) ? itemsPerPage : count % itemsPerPage;
                T[] items = new T[itemsPerPage];

                for (int pageItem = 0; pageItem < inpage; pageItem++)
                {
                    if (Size < count)
                    {
                        items[pageItem] = inventory[Size];
                        Size++;
                    }
                    else { break; }
                }
                Pages.Add(new(page, inpage, items));
            }
        } // constructor which works ig?
        public int Select(ConsoleKey k)
        {
            int index = (Page - 1) * ItemsPerPage + (k - ConsoleKey.D0 - 1);
            if (index < Size)
            {
                return index;
            }
            else { return -1; }
        }
        public void NextPage() { Page = Page == Pages.Count ? 1 : Page + 1; }
        public void PrevPage() { Page = Page == 1 ? Pages.Count : Page - 1; }
        public void FirstPage() { Page = 1; }
        public void LastPage() { Page = Pages.Count; }
        public IntResult BookNav(Player player, ConsoleKey k, bool selecting = true)
        {
            IntResult result = new(true, -1);

            if (k == ConsoleKey.Escape) { result.Result = false; }

            else if (k == ConsoleKey.RightArrow) { NextPage(); }

            else if (k == ConsoleKey.UpArrow) { FirstPage(); }

            else if (k == ConsoleKey.DownArrow) { LastPage(); }

            else if (k == ConsoleKey.LeftArrow) { PrevPage(); }

            else if (k >= ConsoleKey.D1 && k <= ConsoleKey.D9 && selecting)
            {
                result.Result = false;
                result.Number = Select(k);
            }
            return result;
        }
    }   // The End
}
