using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Linq;

namespace AU2019.Autocad
{
/// <summary>
/// Adapted from Scott McFarlane's AU2015 class
/// SD12077: Being a Remarkable C# .NET AutoCAD Developer
/// http://au.autodesk.com/au-online/classes-on-demand/class-catalog/2015/autocad/sd12077
/// </summary>
public static class Active
{
    public static Editor Editor => Document.Editor;

    public static Document Document => Application.DocumentManager.MdiActiveDocument;

    public static Database Database => Document.Database;

    public static void UsingTransaction(Action<Transaction> action)
    {
        using (var tr = Database.TransactionManager.StartTransaction())
        {
            action(tr);

            tr.Commit();
        }
    }

        public static T UsingTransaction<T>(Func<Transaction, T> func)
        {
            T result;
            using (var tr = Database.TransactionManager.StartTransaction())
            {
                result = func(tr);

                tr.Commit();
            }

            return result;
        }

        public static void UsingModelSpace(Action<Transaction, BlockTableRecord> action)
        {
            using (var tr = Database.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(Database.BlockTableId, OpenMode.ForRead);
                var ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                action(tr, ms);

                tr.Commit();
            }
        }
    }
}
