using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Extensions.Linq
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> source)
        {
            if (source == null || source.Count() <= 0) return null;
            return new ObservableCollection<T>(source);
        }

        public static ObservableCollection<T> ToObservable<T>(this IOrderedEnumerable<T> source)
        {
            if (source == null || source.Count() <= 0) return null;
            return new ObservableCollection<T>(source);
        }

        public static ObservableCollection<T> ToObservable<T>(this IList<T> source)
        {
            if (source == null || source.Count() <= 0) return null;
            return new ObservableCollection<T>(source);
        }

        public static ObservableCollection<T> ToObservable<T>(this IQueryable<T> source)
        {
            if (source == null || source.Count() <= 0) return null;
            return new ObservableCollection<T>(source);
        }

        public static ObservableCollection<T> ToObservable<T>(this IOrderedQueryable<T> source)
        {
            if (source == null || source.Count() <= 0) return null;
            return new ObservableCollection<T>(source);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey1, TKey2>(this IEnumerable<TSource> source, Func<TSource, TKey1> key1, Func<TSource, TKey2> key2)
        {
            if (source == null || source.Count() <= 0) return null;
            return source.OrderBy(key1).ThenBy(key2);
        }

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey1, TKey2>(this IEnumerable<TSource> source, Func<TSource, TKey1> key1, Func<TSource, TKey2> key2)
        {
            if (source == null || source.Count() <= 0) return null;
            return source.OrderByDescending(key1).ThenByDescending(key2);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> func)
        {
            if (source == null || source.Count() <= 0) return null;
            return source.GroupBy(func).Select(o => o.First());
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> func)
        {
            if (source == null || source.Count() <= 0) return null;
            return source.GroupBy(func).Select(o => o.First());
        }
    }
}
