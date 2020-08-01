using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
 public class Unit_Person
 {
     #region Fields

     private int _PersonID;
     private int _UnitID;
     private string _Relation;
     private string _Desc;

     #endregion Fields

     #region Properties

     public string Relation
     {
         get { return _Relation; }
         set { _Relation = value; }
     }

     public string Desc
     {
         get { return _Desc; }
         set { _Desc = value; }
     }
     
    public int UnitID
     {
         get { return _UnitID; }
         set { _UnitID = value; }
     }

     public int PersonID
     {
         get { return _PersonID; }
         set { _PersonID = value; }
     }

     #endregion Properties
 }
}
