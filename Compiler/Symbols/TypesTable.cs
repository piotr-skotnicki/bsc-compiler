using System;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class TypesTable<T> : ICloneable
    {
        private Dictionary<IType, Dictionary<IType, T>> table;

        public TypesTable()
        {
            table = new Dictionary<IType, Dictionary<IType, T>>();
        }

        public T this[IType row, IType col]
        {
            get
            {
                return table[row][col];
                /*
                try
                {
                    return table[row][col];
                }
                catch
                {
                    return default(T);
                }
                */
            }
            set
            {
                if (!table.ContainsKey(row))
                {
                    table.Add(row, new Dictionary<IType, T>());
                }
                if (!table[row].ContainsKey(col))
                {
                    table[row].Add(col, value);
                }
                else
                {
                    table[row][col] = value;
                }
            }
        }

        public object Clone()
        {
            TypesTable<T> copy = new TypesTable<T>();
            foreach (KeyValuePair<IType, Dictionary<IType, T>> row in table)
            {
                foreach (KeyValuePair<IType, T> col in row.Value)
                {
                    copy[row.Key, col.Key] = col.Value;
                }
            }
            return copy;
        }
    }
}
