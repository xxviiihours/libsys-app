﻿using FastMember;
using libsys_desktop_ui.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Helpers
{
    public class DataTableConverterHelper : IDataTableConverterHelper
    {
        public DataTable ConvertToDataTable<T>(BindingList<T> models)
        {
            //DataTable dataTable = new DataTable(typeof(T).Name);

            ////Get all the properties
            //PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //// Loop through all the properties            
            //// Adding Column to our datatable
            //foreach (PropertyInfo prop in Props)
            //{
            //    //Setting column names as Property names  
            //    dataTable.Columns.Add(prop.Name);
            //}
            //// Adding Row
            //foreach (T item in models)
            //{
            //    var values = new object[Props.Length];
            //    for (int i = 0; i < Props.Length; i++)
            //    {
            //        //inserting property values to datatable rows  
            //        values[i] = Props[i].GetValue(item, null);
            //    }
            //    // Finally add value to datatable  
            //    dataTable.Rows.Add(values);
            //}
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(models))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
