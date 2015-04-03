using System;
using System.Collections.Generic;
using DatabaseSchemaReader.DataSchema;

namespace DatabaseSchemaReader.Extensions
{
    /// <summary> Алис таблицы в запросе. </summary>
    public class DatabaseTableAlias : NamedObject
    {
        /// <summary> Список колонок алиаса. </summary>
        public List<DatabaseColumnAlias> Columns { get; protected set; }

        /// <summary> Исходная таблица. </summary>
        public DatabaseTable Table { get; private set; }

        /// <summary> Возвращает колонку по ее имени. </summary>
        /// <param name="columnName"> Наименование колонки. </param>
        public DatabaseColumnAlias this[string columnName]
        {
            get
            {
                return Columns.Get(columnName);
            }
        }

        public DatabaseTableAlias(DatabaseTable table, string alias = null)
        {
            if (table == null)
                throw new ArgumentNullException("table");

            Name = alias ?? ToCamelCase(table.Name);
            Table = table;
            Columns = new List<DatabaseColumnAlias>();
            foreach (var c in table.Columns)
            {
                Columns.Add(new DatabaseColumnAlias(this, c));
            }
        }

        private static string ToCamelCase(string s)
        {
            if (s == null && s.Length == 0)
                return s;
            
            var c1 = s[0];
            if (c1 == '#')
                return s;

            return char.ToLowerInvariant(c1) + s.Substring(1, s.Length - 1);
        }

        public string From()
        {
            return string.Format("{0} AS {1}", Table.FullName(), Name);
        }
    }
}