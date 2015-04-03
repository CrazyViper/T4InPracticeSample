using System;
using System.Collections.Generic;
using DatabaseSchemaReader.DataSchema;
using DatabaseSchemaReader.Extensions;

namespace T4TemplatesInPractice.DDL.Staff
{
    public static class TableDeclarations
    {

        /// <summary>  </summary>
        public static DepartmentTable Department { get { return _DepartmentTable.Value; } }
        private static Lazy<DepartmentTable> _DepartmentTable = new Lazy<DepartmentTable>(()=> { return new DepartmentTable(); });


        /// <summary>  </summary>
        public static EmployeeTable Employee { get { return _EmployeeTable.Value; } }
        private static Lazy<EmployeeTable> _EmployeeTable = new Lazy<EmployeeTable>(()=> { return new EmployeeTable(); });

    }

    #region 

    /// <summary>  </summary>
    public class DepartmentTable : DatabaseTable
    {
        public DepartmentTable()
        {
            SchemaOwner = "Staff";
            Name = "Department";
            Columns.AddRange(new[] { C_Id, C_FullName, C_ShortName, C_SourceId, C_Timestamp });
            foreach (var c in Columns)
            {
                c.Table = this;
            }
        }
        
        #region Колонки таблицы

        /// <summary>  </summary>
        public DatabaseColumn C_Id { get { return _id; } }
        private DatabaseColumn _id = new DatabaseColumn {Name = "Id", DbDataType = "bigint", IsPrimaryKey = true};


        /// <summary>  </summary>
        public DatabaseColumn C_FullName { get { return _fullName; } }
        private DatabaseColumn _fullName = new DatabaseColumn {Name = "FullName", DbDataType = "nvarchar", Length = 1000};


        /// <summary>  </summary>
        public DatabaseColumn C_ShortName { get { return _shortName; } }
        private DatabaseColumn _shortName = new DatabaseColumn {Name = "ShortName", DbDataType = "nvarchar", Length = 100};


        /// <summary>  </summary>
        public DatabaseColumn C_SourceId { get { return _sourceId; } }
        private DatabaseColumn _sourceId = new DatabaseColumn {Name = "SourceId", DbDataType = "bigint"};


        /// <summary>  </summary>
        public DatabaseColumn C_Timestamp { get { return _timestamp; } }
        private DatabaseColumn _timestamp = new DatabaseColumn {Name = "Timestamp", DbDataType = "datetime2"};

        #endregion

        /// <summary> Создает алиас для таблицы. </summary>
        public DepartmentAlias As(string alias = null)
        {
            return new DepartmentAlias(this, alias);
        }
    }

    /// <summary>  </summary>
    public class DepartmentAlias : DatabaseTableAlias
    {
        public DepartmentAlias(string alias = null)
            : this(new DepartmentTable(), alias)
        {
        }

        public DepartmentAlias(DepartmentTable table, string alias = null)
            : base(table, alias)
        {
            _id = new DatabaseColumnAlias(this, table.C_Id);
            _fullName = new DatabaseColumnAlias(this, table.C_FullName);
            _shortName = new DatabaseColumnAlias(this, table.C_ShortName);
            _sourceId = new DatabaseColumnAlias(this, table.C_SourceId);
            _timestamp = new DatabaseColumnAlias(this, table.C_Timestamp);

            Columns = new List<DatabaseColumnAlias>() { C_Id, C_FullName, C_ShortName, C_SourceId, C_Timestamp };
        }

        #region Колонки таблицы

        /// <summary>  </summary>
        public DatabaseColumnAlias C_Id { get { return _id; } }
        private DatabaseColumnAlias _id;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_FullName { get { return _fullName; } }
        private DatabaseColumnAlias _fullName;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_ShortName { get { return _shortName; } }
        private DatabaseColumnAlias _shortName;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_SourceId { get { return _sourceId; } }
        private DatabaseColumnAlias _sourceId;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_Timestamp { get { return _timestamp; } }
        private DatabaseColumnAlias _timestamp;
        #endregion
   }

    #endregion


    #region 

