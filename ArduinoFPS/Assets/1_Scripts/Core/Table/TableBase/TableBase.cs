//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.34209
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public abstract class TableBase
{
    /// <summary>
    /// 
    /// </summary>
    static Dictionary<string, bool> loaded = new Dictionary<string, bool>();

    /// <summary>
    /// entity type container
    /// key : entity type(class name)
    /// value list key : agent key
    /// value list value : agent
    /// </summary>
    private static Dictionary<string, Dictionary<string, TableBase>> dicToTable = new Dictionary<string, Dictionary<string, TableBase>>();

    /// <summary>
    /// 
    /// </summary>
    public static void Clear()
    {
        List<Dictionary<string, TableBase>> temp = dicToTable.Values.ToList();
        for (int i = 0, ii = temp.Count; ii > i; ++i)
        {
            List<TableBase> entitys = temp[i].Values.ToList();
            for (int x = 0, xx = entitys.Count; xx > x; ++x)
            {
                entitys[x].OnRelease();
            }

            temp[i].Clear();
        }

        dicToTable.Clear();
        dicToTable = null;
    }


    public static Dictionary<string, TableBase> GetTable(string className)
    {
        if (!dicToTable.ContainsKey(className))
            return null;

        return dicToTable[className];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="className"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static TableBase GetData(string className, string key)
    {
        if (!dicToTable.ContainsKey(className))
            return null;

        if (!dicToTable[className].ContainsKey(key))
            return null;

        return dicToTable[className][key];
    }

    /// <summary>
    /// load all data table
    /// </summary>
    /// <returns></returns>
    public static IEnumerator LoadAllDataTable()
    {
        GameManager.StartCoroutineMethod(LoadDataTable("Unit_Table"));
        ///*
        while (true)
        {
            yield return null;

            bool complete = true;

            using (Dictionary<string, bool>.Enumerator e = loaded.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current.Value == false)
                    {
                        complete = false;
                        break;
                    }
                }
            }

            if (complete)
            {
                break;
            }
        }
        //*/

        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>The data table.</returns>
    public static IEnumerator LoadDataTable(string className)
    {
        loaded.Add(className, false);

        DataBase database = DataBase.Get(className);
        DataTableReader.LoadStringToDataTable(className, database);

        for (int i = 0, ii = database.row; ii > i; ++i)
        {

            if (database.table[i, 0] == 0)
                break;

            try
            {
                ObjectHandle handle = System.Activator.CreateInstance(null, className);
                TableBase table = handle.Unwrap() as TableBase;
                table.SetFieldIndex(i);
                table.SetDataBase(database);
                table.SetKey();

                table.Regist();

            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        loaded[className] = true;

        yield return null;
    }

    public static void LoadDataTable_(string className)
    {
        loaded.Add(className, false);

        DataBase database = DataBase.Get(className);
        DataTableReader.LoadStringToDataTable(className, database);

        for (int i = 0, ii = database.row; ii > i; ++i)
        {

            if (database.table[i, 0] == 0)
                break;

            try
            {
                ObjectHandle handle = System.Activator.CreateInstance(null, className);
                TableBase table = handle.Unwrap() as TableBase;
                table.SetFieldIndex(i);
                table.SetDataBase(database);
                table.SetKey();

                table.Regist();

            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }

        loaded[className] = true;
    }

    /// <summary>
    /// table field id ( 0 ~ n )
    /// </summary>
    protected int fieldIndex { private set; get; }

    /// <summary>
    /// database
    /// </summary>
    /// <value>The database.</value>
    private DataBase data;

    /// <summary>
    /// table field key
    /// </summary>
	public string key { protected set; get; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    protected DataValue this[int columns]
    {
        get
        {
            return data.table[this.fieldIndex, columns];
        }
    }


    /// <summary>
    /// entity
    /// </summary>
    public TableBase()
    {
    }

    /// <summary>
    /// entity
    /// </summary>
    private void OnRelease()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    protected abstract void SetKey();

    /// <summary>
    /// 
    /// </summary>
    private void SetFieldIndex(int fieldIndex)
    {
        this.fieldIndex = fieldIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    private void SetDataBase(DataBase data)
    {
        this.data = data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p">P.</param>
    private void Regist()
    {
        if (!dicToTable.ContainsKey(this.ToString()))
        {
            dicToTable.Add(this.ToString(), new Dictionary<string, TableBase>());
        }

        if (!dicToTable[this.ToString()].ContainsKey(key))
        {
            dicToTable[this.ToString()].Add(key, this);
            //#if UNITY_EDITOR
            //            Debug.Log(string.Format("regist {0} entity table pool -> key {1}", this.ToString(), key));
            //#endif
        }
    }

    public static Unit_Table GetUnit_Table(string key)
    {
        return TableBase.GetData("Unit_Table", key) as Unit_Table;
    }

    public static int GetColumn_Count(string key)
    {
        if (dicToTable.ContainsKey(key))
            return dicToTable[key].Count();
        return 0;
    }
}