using System.Collections.Specialized;

namespace RegularCustomer
{
    internal class Customer
    {
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Item newItem)
                        Console.WriteLine($"Добавлен новый товар: id = {newItem.Id}, название = {newItem.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Item oldItem)
                        Console.WriteLine($"Удален товар: id = {oldItem.Id}, название = {oldItem.Name}");
                    break;
            }
        }
    }
}
