using System;
using DatabaseSchemaReader.DataSchema;

namespace DatabaseSchemaReader.Extensions
{
    /// <summary> Колонка в таблице с алиасом. </summary>
    public class DatabaseColumnAlias : NamedObject
    {
        /// <summary> Алиас таблицы в запросе. </summary>
        public DatabaseTableAlias TableAlias { get; private set; }

        /// <summary> Исходная колонка. </summary>
        public DatabaseColumn Column { get; private set; }

        public DatabaseColumnAlias(DatabaseTableAlias tableAlias, DatabaseColumn column)
        {
            if (tableAlias == null)
                throw new ArgumentNullException("tableAlias");
            if (column == null)
                throw new ArgumentNullException("column");

            TableAlias = tableAlias;
            Column = column;
            Name = column.Name;
        }

        /// <summary> алиас таблицы + имя колонки. </summary>
        public string FullName { get { return TableAlias.Name + "." + Name; } }

        public override string ToString()
        {
            return FullName;
        }

        public string DbDataType
        {
            get { return Column.DbDataType; }
        }

        public int? Length
        {
            get { return Column.Length; }
        }

        public int? Precision
        {
            get { return Column.Precision; }
        }

        public int? Scale
        {
            get { return Column.Scale; }
        }
    }
}