    /// <summary>  </summary>
    public class EmployeeTable : DatabaseTable
    {
        public EmployeeTable()
        {
            SchemaOwner = "Staff";
            Name = "Employee";
            Columns.AddRange(new[] { C_Id, C_FirstName, C_LastName, C_Birthday, C_SourceId, C_Timestamp, C_DepartmentId });
            foreach (var c in Columns)
            {
                c.Table = this;
            }
        }
        
        #region Колонки таблицы

        /// <summary>  </summary>
        public DatabaseColumn C_Id { get { return _id; } }
        private DatabaseColumn _id = new DatabaseColumn {Name = "Id", DbDataType = "bigint", IsPrimaryKey = true};


        /// <summary>  </summary>
        public DatabaseColumn C_FirstName { get { return _firstName; } }
        private DatabaseColumn _firstName = new DatabaseColumn {Name = "FirstName", DbDataType = "nvarchar", Length = 100};


        /// <summary>  </summary>
        public DatabaseColumn C_LastName { get { return _lastName; } }
        private DatabaseColumn _lastName = new DatabaseColumn {Name = "LastName", DbDataType = "nvarchar", Length = 100};


        /// <summary>  </summary>
        public DatabaseColumn C_Birthday { get { return _birthday; } }
        private DatabaseColumn _birthday = new DatabaseColumn {Name = "Birthday", DbDataType = "date"};


        /// <summary>  </summary>
        public DatabaseColumn C_SourceId { get { return _sourceId; } }
        private DatabaseColumn _sourceId = new DatabaseColumn {Name = "SourceId", DbDataType = "bigint"};


        /// <summary>  </summary>
        public DatabaseColumn C_Timestamp { get { return _timestamp; } }
        private DatabaseColumn _timestamp = new DatabaseColumn {Name = "Timestamp", DbDataType = "datetime2"};


        /// <summary>  </summary>
        public DatabaseColumn C_DepartmentId { get { return _departmentId; } }
        private DatabaseColumn _departmentId = new DatabaseColumn {Name = "DepartmentId", DbDataType = "bigint"};

        #endregion

        /// <summary> Создает алиас для таблицы. </summary>
        public EmployeeAlias As(string alias = null)
        {
            return new EmployeeAlias(this, alias);
        }
    }

    /// <summary>  </summary>
    public class EmployeeAlias : DatabaseTableAlias
    {
        public EmployeeAlias(string alias = null)
            : this(new EmployeeTable(), alias)
        {
        }

        public EmployeeAlias(EmployeeTable table, string alias = null)
            : base(table, alias)
        {
            _id = new DatabaseColumnAlias(this, table.C_Id);
            _firstName = new DatabaseColumnAlias(this, table.C_FirstName);
            _lastName = new DatabaseColumnAlias(this, table.C_LastName);
            _birthday = new DatabaseColumnAlias(this, table.C_Birthday);
            _sourceId = new DatabaseColumnAlias(this, table.C_SourceId);
            _timestamp = new DatabaseColumnAlias(this, table.C_Timestamp);
            _departmentId = new DatabaseColumnAlias(this, table.C_DepartmentId);

            Columns = new List<DatabaseColumnAlias>() { C_Id, C_FirstName, C_LastName, C_Birthday, C_SourceId, C_Timestamp, C_DepartmentId };
        }

        #region Колонки таблицы

        /// <summary>  </summary>
        public DatabaseColumnAlias C_Id { get { return _id; } }
        private DatabaseColumnAlias _id;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_FirstName { get { return _firstName; } }
        private DatabaseColumnAlias _firstName;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_LastName { get { return _lastName; } }
        private DatabaseColumnAlias _lastName;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_Birthday { get { return _birthday; } }
        private DatabaseColumnAlias _birthday;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_SourceId { get { return _sourceId; } }
        private DatabaseColumnAlias _sourceId;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_Timestamp { get { return _timestamp; } }
        private DatabaseColumnAlias _timestamp;
            
        /// <summary>  </summary>
        public DatabaseColumnAlias C_DepartmentId { get { return _departmentId; } }
        private DatabaseColumnAlias _departmentId;
        #endregion
   }

    #endregion

}
