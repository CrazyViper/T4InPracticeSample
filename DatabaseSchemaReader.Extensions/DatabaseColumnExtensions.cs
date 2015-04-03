using DatabaseSchemaReader.DataSchema;

namespace DatabaseSchemaReader.Extensions
{
    public static class DatabaseColumnExtensions
    {

        public static void CloneTo(this DatabaseColumn source, DatabaseColumn target)
        {
            ((NamedObject)source).CloneTo(target);
            target.DbDataType = source.DbDataType;
            target.ForeignKeyTableName = source.ForeignKeyTableName;
            target.Length = source.Length;
            target.Nullable = source.Nullable;
            target.Ordinal = source.Ordinal;
            target.DefaultValue = source.DefaultValue;
            target.Precision = source.Precision;
            target.Scale = source.Scale;
            target.DateTimePrecision = source.DateTimePrecision;
            target.TableName = source.TableName;
            target.ComputedDefinition = source.ComputedDefinition;
            target.Description = source.Description;
            target.IsForeignKey = source.IsForeignKey;
            target.IsIndexed = source.IsIndexed;
            target.IsPrimaryKey = source.IsPrimaryKey;
            target.IsUniqueKey = source.IsUniqueKey;
            target.NetName = source.NetName;
            //Table
            //DatabaseSchema
            target.DataType = source.DataType;
            // ForeignKeyTable
        }

        public static DatabaseColumn Clone(this DatabaseColumn column)
        {
            var newColumn = new DatabaseColumn();
            column.CloneTo(newColumn);
            return newColumn;
        }


        /// <summary> Объявление колонки с типом данных. </summary>
        public static string GetDeclarationExpr(this DatabaseColumn column)
        {
            string s = string.Format("[{0}] {1}", column.Name, GetTypeExpression(column.DbDataType, column.Length, column.Precision, column.Scale));

            if (!column.Nullable)
            {
                s += " NOT NULL";
            }
            if (!string.IsNullOrEmpty(column.DefaultValue))
            {
                s += " DEFAULT " + column.DefaultValue;
            }
            return s;
        }

        public static string GetTypeExpression(string databaseDataType, int? length, int? precision, int? scale)
        {
            if (length == null)
            {
                if (precision == null || (databaseDataType.Contains("int")))
                {
                    return databaseDataType;
                }
                else if (scale == null)
                {
                    return string.Format("{0}({1})", databaseDataType, precision);
                }
                else
                {
                    return string.Format("{0}({1}, {2})", databaseDataType, precision, scale);
                }
            }
            return string.Format("{0}({1})", databaseDataType, length == -1 ? "MAX" : length.ToString());
        }

    }
}