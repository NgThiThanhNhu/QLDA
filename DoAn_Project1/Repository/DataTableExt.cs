using System.Data;
using System.Reflection;

namespace Repository
{
    public static class DataTableExt
    {
        public static List<T> ToList<T>(this DataTable tbl) where T : class
        {
            List<T> list = new List<T>();
            foreach (DataRow row in (InternalDataCollectionBase)tbl.Rows)
                list.Add(DataTableExt.CreateItemFromRow<T>(row));
            return list;
        }

        private static T CreateItemFromRow<T>(DataRow row) where T : class
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            DataTableExt.SetItemFromRow<T>(instance, row);
            return instance;
        }

        private static void SetItemFromRow<T>(T item, DataRow row) where T : class
        {
            foreach (DataColumn column in (InternalDataCollectionBase)row.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);
                if (property != (PropertyInfo)null && row[column] != DBNull.Value)
                    property.SetValue((object)item, row[column], (object[])null);
            }
        }
    }
}
