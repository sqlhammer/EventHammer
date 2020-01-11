using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DKK_App.Objects
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private PropertyDescriptor _sortProperty;
        private ListSortDirection _sortDirection;

        // Core sort methods
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)this.Items;
            if (property.PropertyType.GetInterface("IComparable") != null)
            {
                itemsList.Sort(new Comparison<T>(delegate (T x, T y)
                {
                    // Compare x to y if x is not null. If x is, but y isn't, we compare y
                    // to x and reverse the result. If both are null, they're equal.
                    if (property.GetValue(x) != null)
                        return ((IComparable)property.GetValue(x)).CompareTo(property.GetValue(y)) * (direction == ListSortDirection.Descending ? -1 : 1);
                    else if (property.GetValue(y) != null)
                        return ((IComparable)property.GetValue(y)).CompareTo(property.GetValue(x)) * (direction == ListSortDirection.Descending ? 1 : -1);
                    else
                        return 0;
                }));

                _isSorted = true;
                _sortProperty = property;
                _sortDirection = direction;
            }
            else
            {
                _isSorted = false;
            }

            // Let bound controls know they should refresh their views
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override void RemoveSortCore()
        {
            _isSorted = false;
        }

        // Core sort properties
        protected override bool SupportsSortingCore { get { return true; } }
        protected override bool IsSortedCore { get { return _isSorted; } }
        protected override ListSortDirection SortDirectionCore { get { return _sortDirection; } }
        protected override PropertyDescriptor SortPropertyCore { get { return _sortProperty; } }
    }
}
