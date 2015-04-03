using System.Collections.Generic;
using System.Linq;
using DatabaseSchemaReader.DataSchema;

namespace DatabaseSchemaReader.Extensions
{
    /// <summary> расширяющие методы для класса <see cref="DatabaseTable"/>. </summary>
    public static class DatabaseTableExtensions
    {
        public static IEnumerable<string> SystemColumnNames = new[] { "Timestamp" };

        /// <summary> Возвращает алиас для таблицы. </summary>
        /// <param name="table"> Исходная таблица. </param>
        /// <param name="aliasName"> Алиас таблицы. </param>
        public static DatabaseTableAlias As(this DatabaseTable table, string aliasName = null)
        {
            return new DatabaseTableAlias(table, aliasName);
        }

        public static string FullName(this DatabaseTable table)
        {
            return string.IsNullOrEmpty(table.SchemaOwner) ? table.Name : table.SchemaOwner + "." + table.Name;
        }

        public static string GetColumnsDeclarations(this DatabaseTable table)
        {
            return string.Join(", ", table.Columns.Select(c => c.GetDeclarationExpr()));
        }

        public static DatabaseTable CloneToTempTable(this DatabaseTable table)
        {
            var departmentTemp = new DatabaseTable
            {
                Name = string.Format("#{0}_{1}", table.SchemaOwner, table.Name)
            };
            departmentTemp.AddColumnsCloned(table.Columns.Where(c => !SystemColumnNames.Contains(c.Name)));
            departmentTemp.AddColumn(new DatabaseColumn() { Name = "HasErrors", DbDataType = "bit" });

            return departmentTemp;
        }

        /// <summary> Добавляет массив колонок к таблице. </summary>
        public static void AddColumns(this DatabaseTable databaseTable, IEnumerable<DatabaseColumn> databaseColumns)
        {
            foreach (var databaseColumn in databaseColumns)
            {
                databaseTable.AddColumn(databaseColumn);
            }
        }

        /// <summary> Клонирует колонку и добавялет клона к таблице. </summary>
        public static DatabaseColumn AddColumnCloned(this DatabaseTable databaseTable, DatabaseColumn sourceColumn)
        {
            var newColumn = new DatabaseColumn();
            sourceColumn.CloneTo(newColumn);
            return databaseTable.AddColumn(newColumn);
        }

        /// <summary> Клонирует колонки из массива и добавляет клоны к таблице. </summary>
        public static void AddColumnsCloned(this DatabaseTable databaseTable, IEnumerable<DatabaseColumn> sourceColumns)
        {
            foreach (var sourceColumn in sourceColumns)
            {
                AddColumnCloned(databaseTable, sourceColumn);
            }
        }

        public static DatabaseColumn GetColumn(this DatabaseTable databaseTable, string columnName)
        {
            return databaseTable.Columns.Get(columnName);
        }
    }

}
