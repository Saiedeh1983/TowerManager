//using System;
//using System.Collections.Generic;
//using System.Text;
//using Alma.Common;
//using System.Data.OleDb;
//using System.Data;
//using System.Configuration;


//namespace Alma.DAL
//{
//    public class DAL
//    {
//        OleDbConnection cn = new OleDbConnection(ConfigurationManager.AppSettings["CnString"]);
//        OleDbCommand cmd;
//        #region Unit

//        public Unit LoadUnit(int UnitID)
//        {
//            string SqlStr = "select * from tblUnits where UnitID=@UnitID and UnitIsDel=0";
//            Unit unit = new Unit();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unit.ID = int.Parse(r[0].ToString());
//                unit.UnitCode = int.Parse(r[1].ToString());
//                unit.UnitNumber = r[2].ToString();
//                unit.UnitArea = int.Parse(r[3].ToString());
//                unit.UnitFloor = int.Parse(r[4].ToString());
//                unit.UnitPersonsNum = int.Parse(r[5].ToString());
//                unit.Type = r[6].ToString();
//                unit.UnitRooms = int.Parse(r[7].ToString());
//                unit.Desc = r[8].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit;
//        }

//        public List<Unit> LoadUnitListWithUnitCode(int UnitCode)
//        {
//            string SqlStr = "select * from tblUnits where (UnitIsDel=0) and UnitCode=@UnitCode";
//            List<Unit> unitList = new List<Unit>();
//            Unit unit;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitCode", UnitCode);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit = new Unit();
//                unit.ID = int.Parse(r[0].ToString());
//                unit.UnitCode = int.Parse(r[1].ToString());
//                unit.UnitNumber = r[2].ToString();
//                unit.UnitArea = int.Parse(r[3].ToString());
//                unit.UnitFloor = int.Parse(r[4].ToString());
//                unit.UnitPersonsNum = int.Parse(r[5].ToString());
//                unit.Type = r[6].ToString();
//                unit.UnitRooms = int.Parse(r[7].ToString());
//                unit.Desc = r[8].ToString();
//                unitList.Add(unit);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unitList;
//        }

//        public Unit LoadUnitWithUnitCodeandUnitFloor(int UnitCode, int UnitFloor)
//        {
//            string SqlStr = "select * from tblUnits where (UnitIsDel=0) and UnitCode=@UnitCode and UnitFloor=@UnitFloor";
//            List<Unit> unitList = new List<Unit>();
//            Unit unit = new Unit();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitCode", UnitCode);
//            cmd.Parameters.AddWithValue("@UnitFloor", UnitFloor);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit.ID = int.Parse(r[0].ToString());
//                unit.UnitCode = int.Parse(r[1].ToString());
//                unit.UnitNumber = r[2].ToString();
//                unit.UnitArea = int.Parse(r[3].ToString());
//                unit.UnitFloor = int.Parse(r[4].ToString());
//                unit.UnitPersonsNum = int.Parse(r[5].ToString());
//                unit.Type = r[6].ToString();
//                unit.UnitRooms = int.Parse(r[7].ToString());
//                unit.Desc = r[8].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit;
//        }
//        public List<Unit> LoadUnitList()
//        {
//            string SqlStr = "select * from tblUnits where (UnitIsDel=0) ";
//            List<Unit> unitList = new List<Unit>();
//            Unit unit;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit = new Unit();
//                unit.ID = int.Parse(r[0].ToString());
//                unit.UnitCode = int.Parse(r[1].ToString());
//                unit.UnitNumber = r[2].ToString();
//                unit.UnitArea = int.Parse(r[3].ToString());
//                unit.UnitFloor = int.Parse(r[4].ToString());
//                unit.UnitPersonsNum = int.Parse(r[5].ToString());
//                unit.Type = r[6].ToString();
//                unit.UnitRooms = int.Parse(r[7].ToString());
//                unit.Desc = r[8].ToString();

//                unitList.Add(unit);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unitList;
//        }

//        public void InsertUnit(Unit unit1)
//        {
//            string SqlStr = "Insert into tblUnits " +
//                              " (UnitCode,UnitNumber,UnitArea,UnitFloor,UnitPersonsNum,UnitType,UnitRooms,UnitDesc)" +
//                              " VALUES (@UnitCode,@UnitNumber,@UnitArea,@UnitFloor,@UnitPersonsNum,@UnitType,@UnitRooms,@UnitDesc)";
//            Unit unit = new Unit();
//            unit = unit1;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitCode", unit.UnitCode);
//            cmd.Parameters.AddWithValue("@UnitNumber", unit.UnitNumber);
//            cmd.Parameters.AddWithValue("@UnitArea", unit.UnitArea);
//            cmd.Parameters.AddWithValue("@UnitFloor", unit.UnitFloor);
//            cmd.Parameters.AddWithValue("@UnitPersonsNum", unit.UnitPersonsNum);
//            cmd.Parameters.AddWithValue("@UnitType", unit.Type);
//            cmd.Parameters.AddWithValue("@UnitRooms", unit.UnitRooms);
//            cmd.Parameters.AddWithValue("@UnitDesc", unit.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditUnit(Unit unit1)
//        {
//            string SqlStr = "UPDATE tblUnits " +
//                                  " SET UnitCode = @UnitCode,UnitNumber=@UnitNumber,UnitArea = @UnitArea, UnitFloor=@UnitFloor ,UnitPersonsNum=@UnitPersonsNum,UnitType=@UnitType,UnitRooms=@UnitRooms,UnitDesc=@UnitDesc";
//            Unit unit = new Unit();
//            unit = unit1;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitCode", unit.UnitCode);
//            cmd.Parameters.AddWithValue("@UnitNumber", unit.UnitNumber);
//            cmd.Parameters.AddWithValue("@UnitArea", unit.UnitArea);
//            cmd.Parameters.AddWithValue("@UnitFloor", unit.UnitFloor);
//            cmd.Parameters.AddWithValue("@UnitPersonsNum", unit.UnitPersonsNum);
//            cmd.Parameters.AddWithValue("@UnitType", unit.Type);
//            cmd.Parameters.AddWithValue("@UnitRooms", unit.UnitRooms);
//            cmd.Parameters.AddWithValue("@UnitDesc", unit.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteUnit(int UnitID)
//        {
//            string SqlStr = "UPDATE tblUnits SET UnitIsDel=1 where UnitID=@UnitID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.Add("@UnitID", OleDbType.Integer).Value = UnitID;
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }


//        #endregion Unit

//        #region Independent

//        public Independent LoadIndependent(int IndependentID)
//        {
//            string SqlStr = "select * from I where IndependentID=@IndependentID and (IsDel=0)";
//            Independent independent = new Independent();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@IndependentID", IndependentID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                independent.ID = int.Parse(r[0].ToString());
//                independent.Type = r[1].ToString();
//                independent.Title = r[2].ToString();
//                independent.Count = int.Parse(r[3].ToString());
//                independent.Area = int.Parse(r[4].ToString());
//                independent.FloorNum = int.Parse(r[5].ToString());
//                independent.Desc = r[6].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independent;
//        }

//        public List<Independent> LoadIndependentListWithDetailType(string DetailType)
//        {
//            string SqlStr = "select * from I where (IsDel=0) and DetailType=@DetailType";
//            List<Independent> independentList = new List<Independent>();
//            Independent independent;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@DetailType", DetailType);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                independent = new Independent();
//                independent.ID = int.Parse(r[0].ToString());
//                independent.Type = r[1].ToString();
//                independent.Title = r[2].ToString();
//                independent.Count = int.Parse(r[3].ToString());
//                independent.Area = int.Parse(r[4].ToString());
//                independent.FloorNum = int.Parse(r[5].ToString());
//                independent.Desc = r[6].ToString();
//                independentList.Add(independent);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independentList;
//        }

//        public Independent LoadIndependentWithTitle(string Title)
//        {
//            string SqlStr = "select * from I where (IsDel=0) and Title=@Title";
//            Independent independent = new Independent();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Title", Title);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                independent.ID = int.Parse(r[0].ToString());
//                independent.Type = r[1].ToString();
//                independent.Title = r[2].ToString();
//                independent.Count = int.Parse(r[3].ToString());
//                independent.Area = int.Parse(r[4].ToString());
//                independent.FloorNum = int.Parse(r[5].ToString());
//                independent.Desc = r[6].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independent;
//        }
//        public List<Independent> LoadIndependentList()
//        {
//            string SqlStr = "select * from I where (IsDel=0) ";
//            List<Independent> independentList = new List<Independent>();
//            Independent independent;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                independent = new Independent();
//                independent.ID = int.Parse(r[0].ToString());
//                independent.Type = r[1].ToString();
//                independent.Title = r[2].ToString();
//                independent.Count = int.Parse(r[3].ToString());
//                independent.Area = int.Parse(r[4].ToString());
//                independent.FloorNum = int.Parse(r[5].ToString());
//                independent.Desc = r[6].ToString();
//                independentList.Add(independent);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independentList;
//        }

//        public bool InsertIndependent(Independent independent1)
//        {
//            try
//            {
//                string SqlStr = "insert into I" +
//                                   "(DetailType,Title,Count,Area,FloorNum,Desc)" +
//                                   " VALUES (@DetailType,@Title,@Count,@Area,@FloorNum,@Desc)";
//                Independent independent = new Independent();
//                independent = independent1;
//                cn = CnnManager.Instance.GetConnection();
//                cmd = new OleDbCommand(SqlStr, cn);
//                cmd.Parameters.AddWithValue("@DetailType", independent.Type);
//                cmd.Parameters.AddWithValue("@Title", independent.Title);
//                cmd.Parameters.AddWithValue("@Count", independent.Count);
//                cmd.Parameters.AddWithValue("@Area", independent.Area);
//                cmd.Parameters.AddWithValue("@FloorNum", independent.FloorNum);
//                cmd.Parameters.AddWithValue("@Desc", independent.Desc);
//                cmd.ExecuteNonQuery();
//                CnnManager.Instance.FreeConnection();
//                return true;
//            }
//            catch { return false; }
//        }

//        public void EditIndependent(Independent independent1)
//        {
//            string SqlStr = "UPDATE [I].[dbo] " +
//                                  "SET DetailType = @DetailType, Title = @Title, Count=@Count ,Area=@Area,FloorNum=@FloorNum,Desc=@Desc";
//            Independent independent = new Independent();
//            independent = independent1;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@DetailType", independent.Type);
//            cmd.Parameters.AddWithValue("@Title", independent.Title);
//            cmd.Parameters.AddWithValue("@Count", independent.Count);
//            cmd.Parameters.AddWithValue("@Area", independent.Area);
//            cmd.Parameters.AddWithValue("@FloorNum", independent.FloorNum);
//            cmd.Parameters.AddWithValue("@Desc", independent.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteIndependent(int IndependentID)
//        {
//            string SqlStr = "UPDATE I SET IsDel=1 where IndependentID=@IndependentID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.Add("@IndependentID", OleDbType.Integer).Value = IndependentID;
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion Independent

//        #region Tower

//        public Tower LoadTower(int TowerID)
//        {
//            string SqlStr = "select * from tblTower where (TowerIsDel=0) and TowerID=@TowerID";
//            Tower tower = new Tower();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerID", TowerID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                tower.ID = int.Parse(r[0].ToString());
//                tower.TowerTitle = r[1].ToString();
//                tower.FloorCount = int.Parse(r[2].ToString());
//                tower.UnitNum = int.Parse(r[3].ToString());
//                tower.ParkingCount = int.Parse(r[4].ToString());
//                tower.Area = int.Parse(r[5].ToString());
//                tower.TowerNum = r[6].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return tower;
//        }


//        public List<Tower> LoadTowerListWithTowerTitle(string TowerTitle)
//        {
//            string SqlStr = "select * from tblTower where (TowerIsDel=0) and TowerTitle=@TowerTitle";
//            List<Tower> towerList = new List<Tower>();
//            Tower tower = new Tower();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerTitle", TowerTitle);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                tower = new Tower();
//                tower.ID = int.Parse(r[0].ToString());
//                tower.TowerTitle = r[1].ToString();
//                tower.FloorCount = int.Parse(r[2].ToString());
//                tower.UnitNum = int.Parse(r[3].ToString());
//                tower.ParkingCount = int.Parse(r[4].ToString());
//                tower.Area = int.Parse(r[5].ToString());
//                tower.TowerNum = r[6].ToString();
//                towerList.Add(tower);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return towerList;
//        }

//        public List<Tower> LoadTowerList()
//        {
//            string SqlStr = "select * from tblTower where (TowerIsDel=0) ";
//            List<Tower> towerList = new List<Tower>();
//            Tower tower;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                tower = new Tower();
//                tower.ID = int.Parse(r[0].ToString());
//                tower.TowerTitle = r[1].ToString();
//                tower.FloorCount = int.Parse(r[2].ToString());
//                tower.UnitNum = int.Parse(r[3].ToString());
//                tower.ParkingCount = int.Parse(r[4].ToString());
//                tower.Area = int.Parse(r[5].ToString());
//                tower.TowerNum = r[6].ToString();
//                towerList.Add(tower);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return towerList;
//        }

//        public void InsertTower(Tower tower1)
//        {
//            string SqlStr = "Insert into tblTower " +
//                              " (TowerTitle,FloorCount,UnitCount,ParkingCount,Area,TNumber)" +
//                              " VALUES (@TowerTitle,@FloorCount,@UnitCount,@ParkingCount,@Area,@TNumber)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Tower tower = new Tower();
//            tower = tower1;
//            cmd.Parameters.AddWithValue("@TowerTitle", tower.TowerTitle);
//            cmd.Parameters.AddWithValue("@FloorCount", tower.FloorCount);
//            cmd.Parameters.AddWithValue("@UnitCount", tower.UnitNum);
//            cmd.Parameters.AddWithValue("@ParkingCount", tower.ParkingCount);
//            cmd.Parameters.AddWithValue("@Area", tower.Area);
//            cmd.Parameters.AddWithValue("@TNumber", tower.TowerNum);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditTower(Tower Tower)
//        {
//            string SqlStr = "UPDATE tblTower " +
//                                 " SET TowerTitle = @TowerTitle, FloorCount = @FloorCount, UnitCount=@UnitCount ,ParkingCount=@ParkingCount,Area=@Area,TNumber=@TNumber";
//            Tower tower = new Tower();
//            tower = Tower;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerTitle", tower.TowerTitle);
//            cmd.Parameters.AddWithValue("@FloorCount", tower.FloorCount);
//            cmd.Parameters.AddWithValue("@UnitCount", tower.UnitNum);
//            cmd.Parameters.AddWithValue("@ParkingCount", tower.ParkingCount);
//            cmd.Parameters.AddWithValue("@Area", tower.Area);
//            cmd.Parameters.AddWithValue("@TNumber", tower.TowerNum);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteTower(int TowerID)
//        {
//            string SqlStr = "UPDATE tblTower SET TowerIsDel =1 where TowerID=@TowerID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerID", TowerID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }


//        #endregion Tower

//        #region Person

//        public Person LoadPerson(int PersonID)
//        {
//            string SqlStr = "select * from tblPersons where PersonIsDel=0 and PersonID=@PersonID";
//            Person person = new Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@PersonID", PersonID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                person.PersonID = int.Parse(r[0].ToString());
//                person.Name = r[1].ToString();
//                person.Family = r[2].ToString();
//                person.FatherName = r[3].ToString();
//                person.RegisterCardNum = r[4].ToString();
//                person.NationalCode = r[5].ToString();
//                person.Sex = bool.Parse(r[6].ToString());
//                person.PicturePath = r[7].ToString();
//                person.Telephon = r[8].ToString();
//                person.Mobile = r[9].ToString();
//                person.DateEnter = r[10].ToString();
//                person.DateExit = r[11].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return person;
//        }

//        public Person LoadPersonWithFamily(string Family)
//        {
//            string SqlStr = "select * from tblPersons where PersonIsDel=0 and Family=@Family";
//            Person person = new Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Family", Family);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                person.PersonID = int.Parse(r[0].ToString());
//                person.Name = r[1].ToString();
//                person.Family = r[2].ToString();
//                person.FatherName = r[3].ToString();
//                person.RegisterCardNum = r[4].ToString();
//                person.NationalCode = r[5].ToString();
//                person.Sex = bool.Parse(r[6].ToString());
//                person.PicturePath = r[7].ToString();
//                person.Telephon = r[8].ToString();
//                person.Mobile = r[9].ToString();
//                person.DateEnter = r[10].ToString();
//                person.DateExit = r[11].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return person;
//        }

//        public List<Person> LoadPersonList()
//        {
//            string SqlStr = "select * from tblPersons where (PersonIsDel=0)";
//            List<Person> personList = new List<Person>();
//            Person person = new Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                person = new Person();
//                person.PersonID = int.Parse(r[0].ToString());
//                person.Name = r[1].ToString();
//                person.Family = r[2].ToString();
//                person.FatherName = r[3].ToString();
//                person.RegisterCardNum = r[4].ToString();
//                person.NationalCode = r[5].ToString();
//                person.Sex = bool.Parse(r[6].ToString());
//                person.PicturePath = r[7].ToString();
//                person.Telephon = r[8].ToString();
//                person.Mobile = r[9].ToString();
//                person.DateEnter = r[10].ToString();
//                person.DateExit = r[11].ToString();
//                personList.Add(person);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return personList;
//        }

//        public List<Person> LoadPersonListWithName(string Name, string Family)
//        {
//            string SqlStr = "select * from tblPerson where (PersonIsDel=0) and Name=@Name and Family=@Family";
//            List<Person> personList = new List<Person>();
//            Person person = new Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Family", Family);
//            cmd.Parameters.AddWithValue("@Name", Name);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                person = new Person();
//                person.PersonID = int.Parse(r[0].ToString());
//                person.Name = r[1].ToString();
//                person.Family = r[2].ToString();
//                person.FatherName = r[3].ToString();
//                person.RegisterCardNum = r[4].ToString();
//                person.NationalCode = r[5].ToString();
//                person.Sex = bool.Parse(r[6].ToString());
//                person.PicturePath = r[7].ToString();
//                person.Telephon = r[8].ToString();
//                person.Mobile = r[9].ToString();
//                person.DateEnter = r[10].ToString();
//                person.DateExit = r[11].ToString();
//                personList.Add(person);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return personList;
//        }


//        public void InsertPerson(Person Person)
//        {
//            string SqlStr = "Insert into tblPersons " +
//                              " (Name,Family,FatherName,RegisterCardNum,NationalCode,Sex,PicturePath,Telephon,Mobile,DateEnter,DateExit)" +
//                              " VALUES (@Name,@Family,@FatherName,@RegisterCardNum,@NationalCode,@Sex,@PicturePath,@Telephon,@Mobile,@DateEnter,@DateExit)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Person person = new Person();
//            person = Person;
//            cmd.Parameters.AddWithValue("@Name", person.Name);
//            cmd.Parameters.AddWithValue("@Family", person.Family);
//            cmd.Parameters.AddWithValue("@FatherName", person.FatherName);
//            cmd.Parameters.AddWithValue("@RegisterCardNum", person.RegisterCardNum);
//            cmd.Parameters.AddWithValue("@NationalCode", person.NationalCode);
//            cmd.Parameters.AddWithValue("@Sex", person.Sex);
//            cmd.Parameters.AddWithValue("@PicturePath", person.PicturePath);
//            cmd.Parameters.AddWithValue("@Telephon", person.Telephon);
//            cmd.Parameters.AddWithValue("@Mobile", person.Mobile);
//            cmd.Parameters.AddWithValue("@DateEnter", person.DateEnter);
//            cmd.Parameters.AddWithValue("@DateExit", person.DateExit);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditPerson(Person Person)
//        {
//            string SqlStr = "UPDATE tblPersons " +
//                                 " SET Name = @Name, Family = @Family, FatherName=@FatherName ,RegisterCardNum=@RegisterCardNum,NationalCode=@NationalCode,Sex=@Sex,PicturePath=@PicturePath,Telephon=@Telephon,Mobile=@Mobile,DateEnter=@DateEnter,DateExit=@DateExit";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Person person = new Person();
//            person = Person;
//            cmd.Parameters.AddWithValue("@Name", person.Name);
//            cmd.Parameters.AddWithValue("@Family", person.Family);
//            cmd.Parameters.AddWithValue("@FatherName", person.FatherName);
//            cmd.Parameters.AddWithValue("@RegisterCardNum", person.RegisterCardNum);
//            cmd.Parameters.AddWithValue("@NationalCode", person.NationalCode);
//            cmd.Parameters.AddWithValue("@Sex", person.Sex);
//            cmd.Parameters.AddWithValue("@PicturePath", person.PicturePath);
//            cmd.Parameters.AddWithValue("@Telephon", person.Telephon);
//            cmd.Parameters.AddWithValue("@Mobile", person.Mobile);
//            cmd.Parameters.AddWithValue("@DateEnter", person.DateEnter);
//            cmd.Parameters.AddWithValue("@DateExit", person.DateExit);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeletePerson(long PersonID)
//        {
//            string SqlStr = "UPDATE tblPersons SET PersonIsDel =1 where PersonID=@PersonID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@PersonID", PersonID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion Person

//        #region Floor

//        public Floor LoadFloor(int FloorID)
//        {
//            string SqlStr = "select * from tblFloor where FloorID=@FloorID ";
//            Floor floor = new Floor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FloorID", FloorID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                floor.ID = int.Parse(r[0].ToString());
//                floor.FloorNum = int.Parse(r[1].ToString());
//                floor.FloorTitle = r[2].ToString();
//                floor.UnitCount = int.Parse(r[3].ToString());
//                floor.Area = r[4].ToString();
//                floor.Half = bool.Parse(r[5].ToString());
//                floor.Desc = r[6].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return floor;
//        }

//        public List<Floor> LoadFloorListWithFloorNum(int FloorNum)
//        {
//            string SqlStr = "select * from tblFloor where FloorNum=@FloorNum";
//            List<Floor> floorList = new List<Floor>();
//            Floor floor;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FloorNum", FloorNum);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                floor = new Floor();
//                floor.ID = int.Parse(r[0].ToString());
//                floor.FloorNum = int.Parse(r[1].ToString());
//                floor.FloorTitle = r[2].ToString();
//                floor.UnitCount = int.Parse(r[3].ToString());
//                floor.Area = r[4].ToString();
//                floor.Half = bool.Parse(r[5].ToString());
//                floor.Desc = r[6].ToString();
//                floorList.Add(floor);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return floorList;
//        }
//        public List<Floor> LoadFloorList()
//        {
//            string SqlStr = "select * from tblFloor ";
//            List<Floor> floorList = new List<Floor>();
//            Floor floor;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                floor = new Floor();
//                floor.ID = int.Parse(r[0].ToString());
//                floor.FloorNum = int.Parse(r[1].ToString());
//                floor.FloorTitle = r[2].ToString();
//                floor.UnitCount = int.Parse(r[3].ToString());
//                floor.Area = r[4].ToString();
//                floor.Half = bool.Parse(r[5].ToString());
//                floor.Desc = r[6].ToString();
//                floorList.Add(floor);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return floorList;
//        }

//        public void InsertFloor(Floor floor1)
//        {
//            string SqlStr = "Insert into tblFloor " +
//                              " (FloorNum,FloorTitle,UnitCount,FloorArea,HalfFloor,FloorDesc)" +
//                              " VALUES (@FloorNum,@FloorTitle,@UnitCount,@FloorArea,@HalfFloor,@FloorDesc)";
//            Floor floor = new Floor();
//            floor = floor1;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FloorNum", floor.FloorNum);
//            cmd.Parameters.AddWithValue("@FloorTitle", floor.FloorTitle);
//            cmd.Parameters.AddWithValue("@UnitCount", floor.UnitCount);
//            cmd.Parameters.AddWithValue("@FloorArea", floor.Area);
//            cmd.Parameters.AddWithValue("@HalfFloor", floor.Half);
//            cmd.Parameters.AddWithValue("@FloorDesc", floor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditFloor(Floor floor1)
//        {
//            string SqlStr = "UPDATE tblFloor " +
//                                  " SET FloorNum = @FloorNum,FloorTitle=@FloorTitle,UnitCount=@UnitCount, FloorArea = @FloorArea, HalfFloor=@HalfFloor,FloorDesc=@FloorDesc";
//            Floor floor = new Floor();
//            floor = floor1;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FloorNum", floor.FloorNum);
//            cmd.Parameters.AddWithValue("@FloorTitle", floor.FloorTitle);
//            cmd.Parameters.AddWithValue("@UnitCount", floor.UnitCount);
//            cmd.Parameters.AddWithValue("@FloorArea", floor.Area);
//            cmd.Parameters.AddWithValue("@HalfFloor", floor.Half);
//            cmd.Parameters.AddWithValue("@FloorDesc", floor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteFloor(int FloorID)
//        {
//            string SqlStr = "Delete tblFloor where FloorID=@FloorID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.Add("@FloorID", OleDbType.Integer).Value = FloorID;
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }


//        #endregion Floor

//        #region Car

//        public Car LoadCar(int CarID)
//        {
//            string SqlStr = "select * from tblCar where (CarIsDel=0) and CarID=@CarID";
//            Car car = new Car();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@CarID", CarID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                car.ID = int.Parse(r[0].ToString());
//                car.Code = r[1].ToString();
//                car.Color = r[2].ToString();
//                car.Model = r[3].ToString();
//                car.Owner = int.Parse(r[4].ToString());
//                car.Desc = r[5].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return car;
//        }

//        public List<Car> LoadCarListWithCarModel(int CarModel)
//        {
//            string SqlStr = "select * from tblCar where (CarIsDel=0) and CarModel=@CarModel";
//            List<Car> carList = new List<Car>();
//            Car car = new Car();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Connection = cn;
//            cmd.Parameters.AddWithValue("@CarModel", CarModel);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                car = new Car();
//                car.ID = int.Parse(r[0].ToString());
//                car.Code = r[1].ToString();
//                car.Color = r[2].ToString();
//                car.Model = r[3].ToString();
//                car.Owner = int.Parse(r[4].ToString());
//                car.Desc = r[5].ToString();
//                carList.Add(car);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return carList;
//        }

//        public List<Car> LoadCarList()
//        {
//            string SqlStr = "select * from tblCar where (CarIsDel=0)";
//            List<Car> carList = new List<Car>();
//            Car car = new Car();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Connection = cn;
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                car = new Car();
//                car.ID = int.Parse(r[0].ToString());
//                car.Code = r[1].ToString();
//                car.Color = r[2].ToString();
//                car.Model = r[3].ToString();
//                car.Owner = int.Parse(r[4].ToString());
//                car.Desc = r[5].ToString();
//                carList.Add(car);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return carList;
//        }


//        public void InsertCar(Car Car)
//        {
//            string SqlStr = "Insert into tblCar " +
//                              " (CarCode,CarColor,CarModel,CarOwner,CarDesc)" +
//                              " VALUES (@CarCode,@CarColor,@CarModel,@CarOwner,@CarDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Car car = new Car();
//            car = Car;
//            cmd.Parameters.AddWithValue("@CarCode", car.Code);
//            cmd.Parameters.AddWithValue("@CarColor", car.Color);
//            cmd.Parameters.AddWithValue("@CarModel", car.Model);
//            cmd.Parameters.AddWithValue("@CarOwner", car.Owner);
//            cmd.Parameters.AddWithValue("@CarDesc", car.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditCar(Car Car)
//        {
//            string SqlStr = "UPDATE tblCar " +
//                                 " SET CarCode = @CarCode, CarColor = @CarColor, CarModel=@CarModel,CarOwner=@CarOwner,CarDesc=@CarDesc";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Car car = new Car();
//            car = Car;
//            cmd.Parameters.AddWithValue("@CarCode", car.Code);
//            cmd.Parameters.AddWithValue("@CarColor", car.Color);
//            cmd.Parameters.AddWithValue("@CarModel", car.Model);
//            cmd.Parameters.AddWithValue("@CarOwner", car.Owner);
//            cmd.Parameters.AddWithValue("@CarDesc", car.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteCar(int CarID)
//        {
//            string SqlStr = "UPDATE tblCar SET CarIsDel=1 where CarID=@CarID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@CarID", CarID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion Car

//        #region Unit_Person

//        public Unit_Person LoadUnit_Person(int ID)
//        {
//            string SqlStr = "select * from Unit_Person where (IsDel=0) AND UnitID=@UnitID ";
//            Unit_Person unit_person = new Unit_Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", ID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_person.UnitID = int.Parse(r[0].ToString());
//                unit_person.PersonID = int.Parse(r[1].ToString());
//                unit_person.Relation = r[2].ToString();
//                unit_person.Desc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit_person;
//        }
//        public List<Unit_Person> LoadUnit_PersonList()
//        {
//            string SqlStr = "select * from Unit_Person where (IsDel=0) ";
//            List<Unit_Person> unit_personList = new List<Unit_Person>();
//            Unit_Person unit_person;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_person = new Unit_Person();
//                unit_person.UnitID = int.Parse(r[0].ToString());
//                unit_person.PersonID = int.Parse(r[1].ToString());
//                unit_person.Relation = r[2].ToString();
//                unit_person.Desc = r[3].ToString();
//                unit_personList.Add(unit_person);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit_personList;
//        }

//        //public List<Unit_Person> LoadUnit_PersonListWithPersonID()
//        //{
//        //    string SqlStr = "select * from Unit_Person,Person where Unit_Person.IsDel=0 and  Person.PersonID=Unit_Person.PersonID";
//        //    List<Unit_Person> unit_personList = new List<Unit_Person>();
//        //    Unit_Person unit_person;
//        //    Person person;
//        //    cn = CnnManager.Instance.GetConnection();
//        //    cmd = new OleDbCommand(SqlStr, cn);
//        //    OleDbDataReader r = cmd.ExecuteReader();
//        //    while (r.Read())
//        //    {
//        //        unit_person = new Unit_Person();
//        //        person = new Person();
//        //        unit_person.UnitID = int.Parse(r[0].ToString());
//        //        //unit_person.PersonID = int.Parse(r[1].ToString());
//        //        unit_person.Relation = r[2].ToString();
//        //        unit_person.Desc = r[3].ToString();
//        //        person.Family =r[5].ToString();
//        //        unit_personList.Add(unit_person);
//        //    }
//        //    r.Close();
//        //    CnnManager.Instance.FreeConnection();
//        //    return unit_personList;
//        //}
//        public List<Unit_Person> LoadUnit_PersonListForGrid()
//        {
//            string SqlStr = "select * from Unit_Person where (IsDel=0) ";
//            List<Unit_Person> unit_personList = new List<Unit_Person>();
//            Unit_Person unit_person;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_person = new Unit_Person();
//                unit_person.UnitID = int.Parse(r[0].ToString());
//                unit_person.PersonID = int.Parse(r[1].ToString());
//                unit_person.Relation = r[2].ToString();
//                unit_person.Desc = r[3].ToString();
//                unit_personList.Add(unit_person);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit_personList;
//        }
//        public List<Person> LoadPersonWithUnitID(int UnitID)
//        {
//            string SqlStr = "select * from Unit_Person where UnitID=@UnitID AND IsDel=0";
//            Unit_Person unit_person = new Unit_Person();
//            List<Unit_Person> unit_personList = new List<Unit_Person>();
//            Person person = new Person();
//            List<Person> PersonList = new List<Person>();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unit_person = new Unit_Person();
//                unit_person.UnitID = int.Parse(r[0].ToString());
//                unit_person.PersonID = int.Parse(r[1].ToString());
//                unit_person.Relation = r[2].ToString();
//                unit_person.Desc = r[3].ToString();
//                unit_personList.Add(unit_person);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; unit_personList.Count > i; i++)
//            {
//                person = new Person();
//                person = LoadPerson(unit_personList[i].PersonID);
//                PersonList.Add(person);
//            }

//            return PersonList;
//        }

//        public List<Unit> LoadUnitWithPersonID(int PersonID)
//        {
//            string SqlStr = "select * from Unit_Person where PersonID=@PersonID AND IsDel=0";
//            Unit_Person unit_person = new Unit_Person();
//            List<Unit_Person> unit_personList = new List<Unit_Person>();
//            Unit unit = new Unit();
//            List<Unit> unitList = new List<Unit>();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@PersonID", PersonID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unit_person = new Unit_Person();
//                unit_person.UnitID = int.Parse(r[0].ToString());
//                unit_personList.Add(unit_person);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; unit_personList.Count > i; i++)
//            {
//                unit = new Unit();
//                unit = LoadUnit(unit_personList[i].UnitID);
//                unitList.Add(unit);
//            }

//            return unitList;
//        }
//        public void InsertUnit_Person(Unit_Person UnitPerson)
//        {
//            string SqlStr = "Insert into Unit_Person " +
//                              " (UnitID,PersonID,Relation,Desc)" +
//                              " VALUES (@UnitID,@PersonID,@Relation,@Desc)";
//            Unit_Person unit_person = new Unit_Person();
//            unit_person = UnitPerson;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);

//            cmd.Parameters.AddWithValue("@UnitID", unit_person.UnitID);
//            cmd.Parameters.AddWithValue("@PersonID", unit_person.PersonID);
//            cmd.Parameters.AddWithValue("@Relation", unit_person.Relation);
//            cmd.Parameters.AddWithValue("@Desc", unit_person.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditUnit_Person(Unit_Person UnitPerson)
//        {
//            string SqlStr = "UPDATE Unit_Person " +
//                                 " SET PersonID = @PersonID, UnitID = @UnitID,Relation=@Relation,Desc=@Desc ";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Unit_Person unit_person = new Unit_Person();
//            unit_person = UnitPerson;
//            cmd.Parameters.AddWithValue("@PersonID", unit_person.PersonID);
//            cmd.Parameters.AddWithValue("@UnitID", unit_person.UnitID);
//            cmd.Parameters.AddWithValue("@Relation", unit_person.Relation);
//            cmd.Parameters.AddWithValue("@Desc", unit_person.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteUnit_Person(int UnitID, int PersonID)
//        {
//            string SqlStr = "UPDATE Unit_Person SET IsDel=1 where UnitID=@UnitID and PersonID=@PersonID";
//            Unit_Person unit_person = new Unit_Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", unit_person.UnitID);
//            cmd.Parameters.AddWithValue("@PersonID", unit_person.PersonID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }


//        #endregion Unit_Person

//        #region Tower_Unit

//        public Unit LoadUnitWithTowerID(int TowerID)
//        {
//            string SqlStr = "select * from Tower_Unit where TowerID=@TowerID";
//            Unit unit = new Unit();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerID", TowerID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unit.ID = int.Parse(r[0].ToString());
//                unit.UnitCode = int.Parse(r[1].ToString());
//                unit.UnitArea = int.Parse(r[2].ToString());
//                unit.UnitFloor = int.Parse(r[3].ToString());
//                unit.UnitPersonsNum = int.Parse(r[4].ToString());
//                unit.Type = r[5].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit;
//        }

//        public Tower LoadTowerWithUnitID(int UnitID)
//        {
//            string SqlStr = "select * from Tower_Unit where UnitID=@UnitID";
//            Tower tower = new Tower();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                tower.ID = int.Parse(r[0].ToString());
//                tower.TowerTitle = r[1].ToString();
//                tower.FloorCount = int.Parse(r[2].ToString());
//                tower.UnitNum = int.Parse(r[3].ToString());
//                tower.ParkingCount = int.Parse(r[4].ToString());
//                tower.Area = int.Parse(r[5].ToString());
//                tower.TowerNum = r[6].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return tower;
//        }

//        //public void InsertUnit(Unit unit)
//        //{
//        //    cn = CnnManager.Instance.GetConnection();
//        //    cmd = new OleDbCommand();
//        //    cmd.Connection = cn;
//        //    cmd.CommandType = CommandType.Text;
//        //    cmd.CommandText = "Insert into tblUnits " +
//        //                      " (UnitCode,UnitArea,UnitFloor,UnitPersonsNum,UnitType" +
//        //                      " VALUES (@UnitCode,@UnitArea,@UnitFloor,@UnitPersonsNum,@UnitType)";

//        //    Unit f = new Unit();
//        //    f = unit;
//        //    cmd.Parameters.AddWithValue("@UnitCode", f.UnitCode);
//        //    cmd.Parameters.AddWithValue("@UnitArea", f.UnitArea);
//        //    cmd.Parameters.AddWithValue("@UnitFloor", f.UnitFloor);
//        //    cmd.Parameters.AddWithValue("@UnitPersonsNum", f.UnitPersonsNum);
//        //    cmd.Parameters.AddWithValue("@UnitType", f.Type);

//        //    cmd.ExecuteNonQuery();
//        //    CnnManager.Instance.FreeConnection();
//        //}

//        //public void EditUnit(Unit unit)
//        //{
//        //    cn = CnnManager.Instance.GetConnection();
//        //    cmd = new OleDbCommand();
//        //    cmd.Connection = cn;
//        //    cmd.CommandText = "UPDATE    tblUnits " +
//        //                         " SET  UnitCode = @UnitCode, UnitArea = @UnitArea, UnitFloor=@UnitFloor ,UnitPersonsNum=@UnitPersonsNum,UnitType=@UnitType" +
//        //                         " where  UnitID = @UnitID";
//        //    Unit f = new Unit();
//        //    f = unit;
//        //    cmd.Parameters.AddWithValue("@UnitCode", f.UnitCode);
//        //    cmd.Parameters.AddWithValue("@UnitArea", f.UnitArea);
//        //    cmd.Parameters.AddWithValue("@UnitFloor", f.UnitFloor);
//        //    cmd.Parameters.AddWithValue("@UnitPersonsNum", f.UnitPersonsNum);
//        //    cmd.Parameters.AddWithValue("@UnitType", f.Type);

//        //    cmd.ExecuteNonQuery();
//        //    CnnManager.Instance.FreeConnection();
//        //}

//        public void DeleteTower_Unit(int UnitID, int TowerID)
//        {
//            string SqlStr = "UPDATE Tower_Unit SET IsDel =1 where UnitID=@UnitID and TowerID=@TowerID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            cmd.Parameters.AddWithValue("@TowerID", TowerID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion Tower_Unit

//        #region Tower_Person

//        public List<Person> LoadPersonListWithTowerID(int TowerID)
//        {
//            string SqlStr = "select * from Tower_Unit,Unit_Person where Tower_Unit.IsDel=0 and Unit_Person.IsDel=0 and Tower_Unit.TowerID=" + TowerID;
//            List<Person> personList = new List<Person>();
//            Person person = new Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                person = new Person();
//                person.PersonID = int.Parse(r[0].ToString());
//                person.Name = r[1].ToString();
//                person.Family = r[2].ToString();
//                person.FatherName = r[3].ToString();
//                person.RegisterCardNum = r[4].ToString();
//                person.NationalCode = r[5].ToString();
//                person.Sex = bool.Parse(r[6].ToString());
//                person.PicturePath = r[7].ToString();
//                person.DateEnter = r[8].ToString();
//                person.DateExit = r[9].ToString();
//                personList.Add(person);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return personList;
//        }
//        #endregion Tower_Person

//        #region Parking

//        public Parking LoadParking(int ParkingID)
//        {
//            string SqlStr = "select * from tblParking where ParkingID=@ParkingID";
//            Parking parking = new Parking();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ParkingID", ParkingID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                parking.ParkCode = r[1].ToString();
//                parking.ParkSize = int.Parse(r[2].ToString());
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return parking;
//        }

//        public List<Parking> LoadParkingList(int ParkingID)
//        {
//            string SqlStr = "select * from tblParking where (ParkingIsDel=0) and ParkingID=@ParkingID";
//            List<Parking> parkingList = new List<Parking>();
//            Parking parking;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ParkingID", ParkingID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                parking = new Parking();
//                parking.ParkCode = r[1].ToString();
//                parking.ParkSize = int.Parse(r[2].ToString());
//                parkingList.Add(parking);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return parkingList;
//        }



//        public void InsertParking(Parking parking1)
//        {
//            string SqlStr = "Insert into tblParking " +
//                              " (ParkingCode,ParkingSize,ParkingDesc)" +
//                              " VALUES (@ParkingCode,@ParkingSize,@ParkingDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Parking parking = new Parking();
//            parking = parking1;
//            cmd.Parameters.AddWithValue("@ParkingCode", parking.ParkCode);
//            cmd.Parameters.AddWithValue("@ParkingSize", parking.ParkSize);
//            cmd.Parameters.AddWithValue("@ParkingDesc", parking.ParkDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditParking(Parking parking1)
//        {
//            string SqlStr = "UPDATE tblParking " +
//                                 " SET ParkingCode = @ParkingCode, ParkingSiz= @ParkingSiz,ParkingDesc=@ParkingDesc";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Parking parking = new Parking();
//            parking = parking1;
//            cmd.Parameters.AddWithValue("@ParkingCode", parking.ParkCode);
//            cmd.Parameters.AddWithValue("@ParkingSize", parking.ParkSize);
//            cmd.Parameters.AddWithValue("@ParkingDesc", parking.ParkDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteParking(int ParkingID)
//        {
//            string SqlStr = "UPDATE tblParking SET ParkingIsDel =1 where ParkingID=@ParkingID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ParkingID", ParkingID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion Parking

//        #region TowerInfo

//        public TowerInfo LoadTowerInfo(int TowerInfoID)
//        {
//            string SqlStr = "select * from tblTowerInfo where TowerInfoID=@TowerInfoID";
//            TowerInfo towerInfo = new TowerInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerInfoID", TowerInfoID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                towerInfo.TowerInfoID = int.Parse(r[0].ToString());
//                towerInfo.InfoID = int.Parse(r[1].ToString());
//                towerInfo.TowerInfoValue = r[2].ToString();
//                towerInfo.TowerInfoDesc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return towerInfo;
//        }


//        public List<TowerInfo> LoadTowerInfoList(string TowerInfoValue)
//        {
//            string SqlStr = "select * from tblTowerInfo where (TowerIsDel=0) and TowerInfoValue=@TowerInfoValue";
//            List<TowerInfo> towerInfoList = new List<TowerInfo>();
//            TowerInfo towerInfo;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@TowerInfoValue", TowerInfoValue);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                towerInfo = new TowerInfo();
//                towerInfo.TowerInfoID = int.Parse(r[0].ToString());
//                towerInfo.InfoID = int.Parse(r[1].ToString());
//                towerInfo.TowerInfoValue = r[2].ToString();
//                towerInfo.TowerInfoDesc = r[3].ToString();
//                towerInfoList.Add(towerInfo);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return towerInfoList;
//        }

//        public void InsertTowerInfo(TowerInfo towerInfo1)
//        {
//            string SqlStr = "Insert into tblTowerInfo " +
//                              " (InfoID,TowerInfoValue,TowerInfoDesc)" +
//                              " VALUES (@InfoID,@TowerInfoValue,@TowerInfoDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            TowerInfo towerInfo = new TowerInfo();
//            towerInfo = towerInfo1;
//            cmd.Parameters.AddWithValue("@InfoID", towerInfo.InfoID);
//            cmd.Parameters.AddWithValue("@TowerInfoValue", towerInfo.TowerInfoValue);
//            cmd.Parameters.AddWithValue("@TowerInfoDesc", towerInfo.TowerInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditTowerInfo(TowerInfo towerInfo1)
//        {
//            string SqlStr = "UPDATE tblTowerInfo " +
//                                 " SET InfoID = @InfoID, TowerInfoValue = @TowerInfoValue, TowerInfoDesc=@TowerInfoDesc";
//            TowerInfo towerInfo = new TowerInfo();
//            towerInfo = towerInfo1;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@InfoID", towerInfo.InfoID);
//            cmd.Parameters.AddWithValue("@TowerInfoValue", towerInfo.TowerInfoValue);
//            cmd.Parameters.AddWithValue("@TowerInfoDesc", towerInfo.TowerInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteTowerInfo(long InfoID)
//        {
//            string SqlStr = "UPDATE tblTowerInfo SET TowerIsDel =1 where InfoID=@InfoID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@InfoID", InfoID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion TowerInfo

//        #region PersonsInfo

//        public PersonsInfo LoadPersonInfo(int PersonsInfoID)
//        {
//            string SqlStr = "select * from tblPersonsInfo where PersonID=@PersonID";
//            PersonsInfo personsInfo = new PersonsInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@PersonID", PersonsInfoID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                personsInfo.PersonInfoID = int.Parse(r[1].ToString());
//                personsInfo.PersonID = int.Parse(r[2].ToString());
//                personsInfo.DetailInfoID = int.Parse(r[3].ToString());
//                personsInfo.PersonInfoValue = r[4].ToString();
//                personsInfo.PersonInfoDesc = r[5].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return personsInfo;
//        }

//        public List<PersonsInfo> LoadPersonsInfoList(string Name, string Family)
//        {
//            string SqlStr = "select * from tblPersonsInfo where (PersonIsDel=0) and Name=@Name and Family=@Family";
//            List<PersonsInfo> personsInfoList = new List<PersonsInfo>();
//            PersonsInfo personsInfo = new PersonsInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Name", Name);
//            cmd.Parameters.AddWithValue("@Family", Family);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                personsInfo = new PersonsInfo();
//                personsInfo.PersonInfoID = int.Parse(r[1].ToString());
//                personsInfo.PersonID = int.Parse(r[2].ToString());
//                personsInfo.DetailInfoID = int.Parse(r[3].ToString());
//                personsInfo.PersonInfoValue = r[4].ToString();
//                personsInfo.PersonInfoDesc = r[5].ToString();
//                personsInfoList.Add(personsInfo);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return personsInfoList;
//        }

//        public void InsertPersonsInfo(PersonsInfo personsInfo1)
//        {
//            string SqlStr = "Insert into tblPersonsInfo " +
//                              " (PersonInfoID,PersonID,DetailInfoID,PersonInfoValue,PersonInfoDesc)" +
//                              " VALUES (@PersonInfoID,@PersonID,@DetailInfoID,@PersonInfoValue,@PersonInfoDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            PersonsInfo personsInfo = new PersonsInfo();
//            personsInfo = personsInfo1;
//            cmd.Parameters.AddWithValue("@PersonInfoID", personsInfo.PersonInfoID);
//            cmd.Parameters.AddWithValue("@PersonID", personsInfo.PersonID);
//            cmd.Parameters.AddWithValue("@DetailInfoID", personsInfo.DetailInfoID);
//            cmd.Parameters.AddWithValue("@PersonInfoValue", personsInfo.PersonInfoValue);
//            cmd.Parameters.AddWithValue("@PersonInfoDesc", personsInfo.PersonInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditPersonsInfo(PersonsInfo personsInfo1)
//        {
//            string SqlStr = "UPDATE tblPersonsInfo " +
//                                 " SET PersonID = @PersonID, DetailInfoID = @DetailInfoID, PersonInfoValue=@PersonInfoValue ,PersonInfoDesc=@PersonInfoDesc";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            PersonsInfo personsInfo = new PersonsInfo();
//            personsInfo = personsInfo1;
//            cmd.Parameters.AddWithValue("@PersonInfoID", personsInfo.PersonInfoID);
//            cmd.Parameters.AddWithValue("@PersonID", personsInfo.PersonID);
//            cmd.Parameters.AddWithValue("@DetailInfoID", personsInfo.DetailInfoID);
//            cmd.Parameters.AddWithValue("@PersonInfoValue", personsInfo.PersonInfoValue);
//            cmd.Parameters.AddWithValue("@PersonInfoDesc", personsInfo.PersonInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeletePersonsInfo(int PersonsInfoID)
//        {
//            string SqlStr = "UPDATE tblPersonsInfo SET PersonIsDel =1 and PersonInfoID=@PersonInfoID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@PersonInfoID", PersonsInfoID);
//            cmd.CommandType = CommandType.Text;
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion PersonsInfo

//        #region   DetailInfo
//        //public DataTable LoadDetailInfoForGrid()
//        //{
//        //    //string SqlStr = "select * from tblDetailInfo on tblDetailInfo.BaseInfoID=tblBaseInfo.BaseInfoID";
//        //    //DetailInfo detailInfo = new DetailInfo();
//        //    //DataTable dt = new DataTable();
//        //    //dt.
//        //    cn = CnnManager.Instance.GetConnection();
//        //    //cmd = new OleDbCommand(SqlStr, cn);
//        //    //cmd.CommandType = CommandType.Text;
//        //    CnnManager.Instance.FreeConnection();
//        //    DataTable dt = new DataTable("tblDetailInfo");
//        //    dt.Columns.Add("tblDetailInfoID", typeof(int));
//        //    dt.Columns.Add("DetailInfoTitle", typeof(string));
//        //    dt.Columns.Add("BaseInfoID", typeof(int));
//        //    dt.Columns.Add("DetailInfoDesc", typeof(string));
//        //    CnnManager.Instance.FreeConnection();
//        //    return dt;
//        //}
//        public DataTable LoadDetailInfoForGrid(Int64 BaseInfoID)
//        {
//            //string SqlStr = "SELECT tblDetailInfo.DetailInfoTitle,tblBaseInfo.BaseInfoTitle,tblDetailInfo.DetailInfoDesc " +
//                //"FROM tblBaseInfo,tblDetailInfo " +
//                //" WHERE tblDetailInfo.BaseInfoID=@BaseInfoID and tblBaseInfo.BaseInfoID=tblDetailInfo.BaseInfoID";
//            string SqlStr = "select * from tblDetailInfo WHERE BaseInfoID=@BaseInfoID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd.Parameters.AddWithValue("@BaseInfoID", BaseInfoID);
//            cmd = new OleDbCommand(SqlStr, cn);

//            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
//            DataTable dt = new DataTable("tblDetailInfo");
//            dt.Columns.Add("DetailInfoTitle", typeof(string));
//            dt.Columns.Add("BaseInfoTitle", typeof(string));
//            dt.Columns.Add("DetailInfoDesc", typeof(string));
//            CnnManager.Instance.FreeConnection();
//            //Da.Fill(dt);
//            return dt;
//        }

//        public DetailInfo LoadDetailInfoWithTitle(string DetailInfoTitle)
//        {
//            string SqlStr = "select * from tblDetailInfo where DetailInfoTitle=@DetailInfoTitle";
//            DetailInfo detailInfo = new DetailInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@DetailInfoTitle", DetailInfoTitle);
//            cmd.CommandType = CommandType.Text;
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
//                detailInfo.DetailInfoTitle = r[1].ToString();
//                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
//                detailInfo.DetailInfoDesc = r[3].ToString();
//            }
//            CnnManager.Instance.FreeConnection();
//            return detailInfo;
//        }

//        public DetailInfo LoadDetailInfo(int DetailInfoID)
//        {
//            string SqlStr = "select * from tblDetailInfo where DetailInfoID=@DetailInfoID AND (IsDel=0)";
//            DetailInfo detailInfo = new DetailInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@DetailInfoID", DetailInfoID);
//            cmd.CommandType = CommandType.Text;
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
//                detailInfo.DetailInfoTitle = r[1].ToString();
//                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
//                detailInfo.DetailInfoDesc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return detailInfo;
//        }
//        public List<DetailInfo> LoadDetailInfoListWithBaseID(int baseInfoID)
//        {
//            string SqlStr = "select * from tblDetailInfo where (IsDel=0) and BaseInfoID=@BaseInfoID ORDER BY DetailInfoTitle"; ;
//            DetailInfo Detail = new DetailInfo();
//            List<DetailInfo> DList = new List<DetailInfo>();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@BaseInfoID", baseInfoID);
//            DataTable r = new DataTable();
//            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
//            da.Fill(r);
//            for (int co = 0; co < r.Rows.Count; co++)
//            {
//                Detail = new DetailInfo();
//                Detail.DetailInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(0));
//                Detail.DetailInfoTitle = r.Rows[co].ItemArray.GetValue(1).ToString();
//                Detail.BaseInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(2));
//                Detail.DetailInfoDesc = r.Rows[co].ItemArray.GetValue(3).ToString();
//                DList.Add(Detail);
//            }

//            CnnManager.Instance.FreeConnection();
//            return DList;
//        }

//        public List<DetailInfo> LoadDetailInfoList()
//        {
//            string SqlStr = "select * from tblDetailInfo where (IsDel=0)";
//            DetailInfo Detail = new DetailInfo();
//            List<DetailInfo> DList = new List<DetailInfo>();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            DataTable r = new DataTable();
//            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
//            da.Fill(r);
//            for (int co = 0; co < r.Rows.Count; co++)
//            {
//                Detail = new DetailInfo();
//                Detail.DetailInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(0));
//                Detail.DetailInfoTitle = r.Rows[co].ItemArray.GetValue(1).ToString();
//                Detail.BaseInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(2));
//                Detail.DetailInfoDesc = r.Rows[co].ItemArray.GetValue(3).ToString();
//                DList.Add(Detail);
//            }

//            CnnManager.Instance.FreeConnection();
//            return DList;
//        }


//        public void InsertDetailInfo(DetailInfo detailInfo1)
//        {
//            string SqlStr = "Insert into tblDetailInfo " +
//                              " (DetailInfoTitle,BaseInfoID,DetailInfoDesc)" +
//                              " VALUES (@DetailInfoTitle,@BaseInfoID,@DetailInfoDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            DetailInfo detailInfo = new DetailInfo();
//            detailInfo = detailInfo1;
//            cmd.Parameters.AddWithValue("@DetailInfoTitle", detailInfo.DetailInfoTitle);
//            cmd.Parameters.AddWithValue("@BaseInfoID", detailInfo.BaseInfoID);
//            cmd.Parameters.AddWithValue("@DetailInfoDesc", detailInfo.DetailInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditDetailInfo(DetailInfo DetailInfo)
//        {
//            string SqlStr = "UPDATE tblDetailInfo " +
//                                 " SET DetailInfoTitle = @DetailInfoTitle, BaseInfoID = @BaseInfoID, DetailInfoDesc=@DetailInfoDesc ";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            DetailInfo detailInfo = new DetailInfo();
//            detailInfo = DetailInfo;
//            cmd.Parameters.AddWithValue("@DetailInfoTitle", detailInfo.DetailInfoTitle);
//            cmd.Parameters.AddWithValue("@BaseInfoID", detailInfo.BaseInfoID);
//            cmd.Parameters.AddWithValue("@DetailInfoDesc", detailInfo.DetailInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteDetailInfo(int detailInfoID)
//        {
//            string SqlStr = "UPDATE tblDetailInfo SET IsDel=1 where DetailInfoID=@DetailInfoID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@DetailInfoID", detailInfoID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion  DetailInfo

//        #region CarInfo

//        public CarInfo LoadCarInfo(int CarInfoID)
//        {
//            string SqlStr = "select * from tblCarInfo where CarInfoID=@CarInfoID";
//            CarInfo carInfo = new CarInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@CarInfoID", CarInfoID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                carInfo.CarInfoID = int.Parse(r[1].ToString());
//                carInfo.InfoID = int.Parse(r[2].ToString());
//                carInfo.CarInfoValue = r[3].ToString();
//                carInfo.CarInfoDesc = r[4].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return carInfo;
//        }

//        public List<CarInfo> LoadCarInfoList(string CarInfoValue)
//        {
//            string SqlStr = "select * from tblCarInfo where (IsDel=0) and CarInfoValue=@CarInfoValue";
//            List<CarInfo> carInfoList = new List<CarInfo>();
//            CarInfo carInfo = new CarInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@CarInfoValue", CarInfoValue);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                carInfo = new CarInfo();
//                carInfo.CarInfoID = int.Parse(r[0].ToString());
//                carInfo.InfoID = int.Parse(r[1].ToString());
//                carInfo.CarInfoValue = r[2].ToString();
//                carInfo.CarInfoDesc = r[3].ToString();
//                carInfoList.Add(carInfo);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return carInfoList;
//        }

//        public void InsertCarInfo(CarInfo carInfo1)
//        {
//            string SqlStr = "Insert into tblCarInfo " +
//                              " (CarInfoID,InfoID,CarInfoValue,CarInfoDesc)" +
//                              " VALUES (@CarInfoID,@InfoID,@CarInfoValue,@CarInfoDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            CarInfo carInfo = new CarInfo();
//            carInfo = carInfo1;
//            cmd.Parameters.AddWithValue("@CarInfoID", carInfo.CarInfoID);
//            cmd.Parameters.AddWithValue("@InfoID", carInfo.InfoID);
//            cmd.Parameters.AddWithValue("@CarInfoValue", carInfo.CarInfoValue);
//            cmd.Parameters.AddWithValue("@CarInfoDesc", carInfo.CarInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditCarInfo(CarInfo carInfo1)
//        {
//            string SqlStr = "UPDATE tblCarInfo " +
//                                 " SET CarInfoID = @CarInfoID, InfoID = @InfoID, CarInfoValue=@CarInfoValue ,CarInfoDesc=@CarInfoDesc";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            CarInfo carInfo = new CarInfo();
//            carInfo = carInfo1;
//            cmd.Parameters.AddWithValue("@CarInfoID", carInfo.CarInfoID);
//            cmd.Parameters.AddWithValue("@InfoID", carInfo.InfoID);
//            cmd.Parameters.AddWithValue("@CarInfoValue", carInfo.CarInfoValue);
//            cmd.Parameters.AddWithValue("@CarInfoDesc", carInfo.CarInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteCarInfo(int CarInfoID)
//        {
//            string SqlStr = "UPDATE tblCarInfo SET IsDel =1 where CarInfoID=@CarInfoID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@CarInfoID", CarInfoID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion CarInfo

//        #region UnitInfo

//        public UnitInfo LoadUnitInfo(int UnitInfoID)
//        {
//            string SqlStr = "select * from tblUnitInfo where UnitInfoID=@UnitInfoID AND (IsDel=0)";
//            UnitInfo unitInfo = new UnitInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitInfoID", UnitInfoID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unitInfo.UnitInfoID = int.Parse(r[0].ToString());
//                unitInfo.InfoID = int.Parse(r[1].ToString());
//                unitInfo.UnitInfoValue = r[2].ToString();
//                unitInfo.UnitInfoDesc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unitInfo;
//        }

//        //public UnitInfoList LoadUnitInfoList(string UnitInfoValue)
//        //{
//        //    string SqlStr = "select * from tblUnitInfo where (IsDel=0) ";
//        //    UnitInfoList FList = new UnitInfoList();
//        //    UnitInfo f = new UnitInfo();
//        //    cn = CnnManager.Instance.GetConnection();
//        //    cmd = new OleDbCommand(SqlStr, cn);
//        //    cmd.CommandType = CommandType.Text;
//        //    cmd.Parameters.AddWithValue("@UnitInfoValue", UnitInfoValue);
//        //    OleDbDataReader r = cmd.ExecuteReader();
//        //    while (r.Read())
//        //    {
//        //        f.UnitInfoID = int.Parse(r[1].ToString());
//        //        f.InfoID = int.Parse(r[2].ToString());
//        //        f.UnitInfoValue = r[3].ToString();
//        //        f.UnitInfoDesc = r[4].ToString();
//        //        FList.Add(f);
//        //    }
//        //    r.Close();
//        //    CnnManager.Instance.FreeConnection();
//        //    return FList;
//        //}

//        public List<UnitInfo> LoadUnitInfoList()
//        {
//            string SqlStr = "select * from tblUnitInfo where (IsDel=0)";
//            List<UnitInfo> unitInfoList = new List<UnitInfo>();
//            UnitInfo unitInfo = new UnitInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unitInfo = new UnitInfo();
//                unitInfo.UnitInfoID = int.Parse(r[0].ToString());
//                unitInfo.InfoID = int.Parse(r[1].ToString());
//                unitInfo.UnitInfoValue = r[2].ToString();
//                unitInfo.UnitInfoDesc = r[3].ToString();
//                unitInfoList.Add(unitInfo);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unitInfoList;
//        }

//        public void InsertUnitInfo(UnitInfo UnitInfo)
//        {
//            string SqlStr = "Insert into tblUnitInfo" +
//                              " (InfoID,UnitInfoValue,UnitInfoDesc)" +
//                              " VALUES (@InfoID,@UnitInfoValue,@UnitInfoDesc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            UnitInfo unitInfo = new UnitInfo();
//            unitInfo = UnitInfo;
//            //cmd.Parameters.AddWithValue("@UnitInfoID", unitInfo.UnitInfoID);
//            cmd.Parameters.AddWithValue("@InfoID", unitInfo.InfoID);
//            cmd.Parameters.AddWithValue("@UnitInfoValue", unitInfo.UnitInfoValue);
//            cmd.Parameters.AddWithValue("@UnitInfoDesc", unitInfo.UnitInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditUnitInfo(UnitInfo UnitInfo)
//        {
//            string SqlStr = "UPDATE tblUnitInfo " +
//                                 " SET InfoID = @InfoID, vInfoValue=@UnitInfoValue ,UnitInfoDesc=@UnitInfoDesc";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            UnitInfo unitInfo = new UnitInfo();
//            unitInfo = UnitInfo;
//            cmd.Parameters.AddWithValue("@InfoID", unitInfo.InfoID);
//            cmd.Parameters.AddWithValue("@UnitInfoValue", unitInfo.UnitInfoValue);
//            cmd.Parameters.AddWithValue("@UnitInfoDesc", unitInfo.UnitInfoDesc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteUnitInfo(int UnitInfoID)
//        {
//            string SqlStr = "UPDATE tblUnitInfo SET IsDel=1 where UnitInfoID=@UnitInfoID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitInfoID", UnitInfoID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion UnitInfo

//        #region BaseInfo

//        public List<BaseInfo> LoadBaseInfoList()
//        {
//            string SqlStr = "select * from tblBaseInfo ORDER BY BaseInfoTitle";
//            List<BaseInfo> baseInfoList = new List<BaseInfo>();
//            BaseInfo baseInfo = new BaseInfo();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                baseInfo = new BaseInfo();
//                baseInfo.BaseInfoID = int.Parse(r[0].ToString());
//                baseInfo.BaseInfoTitle = r[1].ToString();
//                baseInfo.BaseInfoDesc = r[2].ToString();
//                baseInfoList.Add(baseInfo);
//            }

//            CnnManager.Instance.FreeConnection();
//            return baseInfoList;
//        }

//        public BaseInfo LoadBaseInfo(int baseInfoID)
//        {
//            string SqlStr = "select * from tblBaseInfo where BaseInfoID=@BaseInfoID";
//            BaseInfo baseInfo = new BaseInfo();
//            BaseInfo[] baseInfoList = new BaseInfo[4];
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@BaseInfoID", baseInfoID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            int i = 0;
//            if (r.Read())
//            {
//                baseInfo.BaseInfoID = int.Parse(r[0].ToString());
//                baseInfo.BaseInfoTitle = r[1].ToString();
//                baseInfo.BaseInfoDesc = r[2].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return baseInfo;
//        }
//        #endregion BaseInfo

//        #region Person_Car

//        public List<Person> LoadPersonWithCarID(int CarID)
//        {
//            string SqlStr = "select * from Person_Car where IsDel=0 and CarID=@CarID";
//            Person_Car person_car = new Person_Car();
//            List<Person_Car> person_carList = new List<Person_Car>();
//            List<Person> personList = new List<Person>();
//            Person person = new Person();
//            cn = CnnManager.Instance.GetConnection();
//            cmd.Parameters.AddWithValue("@CarID", CarID);
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                person_car = new Person_Car();
//                person_car.PersonID = int.Parse(r[0].ToString());
//                person_carList.Add(person_car);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; person_carList.Count > i; i++)
//            {
//                person = new Person();
//                person = LoadPerson(person_carList[i].PersonID);
//                personList.Add(person);
//            }
//            return personList;
//        }
//        public List<Car> LoadCarsWithPersonID(int PersonID)
//        {
//            string SqlStr = "select * from Person_Car where PersonID=@PersonID";
//            Person_Car person_car = new Person_Car();
//            List<Person_Car> person_carList = new List<Person_Car>();
//            Car car = new Car();
//            List<Car> carList = new List<Car>();
//            cmd.Parameters.AddWithValue("@PersonID", PersonID);
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                person_car = new Person_Car();
//                person_car.CarID = int.Parse(r[1].ToString());
//                person_carList.Add(person_car);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; person_carList.Count > i; i++)
//            {
//                car = new Car();
//                car = LoadCar(person_carList[i].CarID);
//                carList.Add(car);
//            }

//            return carList;
//        }

//        #endregion Person_Car

//        #region Unit_Car

//        public List<Unit> LoadUnitWithCarID(int CarID)
//        {
//            string SqlStr = "select * from Unit_Car where IsDel=0 and CarID=@CarID";
//            Unit_Car unit_car = new Unit_Car();
//            List<Unit_Car> unit_carList = new List<Unit_Car>();
//            List<Unit> unitList = new List<Unit>();
//            Unit unit = new Unit();
//            cn = CnnManager.Instance.GetConnection();
//            cmd.Parameters.AddWithValue("@CarID", CarID);
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_car = new Unit_Car();
//                unit_car.UnitID = int.Parse(r[0].ToString());
//                unit_carList.Add(unit_car);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; unit_carList.Count > i; i++)
//            {
//                unit = new Unit();
//                unit = LoadUnit(unit_carList[i].UnitID);
//                unitList.Add(unit);
//            }
//            return unitList;
//        }
//        public List<Car> LoadCarsWithUnitID(int UnitID)
//        {
//            string SqlStr = "select * from Unit_Car where UnitID=@UnitID";
//            Unit_Car unit_car = new Unit_Car();
//            List<Unit_Car> unit_carList = new List<Unit_Car>();
//            Car car = new Car();
//            List<Car> carList = new List<Car>();
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unit_car = new Unit_Car();
//                unit_car.CarID = int.Parse(r[1].ToString());
//                unit_carList.Add(unit_car);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; unit_carList.Count > i; i++)
//            {
//                car = new Car();
//                carList.Add(car);
//            }

//            return carList;
//        }

//        #endregion Unit_Car

//        #region Contor

//        public Contor LoadContor(int ContorID)
//        {
//            string SqlStr = "select * from tblContor where (ContorIsDel=0) and ContorID=@ContorID";
//            Contor contor = new Contor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ContorID", ContorID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                contor.ContorID = int.Parse(r[0].ToString());
//                contor.ContorNum = int.Parse(r[1].ToString());
//                contor.ContorValue = r[2].ToString();
//                contor.Desc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return contor;
//        }


//        public List<Contor> LoadContorListWithContorTitle(string ContorValue)
//        {
//            string SqlStr = "select * from tblContor where (ContorIsDel=0) and ContorValue=@ContorValue";
//            List<Contor> contorList = new List<Contor>();
//            Contor contor = new Contor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ContorValue", ContorValue);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                contor = new Contor();
//                contor.ContorID = int.Parse(r[0].ToString());
//                contor.ContorNum = int.Parse(r[1].ToString());
//                contor.ContorValue = r[2].ToString();
//                contor.Desc = r[3].ToString();
//                contorList.Add(contor);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return contorList;
//        }

//        public List<Contor> LoadContorList()
//        {
//            string SqlStr = "select * from tblContor where (ContorIsDel=0) ";
//            List<Contor> contorList = new List<Contor>();
//            Contor contor;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                contor = new Contor();
//                contor.ContorID = int.Parse(r[0].ToString());
//                contor.ContorNum = int.Parse(r[1].ToString());
//                contor.ContorValue = r[2].ToString();
//                contor.Desc = r[3].ToString();
//                contorList.Add(contor);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return contorList;
//        }

//        public void InsertContor(Contor contor1)
//        {
//            string SqlStr = "Insert into tblContor " +
//                              " (ContorNum,ContorValue,Desc)" +
//                              " VALUES (@ContorNum,@ContorValue,@Desc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Contor contor = new Contor();
//            contor = contor1;
//            cmd.Parameters.AddWithValue("@ContorNum", contor.ContorNum);
//            cmd.Parameters.AddWithValue("@ContorValue", contor.ContorValue);
//            cmd.Parameters.AddWithValue("@Desc", contor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditContor(Contor Contor)
//        {
//            string SqlStr = "UPDATE tblContor " +
//                                 " SET ContorNum = @ContorNum, ContorValue = @ContorValue, Desc=@Desc ";
//            Contor contor = new Contor();
//            contor = Contor;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ContorNum", contor.ContorNum);
//            cmd.Parameters.AddWithValue("@ContorValue", contor.ContorValue);
//            cmd.Parameters.AddWithValue("@Desc", contor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteContor(int ContorID)
//        {
//            string SqlStr = "UPDATE tblContor SET ContorIsDel =1 where ContorID=@ContorID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ContorID", ContorID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion Contor

//        #region Unit_Contor

//        public Unit_Contor LoadUnit_Contor(int UnitID, int ContorID)
//        {
//            string SqlStr = "select * from Unit_Contor where (IsDel=0) AND UnitID=@UnitID,ContorID@ContorID ";
//            Unit_Contor unit_contor = new Unit_Contor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            cmd.Parameters.AddWithValue("@ContorID", ContorID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_contor.UnitID = int.Parse(r[0].ToString());
//                unit_contor.ContorID = int.Parse(r[1].ToString());
//                unit_contor.Desc = r[2].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit_contor;
//        }
//        public List<Unit_Contor> LoadUnit_ContorList()
//        {
//            string SqlStr = "select * from Unit_Contor where (IsDel=0) ";
//            List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
//            Unit_Contor unit_contor = new Unit_Contor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_contor.UnitID = int.Parse(r[0].ToString());
//                unit_contor.ContorID = int.Parse(r[1].ToString());
//                unit_contor.Desc = r[2].ToString();
//                unit_contorList.Add(unit_contor);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit_contorList;
//        }
//        public List<Unit_Contor> LoadUnit_ContorListForGrid()
//        {
//            string SqlStr = "select * from Unit_Contor where (IsDel=0) ";
//            List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
//            Unit_Contor unit_contor = new Unit_Contor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unit_contor.UnitID = int.Parse(r[0].ToString());
//                unit_contor.ContorID = int.Parse(r[1].ToString());
//                unit_contor.Desc = r[2].ToString();
//                unit_contorList.Add(unit_contor);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unit_contorList;
//        }
//        //public List<Unit_Person> LoadUnit_PersonListWithPersonID()
//        //{
//        //    string SqlStr = "select * from Unit_Person,Person where Unit_Person.IsDel=0 and  Person.PersonID=Unit_Person.PersonID";
//        //    List<Unit_Person> unit_personList = new List<Unit_Person>();
//        //    Unit_Person unit_person;
//        //    Person person;
//        //    cn = CnnManager.Instance.GetConnection();
//        //    cmd = new OleDbCommand(SqlStr, cn);
//        //    OleDbDataReader r = cmd.ExecuteReader();
//        //    while (r.Read())
//        //    {
//        //        unit_person = new Unit_Person();
//        //        person = new Person();
//        //        unit_person.UnitID = int.Parse(r[0].ToString());
//        //        //unit_person.PersonID = int.Parse(r[1].ToString());
//        //        unit_person.Relation = r[2].ToString();
//        //        unit_person.Desc = r[3].ToString();
//        //        person.Family =r[5].ToString();
//        //        unit_personList.Add(unit_person);
//        //    }
//        //    r.Close();
//        //    CnnManager.Instance.FreeConnection();
//        //    return unit_personList;
//        //}
//        public List<Contor> LoadContorWithUnitID(int UnitID)
//        {
//            string SqlStr = "select * from Unit_Contor where UnitID=@UnitID AND IsDel=0";
//            Unit_Contor unit_contor = new Unit_Contor();
//            List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
//            Contor contor = new Contor();
//            List<Contor> contorList = new List<Contor>();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", UnitID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unit_contor = new Unit_Contor();
//                unit_contor.UnitID = int.Parse(r[0].ToString());
//                unit_contor.ContorID = int.Parse(r[1].ToString());
//                unit_contor.Desc = r[2].ToString();
//                unit_contorList.Add(unit_contor);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; unit_contorList.Count > i; i++)
//            {
//                contor = new Contor();
//                contor = LoadContor(unit_contorList[i].ContorID);
//                contorList.Add(contor);
//            }

//            return contorList;
//        }

//        public List<Unit> LoadUnitWithContorID(int ContorID)
//        {
//            string SqlStr = "select * from Unit_Contor where ContorID=@ContorID AND IsDel=0";
//            Unit_Contor unitContor = new Unit_Contor();
//            List<Unit_Contor> unitContorList = new List<Unit_Contor>();
//            Unit unit = new Unit();
//            List<Unit> unitList = new List<Unit>();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ContorID", ContorID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unitContor = new Unit_Contor();
//                unitContor.UnitID = int.Parse(r[0].ToString());
//                unitContorList.Add(unitContor);
//            }
//            CnnManager.Instance.FreeConnection();
//            for (int i = 0; unitContorList.Count > i; i++)
//            {
//                unit = new Unit();
//                unit = LoadUnit(unitContorList[i].UnitID);
//                unitList.Add(unit);
//            }

//            return unitList;
//        }
//        public void InsertUnit_Contor(Unit_Contor UnitContor)
//        {
//            string SqlStr = "Insert into Unit_Contor " +
//                              " (UnitID,ContorID,Desc)" +
//                              " VALUES (@UnitID,@ContorID,@Desc)";
//            Unit_Contor unit_Contor = new Unit_Contor();
//            unit_Contor = UnitContor;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);

//            cmd.Parameters.AddWithValue("@ContorID", unit_Contor.ContorID);
//            cmd.Parameters.AddWithValue("@UnitID", unit_Contor.UnitID);
//            cmd.Parameters.AddWithValue("@Desc", unit_Contor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditUnit_Person(Unit_Contor UnitContor)
//        {
//            string SqlStr = "UPDATE Unit_Contor " +
//                                 " SET ContorID = @ContorID, UnitID = @UnitID,Desc=@Desc ";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Unit_Contor unit_Contor = new Unit_Contor();
//            unit_Contor = UnitContor;
//            cmd.Parameters.AddWithValue("@ContorID", unit_Contor.ContorID);
//            cmd.Parameters.AddWithValue("@UnitID", unit_Contor.UnitID);
//            cmd.Parameters.AddWithValue("@Desc", unit_Contor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteUnit_Contor(int UnitID, int ContorID)
//        {
//            string SqlStr = "UPDATE Unit_Contor SET IsDel=1 where UnitID=@UnitID and ContorID=@ContorID";
//            Unit_Contor unit_Contor = new Unit_Contor();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnitID", unit_Contor.UnitID);
//            cmd.Parameters.AddWithValue("@ContorID", unit_Contor.ContorID);
//            cmd.Parameters.AddWithValue("@Desc", unit_Contor.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion Unit_Contor

//        #region IndependentSharj

//        public IndependentSharj LoadIndependentSharj(int IndependentID)
//        {
//            string SqlStr = "select * from tblIndependentSharj where (IsDel=0) and IndependentID=@IndependentID";
//            IndependentSharj independentsharj = new IndependentSharj();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@IndependentID", IndependentID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                independentsharj.ID = int.Parse(r[0].ToString());
//                independentsharj.IndependentID = int.Parse(r[1].ToString());
//                independentsharj.Sharj = int.Parse(r[2].ToString());
//                independentsharj.Desc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independentsharj;
//        }


//        public List<IndependentSharj> LoadIndependentSharjListWithSharj(int Sharj)
//        {
//            string SqlStr = "select * from tblContor where (IsDel=0) and Sharj=@Sharj";
//            List<IndependentSharj> independentsharjList = new List<IndependentSharj>();
//            IndependentSharj independentsharj = new IndependentSharj();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Sharj", Sharj);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                independentsharj = new IndependentSharj();
//                independentsharj.ID = int.Parse(r[0].ToString());
//                independentsharj.IndependentID = int.Parse(r[1].ToString());
//                independentsharj.Sharj = int.Parse(r[2].ToString());
//                independentsharj.Desc = r[3].ToString();
//                independentsharjList.Add(independentsharj);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independentsharjList;
//        }

//        public List<IndependentSharj> LoadIndependentSharjList()
//        {
//            string SqlStr = "select * from tblIndependentSharj where (IsDel=0) ";
//            List<IndependentSharj> independentsharjList = new List<IndependentSharj>();
//            IndependentSharj independentsharj;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                independentsharj = new IndependentSharj();
//                independentsharj.ID = int.Parse(r[0].ToString());
//                independentsharj.IndependentID = int.Parse(r[1].ToString());
//                independentsharj.Sharj = int.Parse(r[2].ToString());
//                independentsharj.Desc = r[3].ToString();
//                independentsharjList.Add(independentsharj);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return independentsharjList;
//        }

//        public void InsertIndependentSharj(IndependentSharj independentsharj1)
//        {
//            string SqlStr = "Insert into tblIndependentSharj " +
//                              " (IndependentID,Sharj,Desc)" +
//                              " VALUES (@IndependentID,@Sharj,@Desc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            IndependentSharj independentsharj = new IndependentSharj();
//            independentsharj = independentsharj1;
//            cmd.Parameters.AddWithValue("@IndependentID", independentsharj.IndependentID);
//            cmd.Parameters.AddWithValue("@Sharj", independentsharj.Sharj);
//            cmd.Parameters.AddWithValue("@Desc", independentsharj.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditIndependentSharj(IndependentSharj IndependentSharj)
//        {
//            string SqlStr = "UPDATE [tblIndependentSharj].[dbo] " +
//                                 " SET IndependentID = @IndependentID, Sharj = @Sharj, Desc=@Desc ";
//            IndependentSharj independentsharj = new IndependentSharj();
//            independentsharj = IndependentSharj;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@IndependentID", independentsharj.IndependentID);
//            cmd.Parameters.AddWithValue("@Sharj", independentsharj.Sharj);
//            cmd.Parameters.AddWithValue("@Desc", independentsharj.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeletendependentSharj(int ID)
//        {
//            string SqlStr = "UPDATE tblIndependentSharj SET IsDel =1 where ID=@ID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ID", ID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion ucIndependentSharj

//        #region Unforeseen

//        public Unforeseen LoadUnforeseen(int UnforeseenID)
//        {
//            string SqlStr = "select * from tblUnforeseen where (IsDel=0) and UnforeseenID=@UnforeseenID";
//            Unforeseen unforeseen = new Unforeseen();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@UnforeseenID", UnforeseenID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                unforeseen.ID = int.Parse(r[0].ToString());
//                unforeseen.Title = r[1].ToString();
//                unforeseen.Sharj = int.Parse(r[2].ToString());
//                unforeseen.Desc = r[3].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unforeseen;
//        }


//        public List<Unforeseen> LoadUnforeseenListWithSharj(int Sharj)
//        {
//            string SqlStr = "select * from tblUnforeseen where (IsDel=0) and Sharj=@Sharj";
//            List<Unforeseen> unforeseenList = new List<Unforeseen>();
//            Unforeseen unforeseen = new Unforeseen();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Sharj", Sharj);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unforeseen = new Unforeseen();
//                unforeseen.ID = int.Parse(r[0].ToString());
//                unforeseen.Title = r[1].ToString();
//                unforeseen.Sharj = int.Parse(r[2].ToString());
//                unforeseen.Desc = r[3].ToString();
//                unforeseenList.Add(unforeseen);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unforeseenList;
//        }

//        public List<Unforeseen> LoadUnforeseenList()
//        {
//            string SqlStr = "select * from tblUnforeseen where (IsDel=0) ";
//            List<Unforeseen> unforeseenList = new List<Unforeseen>();
//            Unforeseen unforeseen;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                unforeseen = new Unforeseen();
//                unforeseen.ID = int.Parse(r[0].ToString());
//                unforeseen.Title = r[1].ToString();
//                unforeseen.Sharj = int.Parse(r[2].ToString());
//                unforeseen.Desc = r[3].ToString();
//                unforeseenList.Add(unforeseen);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return unforeseenList;
//        }

//        public void InsertUnforeseen(Unforeseen Unforeseen)
//        {
//            string SqlStr = "Insert into tblUnforeseen " +
//                              " (Title,Sharj,Desc)" +
//                              " VALUES (@Title,@Sharj,@Desc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Unforeseen unforeseen = new Unforeseen();
//            unforeseen = Unforeseen;
//            cmd.Parameters.AddWithValue("@Title", unforeseen.Title);
//            cmd.Parameters.AddWithValue("@Sharj", unforeseen.Sharj);
//            cmd.Parameters.AddWithValue("@Desc", unforeseen.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditUnforeseen(Unforeseen Unforeseen)
//        {
//            string SqlStr = "UPDATE tblUnforeseen " +
//                                 " SET Title = @Title, Sharj = @Sharj, Desc=@Desc ";
//            Unforeseen unforeseen = new Unforeseen();
//            unforeseen = Unforeseen;
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Title", unforeseen.Title);
//            cmd.Parameters.AddWithValue("@Sharj", unforeseen.Sharj);
//            cmd.Parameters.AddWithValue("@Desc", unforeseen.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteUnforeseen(int ID)
//        {
//            string SqlStr = "UPDATE tblUnforeseen SET IsDel =1 where ID=@ID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@ID", ID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }
//        #endregion Unforeseen

//        #region Fiche

//        public Fiche LoadFiche(int FicheID)
//        {
//            string SqlStr = "select * from tblFiche where FicheIsDel=0 and FicheID=@FicheID";
//            Fiche fiche = new Fiche();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FicheID", FicheID);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                fiche.FicheID = int.Parse(r[0].ToString());
//                fiche.TypeContor = r[1].ToString();
//                fiche.Title = r[2].ToString();
//                fiche.Cost = int.Parse(r[3].ToString());
//                fiche.FromDate = r[4].ToString();
//                fiche.UntillDate = r[5].ToString();
//                fiche.Desc = r[6].ToString();

//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return fiche;
//        }

//        public Fiche LoadFicheWithTitle(string Title)
//        {
//            string SqlStr = "select * from tblFiche where FicheIsDel=0 and Title=@Title";
//            Fiche fiche = new Fiche();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@Title", Title);
//            OleDbDataReader r = cmd.ExecuteReader();
//            if (r.Read())
//            {
//                fiche.FicheID = int.Parse(r[0].ToString());
//                fiche.TypeContor = r[1].ToString();
//                fiche.Title = r[2].ToString();
//                fiche.Cost = int.Parse(r[3].ToString());
//                fiche.FromDate = r[4].ToString();
//                fiche.UntillDate = r[5].ToString();
//                fiche.Desc = r[6].ToString();
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return fiche;
//        }

//        public List<Fiche> LoadFicheList()
//        {
//            string SqlStr = "select * from tblFiche where (FicheIsDel=0)";
//            List<Fiche> ficheList = new List<Fiche>();
//            Fiche fiche = new Fiche();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                fiche = new Fiche();
//                fiche.FicheID = int.Parse(r[0].ToString());
//                fiche.TypeContor = r[1].ToString();
//                fiche.Title = r[2].ToString();
//                fiche.Cost = int.Parse(r[3].ToString());
//                fiche.FromDate = r[4].ToString();
//                fiche.UntillDate = r[5].ToString();
//                fiche.Desc = r[6].ToString();
//                ficheList.Add(fiche);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return ficheList;
//        }

//        public List<Fiche> LoadFicheListWithDate(string FromDate, string UntillDate)
//        {
//            string SqlStr = "select * from tblFiche where (FicheIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate";
//            List<Fiche> ficheList = new List<Fiche>();
//            Fiche fiche = new Fiche();
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FromDate", FromDate);
//            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
//            OleDbDataReader r = cmd.ExecuteReader();
//            while (r.Read())
//            {
//                fiche = new Fiche();
//                fiche.FicheID = int.Parse(r[0].ToString());
//                fiche.TypeContor = r[1].ToString();
//                fiche.Title = r[2].ToString();
//                fiche.Cost = int.Parse(r[3].ToString());
//                fiche.FromDate = r[4].ToString();
//                fiche.UntillDate = r[5].ToString();
//                fiche.Desc = r[6].ToString();
//                ficheList.Add(fiche);
//            }
//            r.Close();
//            CnnManager.Instance.FreeConnection();
//            return ficheList;
//        }


//        public void InsertFiche(Fiche Fiche)
//        {
//            string SqlStr = "Insert into tblFiche " +
//                              " (TypeContor,Title,Cost,FromDatee,UntillDate,Desc)" +
//                              " VALUES (TypeContor,@Title,@Cost,@FromDate,@UntillDate,@Desc)";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Fiche fiche = new Fiche();
//            fiche = Fiche;
//            cmd.Parameters.AddWithValue("@TypeContor", fiche.TypeContor);
//            cmd.Parameters.AddWithValue("@Title", fiche.Title);
//            cmd.Parameters.AddWithValue("@Cost", fiche.Cost);
//            cmd.Parameters.AddWithValue("@FromDate", fiche.FromDate);
//            cmd.Parameters.AddWithValue("@UntillDate", fiche.UntillDate);
//            cmd.Parameters.AddWithValue("@Desc", fiche.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void EditFiche(Fiche Fiche)
//        {
//            string SqlStr = "UPDATE tblFiche " +
//                                 " SET TypeContor=@TypeContor,Title = @Title, Cost = @Cost, FromDate=@FromDate ,Desc=@Desc";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            Fiche fiche = new Fiche();
//            fiche = Fiche;
//            cmd.Parameters.AddWithValue("@TypeContor", fiche.TypeContor);
//            cmd.Parameters.AddWithValue("@Title", fiche.Title);
//            cmd.Parameters.AddWithValue("@Cost", fiche.Cost);
//            cmd.Parameters.AddWithValue("@FromDate", fiche.FromDate);
//            cmd.Parameters.AddWithValue("@UntillDate", fiche.UntillDate);
//            cmd.Parameters.AddWithValue("@Desc", fiche.Desc);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        public void DeleteFiche(long FicheID)
//        {
//            string SqlStr = "UPDATE tblFiche SET FicheIsDel =1 where FicheID=@FicheID";
//            cn = CnnManager.Instance.GetConnection();
//            cmd = new OleDbCommand(SqlStr, cn);
//            cmd.Parameters.AddWithValue("@FicheID", FicheID);
//            cmd.ExecuteNonQuery();
//            CnnManager.Instance.FreeConnection();
//        }

//        #endregion Fiche

//    }
//}

using System;
using System.Collections.Generic;
using System.Text;
using Alma.Common;
using System.Data.OleDb;
using System.Data;
using System.Configuration;


namespace Alma.DAL
{
    public class DAL
    {
        OleDbConnection cn = new OleDbConnection(ConfigurationManager.AppSettings["CnString"]);
        OleDbCommand cmd;
        #region Unit

        public Unit LoadUnit(int UnitID)
        {
            string SqlStr = "select * from tblUnits where UnitID=@UnitID and UnitIsDel=0";
            Unit unit = new Unit();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unit.ID = int.Parse(r[0].ToString());
                unit.UnitCode = int.Parse(r[1].ToString());
                unit.UnitNumber = r[2].ToString();
                unit.UnitArea = int.Parse(r[3].ToString());
                unit.UnitFloor = int.Parse(r[4].ToString());
                unit.UnitPersonsNum = int.Parse(r[5].ToString());
                unit.Type = r[6].ToString();
                unit.UnitRooms = int.Parse(r[7].ToString());
                unit.Desc = r[8].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit;
        }

        public List<Unit> LoadUnitListWithUnitCode(int UnitCode)
        {
            string SqlStr = "select * from tblUnits where (UnitIsDel=0) and UnitCode=@UnitCode";
            List<Unit> unitList = new List<Unit>();
            Unit unit;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitCode", UnitCode);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit = new Unit();
                unit.ID = int.Parse(r[0].ToString());
                unit.UnitCode = int.Parse(r[1].ToString());
                unit.UnitNumber = r[2].ToString();
                unit.UnitArea = int.Parse(r[3].ToString());
                unit.UnitFloor = int.Parse(r[4].ToString());
                unit.UnitPersonsNum = int.Parse(r[5].ToString());
                unit.Type = r[6].ToString();
                unit.UnitRooms = int.Parse(r[7].ToString());
                unit.Desc = r[8].ToString();
                unitList.Add(unit);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unitList;
        }

        public Unit LoadUnitWithUnitCodeandUnitFloor(int UnitCode, int UnitFloor)
        {
            string SqlStr = "select * from tblUnits where (UnitIsDel=0) and UnitCode=@UnitCode and UnitFloor=@UnitFloor";
            List<Unit> unitList = new List<Unit>();
            Unit unit = new Unit();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitCode", UnitCode);
            cmd.Parameters.AddWithValue("@UnitFloor", UnitFloor);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit.ID = int.Parse(r[0].ToString());
                unit.UnitCode = int.Parse(r[1].ToString());
                unit.UnitNumber = r[2].ToString();
                unit.UnitArea = int.Parse(r[3].ToString());
                unit.UnitFloor = int.Parse(r[4].ToString());
                unit.UnitPersonsNum = int.Parse(r[5].ToString());
                unit.Type = r[6].ToString();
                unit.UnitRooms = int.Parse(r[7].ToString());
                unit.Desc = r[8].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit;
        }
        public List<Unit> LoadUnitList()
        {
            string SqlStr = "select * from tblUnits where (UnitIsDel=0) ";
            List<Unit> unitList = new List<Unit>();
            Unit unit;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit = new Unit();
                unit.ID = int.Parse(r[0].ToString());
                unit.UnitCode = int.Parse(r[1].ToString());
                unit.UnitNumber = r[2].ToString();
                unit.UnitArea = int.Parse(r[3].ToString());
                unit.UnitFloor = int.Parse(r[4].ToString());
                unit.UnitPersonsNum = int.Parse(r[5].ToString());
                unit.Type = r[6].ToString();
                unit.UnitRooms = int.Parse(r[7].ToString());
                unit.Desc = r[8].ToString();

                unitList.Add(unit);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unitList;
        }

        public Boolean InsertUnit(Unit unit1)
        {
            try
            {
                string SqlStr = "Insert into tblUnits " +
                                   " (UnitCode,UnitNumber,UnitArea,UnitFloor,UnitPersonsNum,UnitType,UnitRooms,UnitDesc)" +
                                   " VALUES (@UnitCode,@UnitNumber,@UnitArea,@UnitFloor,@UnitPersonsNum,@UnitType,@UnitRooms,@UnitDesc)";
                Unit unit = new Unit();
                unit = unit1;
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                cmd.Parameters.AddWithValue("@UnitCode", unit.UnitCode);
                cmd.Parameters.AddWithValue("@UnitNumber", unit.UnitNumber);
                cmd.Parameters.AddWithValue("@UnitArea", unit.UnitArea);
                cmd.Parameters.AddWithValue("@UnitFloor", unit.UnitFloor);
                cmd.Parameters.AddWithValue("@UnitPersonsNum", unit.UnitPersonsNum);
                cmd.Parameters.AddWithValue("@UnitType", unit.Type);
                cmd.Parameters.AddWithValue("@UnitRooms", unit.UnitRooms);
                cmd.Parameters.AddWithValue("@UnitDesc", unit.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EditUnit(Unit unit1)
        {
            string SqlStr = "UPDATE tblUnits " +
                                  " SET UnitCode = @UnitCode,UnitNumber=@UnitNumber,UnitArea = @UnitArea, UnitFloor=@UnitFloor ,UnitPersonsNum=@UnitPersonsNum,UnitType=@UnitType,UnitRooms=@UnitRooms,UnitDesc=@UnitDesc";
            Unit unit = new Unit();
            unit = unit1;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitCode", unit.UnitCode);
            cmd.Parameters.AddWithValue("@UnitNumber", unit.UnitNumber);
            cmd.Parameters.AddWithValue("@UnitArea", unit.UnitArea);
            cmd.Parameters.AddWithValue("@UnitFloor", unit.UnitFloor);
            cmd.Parameters.AddWithValue("@UnitPersonsNum", unit.UnitPersonsNum);
            cmd.Parameters.AddWithValue("@UnitType", unit.Type);
            cmd.Parameters.AddWithValue("@UnitRooms", unit.UnitRooms);
            cmd.Parameters.AddWithValue("@UnitDesc", unit.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteUnit(int UnitID)
        {
            string SqlStr = "UPDATE tblUnits SET UnitIsDel=1 where UnitID=@UnitID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.Add("@UnitID", OleDbType.Integer).Value = UnitID;
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }


        #endregion Unit

        #region Independent

        public Independent LoadIndependent(int IndependentID)
        {
            string SqlStr = "select * from I where IndependentID=@IndependentID and (IsDel=0)";
            Independent independent = new Independent();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IndependentID", IndependentID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                independent.ID = int.Parse(r[0].ToString());
                independent.Type = r[1].ToString();
                independent.Title = r[2].ToString();
                independent.Count = int.Parse(r[3].ToString());
                independent.Area = int.Parse(r[4].ToString());
                independent.FloorNum = int.Parse(r[5].ToString());
                independent.Desc = r[6].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independent;
        }

        public List<Independent> LoadIndependentListWithDetailType(string DetailType)
        {
            string SqlStr = "select * from I where (IsDel=0) and DetailType=@DetailType";
            List<Independent> independentList = new List<Independent>();
            Independent independent;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailType", DetailType);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                independent = new Independent();
                independent.ID = int.Parse(r[0].ToString());
                independent.Type = r[1].ToString();
                independent.Title = r[2].ToString();
                independent.Count = int.Parse(r[3].ToString());
                independent.Area = int.Parse(r[4].ToString());
                independent.FloorNum = int.Parse(r[5].ToString());
                independent.Desc = r[6].ToString();
                independentList.Add(independent);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independentList;
        }

        public Independent LoadIndependentWithTitle(string Title)
        {
            string SqlStr = "select * from I where (IsDel=0) and Title=@Title";
            Independent independent = new Independent();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Title", Title);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                independent.ID = int.Parse(r[0].ToString());
                independent.Type = r[1].ToString();
                independent.Title = r[2].ToString();
                independent.Count = int.Parse(r[3].ToString());
                independent.Area = int.Parse(r[4].ToString());
                independent.FloorNum = int.Parse(r[5].ToString());
                independent.Desc = r[6].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independent;
        }
        public List<Independent> LoadIndependentList()
        {
            string SqlStr = "select * from I where (IsDel=0) ";
            List<Independent> independentList = new List<Independent>();
            Independent independent;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                independent = new Independent();
                independent.ID = int.Parse(r[0].ToString());
                independent.Type = r[1].ToString();
                independent.Title = r[2].ToString();
                independent.Count = int.Parse(r[3].ToString());
                independent.Area = int.Parse(r[4].ToString());
                independent.FloorNum = int.Parse(r[5].ToString());
                independent.Desc = r[6].ToString();
                independentList.Add(independent);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independentList;
        }

        public Boolean InsertIndependent(Independent independent1)
        {
            try
            {
                string SqlStr = "insert into I" +
                                   "(DetailType,Title,Count,Area,FloorNum,Desc)" +
                                   " VALUES (@DetailType,@Title,@Count,@Area,@FloorNum,@Desc)";
                Independent independent = new Independent();
                independent = independent1;
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                cmd.Parameters.AddWithValue("@DetailType", independent.Type);
                cmd.Parameters.AddWithValue("@Title", independent.Title);
                cmd.Parameters.AddWithValue("@Count", independent.Count);
                cmd.Parameters.AddWithValue("@Area", independent.Area);
                cmd.Parameters.AddWithValue("@FloorNum", independent.FloorNum);
                cmd.Parameters.AddWithValue("@Desc", independent.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditIndependent(Independent independent1)
        {
            string SqlStr = "UPDATE [I].[dbo] " +
                                  "SET DetailType = @DetailType, Title = @Title, Count=@Count ,Area=@Area,FloorNum=@FloorNum,Desc=@Desc";
            Independent independent = new Independent();
            independent = independent1;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailType", independent.Type);
            cmd.Parameters.AddWithValue("@Title", independent.Title);
            cmd.Parameters.AddWithValue("@Count", independent.Count);
            cmd.Parameters.AddWithValue("@Area", independent.Area);
            cmd.Parameters.AddWithValue("@FloorNum", independent.FloorNum);
            cmd.Parameters.AddWithValue("@Desc", independent.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteIndependent(int IndependentID)
        {
            string SqlStr = "UPDATE I SET IsDel=1 where IndependentID=@IndependentID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.Add("@IndependentID", OleDbType.Integer).Value = IndependentID;
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion Independent

        #region Tower

        public Tower LoadTower(int TowerID)
        {
            string SqlStr = "select * from tblTower where (TowerIsDel=0) and TowerID=@TowerID";
            Tower tower = new Tower();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerID", TowerID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                tower.ID = int.Parse(r[0].ToString());
                tower.TowerTitle = r[1].ToString();
                tower.FloorCount = int.Parse(r[2].ToString());
                tower.UnitNum = int.Parse(r[3].ToString());
                tower.ParkingCount = int.Parse(r[4].ToString());
                tower.Area = int.Parse(r[5].ToString());
                tower.TowerNum = r[6].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return tower;
        }


        public List<Tower> LoadTowerListWithTowerTitle(string TowerTitle)
        {
            string SqlStr = "select * from tblTower where (TowerIsDel=0) and TowerTitle=@TowerTitle";
            List<Tower> towerList = new List<Tower>();
            Tower tower = new Tower();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerTitle", TowerTitle);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                tower = new Tower();
                tower.ID = int.Parse(r[0].ToString());
                tower.TowerTitle = r[1].ToString();
                tower.FloorCount = int.Parse(r[2].ToString());
                tower.UnitNum = int.Parse(r[3].ToString());
                tower.ParkingCount = int.Parse(r[4].ToString());
                tower.Area = int.Parse(r[5].ToString());
                tower.TowerNum = r[6].ToString();
                towerList.Add(tower);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return towerList;
        }

        public List<Tower> LoadTowerList()
        {
            string SqlStr = "select * from tblTower where (TowerIsDel=0) ";
            List<Tower> towerList = new List<Tower>();
            Tower tower;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                tower = new Tower();
                tower.ID = int.Parse(r[0].ToString());
                tower.TowerTitle = r[1].ToString();
                tower.FloorCount = int.Parse(r[2].ToString());
                tower.UnitNum = int.Parse(r[3].ToString());
                tower.ParkingCount = int.Parse(r[4].ToString());
                tower.Area = int.Parse(r[5].ToString());
                tower.TowerNum = r[6].ToString();
                towerList.Add(tower);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return towerList;
        }

        public bool InsertTower(Tower tower1)
        {
            try
            {
                string SqlStr = "Insert into tblTower " +
                                  " (TowerTitle,FloorCount,UnitCount,ParkingCount,Area,TNumber)" +
                                  " VALUES (@TowerTitle,@FloorCount,@UnitCount,@ParkingCount,@Area,@TNumber)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Tower tower = new Tower();
                tower = tower1;
                cmd.Parameters.AddWithValue("@TowerTitle", tower.TowerTitle);
                cmd.Parameters.AddWithValue("@FloorCount", tower.FloorCount);
                cmd.Parameters.AddWithValue("@UnitCount", tower.UnitNum);
                cmd.Parameters.AddWithValue("@ParkingCount", tower.ParkingCount);
                cmd.Parameters.AddWithValue("@Area", tower.Area);
                cmd.Parameters.AddWithValue("@TNumber", tower.TowerNum);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EditTower(Tower Tower)
        {
            string SqlStr = "UPDATE tblTower " +
                                 " SET TowerTitle = @TowerTitle, FloorCount = @FloorCount, UnitCount=@UnitCount ,ParkingCount=@ParkingCount,Area=@Area,TNumber=@TNumber";
            Tower tower = new Tower();
            tower = Tower;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerTitle", tower.TowerTitle);
            cmd.Parameters.AddWithValue("@FloorCount", tower.FloorCount);
            cmd.Parameters.AddWithValue("@UnitCount", tower.UnitNum);
            cmd.Parameters.AddWithValue("@ParkingCount", tower.ParkingCount);
            cmd.Parameters.AddWithValue("@Area", tower.Area);
            cmd.Parameters.AddWithValue("@TNumber", tower.TowerNum);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteTower(int TowerID)
        {
            string SqlStr = "UPDATE tblTower SET TowerIsDel =1 where TowerID=@TowerID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerID", TowerID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }


        #endregion Tower

        #region Person

        public Person LoadPerson(int PersonID)
        {
            string SqlStr = "select * from tblPersons where PersonIsDel=0 and PersonID=@PersonID";
            Person person = new Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                person.PersonID = int.Parse(r[0].ToString());
                person.Name = r[1].ToString();
                person.Family = r[2].ToString();
                person.FatherName = r[3].ToString();
                person.RegisterCardNum = r[4].ToString();
                person.NationalCode = r[5].ToString();
                person.Sex = bool.Parse(r[6].ToString());
                person.PicturePath = r[7].ToString();
                person.Telephon = r[8].ToString();
                person.Mobile = r[9].ToString();
                person.DateEnter = r[10].ToString();
                person.DateExit = r[11].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return person;
        }

        public Person LoadPersonWithFamily(string Family)
        {
            string SqlStr = "select * from tblPersons where PersonIsDel=0 and Family=@Family";
            Person person = new Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Family", Family);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                person.PersonID = int.Parse(r[0].ToString());
                person.Name = r[1].ToString();
                person.Family = r[2].ToString();
                person.FatherName = r[3].ToString();
                person.RegisterCardNum = r[4].ToString();
                person.NationalCode = r[5].ToString();
                person.Sex = bool.Parse(r[6].ToString());
                person.PicturePath = r[7].ToString();
                person.Telephon = r[8].ToString();
                person.Mobile = r[9].ToString();
                person.DateEnter = r[10].ToString();
                person.DateExit = r[11].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return person;
        }

        public List<Person> LoadPersonList()
        {
            string SqlStr = "select * from tblPersons where (PersonIsDel=0)";
            List<Person> personList = new List<Person>();
            Person person = new Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                person = new Person();
                person.PersonID = int.Parse(r[0].ToString());
                person.Name = r[1].ToString();
                person.Family = r[2].ToString();
                person.FatherName = r[3].ToString();
                person.RegisterCardNum = r[4].ToString();
                person.NationalCode = r[5].ToString();
                person.Sex = bool.Parse(r[6].ToString());
                person.PicturePath = r[7].ToString();
                person.Telephon = r[8].ToString();
                person.Mobile = r[9].ToString();
                person.DateEnter = r[10].ToString();
                person.DateExit = r[11].ToString();
                personList.Add(person);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return personList;
        }

        public List<Person> LoadPersonListWithName(string Name, string Family)
        {
            string SqlStr = "select * from tblPerson where (PersonIsDel=0) and Name=@Name and Family=@Family";
            List<Person> personList = new List<Person>();
            Person person = new Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Family", Family);
            cmd.Parameters.AddWithValue("@Name", Name);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                person = new Person();
                person.PersonID = int.Parse(r[0].ToString());
                person.Name = r[1].ToString();
                person.Family = r[2].ToString();
                person.FatherName = r[3].ToString();
                person.RegisterCardNum = r[4].ToString();
                person.NationalCode = r[5].ToString();
                person.Sex = bool.Parse(r[6].ToString());
                person.PicturePath = r[7].ToString();
                person.Telephon = r[8].ToString();
                person.Mobile = r[9].ToString();
                person.DateEnter = r[10].ToString();
                person.DateExit = r[11].ToString();
                personList.Add(person);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return personList;
        }


        public bool InsertPerson(Person Person)
        {
            try
            {
                string SqlStr = "Insert into tblPersons " +
                                  " (Name,Family,FatherName,RegisterCardNum,NationalCode,Sex,PicturePath,Telephon,Mobile,DateEnter,DateExit)" +
                                  " VALUES (@Name,@Family,@FatherName,@RegisterCardNum,@NationalCode,@Sex,@PicturePath,@Telephon,@Mobile,@DateEnter,@DateExit)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Person person = new Person();
                person = Person;
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Family", person.Family);
                cmd.Parameters.AddWithValue("@FatherName", person.FatherName);
                cmd.Parameters.AddWithValue("@RegisterCardNum", person.RegisterCardNum);
                cmd.Parameters.AddWithValue("@NationalCode", person.NationalCode);
                cmd.Parameters.AddWithValue("@Sex", person.Sex);
                cmd.Parameters.AddWithValue("@PicturePath", person.PicturePath);
                cmd.Parameters.AddWithValue("@Telephon", person.Telephon);
                cmd.Parameters.AddWithValue("@Mobile", person.Mobile);
                cmd.Parameters.AddWithValue("@DateEnter", person.DateEnter);
                cmd.Parameters.AddWithValue("@DateExit", person.DateExit);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditPerson(Person Person)
        {
            string SqlStr = "UPDATE tblPersons " +
                                 " SET Name = @Name, Family = @Family, FatherName=@FatherName ,RegisterCardNum=@RegisterCardNum,NationalCode=@NationalCode,Sex=@Sex,PicturePath=@PicturePath,Telephon=@Telephon,Mobile=@Mobile,DateEnter=@DateEnter,DateExit=@DateExit";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            Person person = new Person();
            person = Person;
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Family", person.Family);
            cmd.Parameters.AddWithValue("@FatherName", person.FatherName);
            cmd.Parameters.AddWithValue("@RegisterCardNum", person.RegisterCardNum);
            cmd.Parameters.AddWithValue("@NationalCode", person.NationalCode);
            cmd.Parameters.AddWithValue("@Sex", person.Sex);
            cmd.Parameters.AddWithValue("@PicturePath", person.PicturePath);
            cmd.Parameters.AddWithValue("@Telephon", person.Telephon);
            cmd.Parameters.AddWithValue("@Mobile", person.Mobile);
            cmd.Parameters.AddWithValue("@DateEnter", person.DateEnter);
            cmd.Parameters.AddWithValue("@DateExit", person.DateExit);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeletePerson(long PersonID)
        {
            string SqlStr = "UPDATE tblPersons SET PersonIsDel =1 where PersonID=@PersonID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion Person

        #region Floor

        public Floor LoadFloor(int FloorID)
        {
            string SqlStr = "select * from tblFloor where FloorID=@FloorID ";
            Floor floor = new Floor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FloorID", FloorID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                floor.ID = int.Parse(r[0].ToString());
                floor.FloorNum = int.Parse(r[1].ToString());
                floor.FloorTitle = r[2].ToString();
                floor.UnitCount = int.Parse(r[3].ToString());
                floor.Area = r[4].ToString();
                floor.Half = bool.Parse(r[5].ToString());
                floor.Desc = r[6].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return floor;
        }

        public List<Floor> LoadFloorListWithFloorNum(int FloorNum)
        {
            string SqlStr = "select * from tblFloor where FloorNum=@FloorNum";
            List<Floor> floorList = new List<Floor>();
            Floor floor;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FloorNum", FloorNum);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                floor = new Floor();
                floor.ID = int.Parse(r[0].ToString());
                floor.FloorNum = int.Parse(r[1].ToString());
                floor.FloorTitle = r[2].ToString();
                floor.UnitCount = int.Parse(r[3].ToString());
                floor.Area = r[4].ToString();
                floor.Half = bool.Parse(r[5].ToString());
                floor.Desc = r[6].ToString();
                floorList.Add(floor);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return floorList;
        }
        public List<Floor> LoadFloorList()
        {
            string SqlStr = "select * from tblFloor ";
            List<Floor> floorList = new List<Floor>();
            Floor floor;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                floor = new Floor();
                floor.ID = int.Parse(r[0].ToString());
                floor.FloorNum = int.Parse(r[1].ToString());
                floor.FloorTitle = r[2].ToString();
                floor.UnitCount = int.Parse(r[3].ToString());
                floor.Area = r[4].ToString();
                floor.Half = bool.Parse(r[5].ToString());
                floor.Desc = r[6].ToString();
                floorList.Add(floor);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return floorList;
        }

        public bool InsertFloor(Floor floor1)
        {
            try
            {
                string SqlStr = "Insert into tblFloor " +
                                  " (FloorNum,FloorTitle,UnitCount,FloorArea,HalfFloor,FloorDesc)" +
                                  " VALUES (@FloorNum,@FloorTitle,@UnitCount,@FloorArea,@HalfFloor,@FloorDesc)";
                Floor floor = new Floor();
                floor = floor1;
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                cmd.Parameters.AddWithValue("@FloorNum", floor.FloorNum);
                cmd.Parameters.AddWithValue("@FloorTitle", floor.FloorTitle);
                cmd.Parameters.AddWithValue("@UnitCount", floor.UnitCount);
                cmd.Parameters.AddWithValue("@FloorArea", floor.Area);
                cmd.Parameters.AddWithValue("@HalfFloor", floor.Half);
                cmd.Parameters.AddWithValue("@FloorDesc", floor.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }

        }

        public void EditFloor(Floor floor1)
        {
            string SqlStr = "UPDATE tblFloor " +
                                  " SET FloorNum = @FloorNum,FloorTitle=@FloorTitle,UnitCount=@UnitCount, FloorArea = @FloorArea, HalfFloor=@HalfFloor,FloorDesc=@FloorDesc";
            Floor floor = new Floor();
            floor = floor1;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FloorNum", floor.FloorNum);
            cmd.Parameters.AddWithValue("@FloorTitle", floor.FloorTitle);
            cmd.Parameters.AddWithValue("@UnitCount", floor.UnitCount);
            cmd.Parameters.AddWithValue("@FloorArea", floor.Area);
            cmd.Parameters.AddWithValue("@HalfFloor", floor.Half);
            cmd.Parameters.AddWithValue("@FloorDesc", floor.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteFloor(int FloorID)
        {
            string SqlStr = "Delete From tblFloor where FloorID=@FloorID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.Add("@FloorID", OleDbType.Integer).Value = FloorID;
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }


        #endregion Floor

        #region Car

        public Car LoadCar(int CarID)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and CarID=@CarID";
            Car car = new Car();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                car.ID = int.Parse(r[0].ToString());
                car.Code = r[1].ToString();
                car.Color = r[2].ToString();
                car.Model = r[3].ToString();
                car.Owner = int.Parse(r[4].ToString());
                car.Desc = r[5].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return car;
        }

        public List<Car> LoadCarListWithCarModel(int CarModel)
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0) and CarModel=@CarModel";
            List<Car> carList = new List<Car>();
            Car car = new Car();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@CarModel", CarModel);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                car = new Car();
                car.ID = int.Parse(r[0].ToString());
                car.Code = r[1].ToString();
                car.Color = r[2].ToString();
                car.Model = r[3].ToString();
                car.Owner = int.Parse(r[4].ToString());
                car.Desc = r[5].ToString();
                carList.Add(car);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return carList;
        }

        public List<Car> LoadCarList()
        {
            string SqlStr = "select * from tblCar where (CarIsDel=0)";
            List<Car> carList = new List<Car>();
            Car car = new Car();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Connection = cn;
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                car = new Car();
                car.ID = int.Parse(r[0].ToString());
                car.Code = r[1].ToString();
                car.Color = r[2].ToString();
                car.Model = r[3].ToString();
                car.Owner = int.Parse(r[4].ToString());
                car.Desc = r[5].ToString();
                carList.Add(car);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return carList;
        }


        public bool InsertCar(Car Car)
        {
            try
            {
                string SqlStr = "Insert into tblCar " +
                                  " (CarCode,CarColor,CarModel,CarOwner,CarDesc)" +
                                  " VALUES (@CarCode,@CarColor,@CarModel,@CarOwner,@CarDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Car car = new Car();
                car = Car;
                cmd.Parameters.AddWithValue("@CarCode", car.Code);
                cmd.Parameters.AddWithValue("@CarColor", car.Color);
                cmd.Parameters.AddWithValue("@CarModel", car.Model);
                cmd.Parameters.AddWithValue("@CarOwner", car.Owner);
                cmd.Parameters.AddWithValue("@CarDesc", car.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }
        public void EditCar(Car Car)
        {
            string SqlStr = "UPDATE tblCar " +
                                 " SET CarCode = @CarCode, CarColor = @CarColor, CarModel=@CarModel,CarOwner=@CarOwner,CarDesc=@CarDesc";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            Car car = new Car();
            car = Car;
            cmd.Parameters.AddWithValue("@CarCode", car.Code);
            cmd.Parameters.AddWithValue("@CarColor", car.Color);
            cmd.Parameters.AddWithValue("@CarModel", car.Model);
            cmd.Parameters.AddWithValue("@CarOwner", car.Owner);
            cmd.Parameters.AddWithValue("@CarDesc", car.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteCar(int CarID)
        {
            string SqlStr = "UPDATE tblCar SET CarIsDel=1 where CarID=@CarID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion Car

        #region Unit_Person

        public Unit_Person LoadUnit_Person(int UnitID, int PersonID)
        {
            string SqlStr = "select P.Name,P.Family,P.NationalCode,UC.UnitCode,UC.UnitNumber," +
                            "FROM tblUnits AS U INNER JOIN tblPerson AS P INNER JOIN Unit_Person AS UC ON UP.UnitID=P.UnitID and UP.PersonID=P.PersonID" +
                            "WHERE UnitID=@UnitID and PersonID=@PersonID";
            Unit_Person unit_person = new Unit_Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd.Parameters.AddWithValue("@PersonID", UnitID);
            OleDbDataReader r = cmd.ExecuteReader();

            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_person;
        }
        public Unit_Person LoadUnit_Person(int UnitID)
        {
            string SqlStr = "select * from Unit_Person where (IsDel=0) AND UnitID=@UnitID ";
            Unit_Person unit_person = new Unit_Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_person.UnitID = int.Parse(r[0].ToString());
                unit_person.PersonID = int.Parse(r[1].ToString());
                unit_person.Relation = r[2].ToString();
                unit_person.Desc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_person;
        }
        public List<Unit_Person> LoadUnit_PersonList()
        {
            string SqlStr = "select * from Unit_Person where (IsDel=0) ";
            List<Unit_Person> unit_personList = new List<Unit_Person>();
            Unit_Person unit_person;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_person = new Unit_Person();
                unit_person.UnitID = int.Parse(r[0].ToString());
                unit_person.PersonID = int.Parse(r[1].ToString());
                unit_person.Relation = r[2].ToString();
                unit_person.Desc = r[3].ToString();
                unit_personList.Add(unit_person);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_personList;
        }

        //public List<Unit_Person> LoadUnit_PersonListWithPersonID()
        //{
        //    string SqlStr = "select * from Unit_Person,Person where Unit_Person.IsDel=0 and  Person.PersonID=Unit_Person.PersonID";
        //    List<Unit_Person> unit_personList = new List<Unit_Person>();
        //    Unit_Person unit_person;
        //    Person person;
        //    cn = CnnManager.Instance.GetConnection();
        //    cmd = new OleDbCommand(SqlStr, cn);
        //    OleDbDataReader r = cmd.ExecuteReader();
        //    while (r.Read())
        //    {
        //        unit_person = new Unit_Person();
        //        person = new Person();
        //        unit_person.UnitID = int.Parse(r[0].ToString());
        //        //unit_person.PersonID = int.Parse(r[1].ToString());
        //        unit_person.Relation = r[2].ToString();
        //        unit_person.Desc = r[3].ToString();
        //        person.Family =r[5].ToString();
        //        unit_personList.Add(unit_person);
        //    }
        //    r.Close();
        //    CnnManager.Instance.FreeConnection();
        //    return unit_personList;
        //}
        public List<Unit_Person> LoadUnit_PersonListForGrid()
        {
            string SqlStr = "select * from Unit_Person where (IsDel=0) ";
            List<Unit_Person> unit_personList = new List<Unit_Person>();
            Unit_Person unit_person;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_person = new Unit_Person();
                unit_person.UnitID = int.Parse(r[0].ToString());
                unit_person.PersonID = int.Parse(r[1].ToString());
                unit_person.Relation = r[2].ToString();
                unit_person.Desc = r[3].ToString();
                unit_personList.Add(unit_person);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_personList;
        }
        public List<Person> LoadPersonWithUnitID(int UnitID)
        {
            string SqlStr = "select * from Unit_Person where UnitID=@UnitID AND IsDel=0";
            Unit_Person unit_person = new Unit_Person();
            List<Unit_Person> unit_personList = new List<Unit_Person>();
            Person person = new Person();
            List<Person> PersonList = new List<Person>();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unit_person = new Unit_Person();
                unit_person.UnitID = int.Parse(r[0].ToString());
                unit_person.PersonID = int.Parse(r[1].ToString());
                unit_person.Relation = r[2].ToString();
                unit_person.Desc = r[3].ToString();
                unit_personList.Add(unit_person);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; unit_personList.Count > i; i++)
            {
                person = new Person();
                person = LoadPerson(unit_personList[i].PersonID);
                PersonList.Add(person);
            }

            return PersonList;
        }

        public List<Unit> LoadUnitWithPersonID(int PersonID)
        {
            string SqlStr = "select * from Unit_Person where PersonID=@PersonID AND IsDel=0";
            Unit_Person unit_person = new Unit_Person();
            List<Unit_Person> unit_personList = new List<Unit_Person>();
            Unit unit = new Unit();
            List<Unit> unitList = new List<Unit>();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unit_person = new Unit_Person();
                unit_person.UnitID = int.Parse(r[0].ToString());
                unit_personList.Add(unit_person);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; unit_personList.Count > i; i++)
            {
                unit = new Unit();
                unit = LoadUnit(unit_personList[i].UnitID);
                unitList.Add(unit);
            }

            return unitList;
        }
        public bool InsertUnit_Person(Unit_Person UnitPerson)
        {
            try
            {
                string SqlStr = "Insert into Unit_Person " +
                                  " (UnitID,PersonID,Relation,Desc)" +
                                  " VALUES (@UnitID,@PersonID,@Relation,@Desc)";
                Unit_Person unit_person = new Unit_Person();
                unit_person = UnitPerson;
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);

                cmd.Parameters.AddWithValue("@UnitID", unit_person.UnitID);
                cmd.Parameters.AddWithValue("@PersonID", unit_person.PersonID);
                cmd.Parameters.AddWithValue("@Relation", unit_person.Relation);
                cmd.Parameters.AddWithValue("@Desc", unit_person.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditUnit_Person(Unit_Person UnitPerson)
        {
            string SqlStr = "UPDATE Unit_Person " +
                                 " SET PersonID = @PersonID, UnitID = @UnitID,Relation=@Relation,Desc=@Desc ";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            Unit_Person unit_person = new Unit_Person();
            unit_person = UnitPerson;
            cmd.Parameters.AddWithValue("@PersonID", unit_person.PersonID);
            cmd.Parameters.AddWithValue("@UnitID", unit_person.UnitID);
            cmd.Parameters.AddWithValue("@Relation", unit_person.Relation);
            cmd.Parameters.AddWithValue("@Desc", unit_person.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteUnit_Person(int UnitID, int PersonID)
        {
            string SqlStr = "UPDATE Unit_Person SET IsDel=1 where UnitID=@UnitID and PersonID=@PersonID";
            Unit_Person unit_person = new Unit_Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", unit_person.UnitID);
            cmd.Parameters.AddWithValue("@PersonID", unit_person.PersonID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }


        #endregion Unit_Person

        #region Tower_Unit

        public Unit LoadUnitWithTowerID(int TowerID)
        {
            string SqlStr = "select * from Tower_Unit where TowerID=@TowerID";
            Unit unit = new Unit();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerID", TowerID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unit.ID = int.Parse(r[0].ToString());
                unit.UnitCode = int.Parse(r[1].ToString());
                unit.UnitArea = int.Parse(r[2].ToString());
                unit.UnitFloor = int.Parse(r[3].ToString());
                unit.UnitPersonsNum = int.Parse(r[4].ToString());
                unit.Type = r[5].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit;
        }

        public Tower LoadTowerWithUnitID(int UnitID)
        {
            string SqlStr = "select * from Tower_Unit where UnitID=@UnitID";
            Tower tower = new Tower();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                tower.ID = int.Parse(r[0].ToString());
                tower.TowerTitle = r[1].ToString();
                tower.FloorCount = int.Parse(r[2].ToString());
                tower.UnitNum = int.Parse(r[3].ToString());
                tower.ParkingCount = int.Parse(r[4].ToString());
                tower.Area = int.Parse(r[5].ToString());
                tower.TowerNum = r[6].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return tower;
        }

        //public void InsertUnit(Unit unit)
        //{
        //    cn = CnnManager.Instance.GetConnection();
        //    cmd = new OleDbCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "Insert into tblUnits " +
        //                      " (UnitCode,UnitArea,UnitFloor,UnitPersonsNum,UnitType" +
        //                      " VALUES (@UnitCode,@UnitArea,@UnitFloor,@UnitPersonsNum,@UnitType)";

        //    Unit f = new Unit();
        //    f = unit;
        //    cmd.Parameters.AddWithValue("@UnitCode", f.UnitCode);
        //    cmd.Parameters.AddWithValue("@UnitArea", f.UnitArea);
        //    cmd.Parameters.AddWithValue("@UnitFloor", f.UnitFloor);
        //    cmd.Parameters.AddWithValue("@UnitPersonsNum", f.UnitPersonsNum);
        //    cmd.Parameters.AddWithValue("@UnitType", f.Type);

        //    cmd.ExecuteNonQuery();
        //    CnnManager.Instance.FreeConnection();
        //}

        //public void EditUnit(Unit unit)
        //{
        //    cn = CnnManager.Instance.GetConnection();
        //    cmd = new OleDbCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandText = "UPDATE    tblUnits " +
        //                         " SET  UnitCode = @UnitCode, UnitArea = @UnitArea, UnitFloor=@UnitFloor ,UnitPersonsNum=@UnitPersonsNum,UnitType=@UnitType" +
        //                         " where  UnitID = @UnitID";
        //    Unit f = new Unit();
        //    f = unit;
        //    cmd.Parameters.AddWithValue("@UnitCode", f.UnitCode);
        //    cmd.Parameters.AddWithValue("@UnitArea", f.UnitArea);
        //    cmd.Parameters.AddWithValue("@UnitFloor", f.UnitFloor);
        //    cmd.Parameters.AddWithValue("@UnitPersonsNum", f.UnitPersonsNum);
        //    cmd.Parameters.AddWithValue("@UnitType", f.Type);

        //    cmd.ExecuteNonQuery();
        //    CnnManager.Instance.FreeConnection();
        //}

        public void DeleteTower_Unit(int UnitID, int TowerID)
        {
            string SqlStr = "UPDATE Tower_Unit SET IsDel =1 where UnitID=@UnitID and TowerID=@TowerID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd.Parameters.AddWithValue("@TowerID", TowerID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion Tower_Unit

        #region Tower_Person

        public List<Person> LoadPersonListWithTowerID(int TowerID)
        {
            string SqlStr = "select * from Tower_Unit,Unit_Person where Tower_Unit.IsDel=0 and Unit_Person.IsDel=0 and Tower_Unit.TowerID=" + TowerID;
            List<Person> personList = new List<Person>();
            Person person = new Person();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                person = new Person();
                person.PersonID = int.Parse(r[0].ToString());
                person.Name = r[1].ToString();
                person.Family = r[2].ToString();
                person.FatherName = r[3].ToString();
                person.RegisterCardNum = r[4].ToString();
                person.NationalCode = r[5].ToString();
                person.Sex = bool.Parse(r[6].ToString());
                person.PicturePath = r[7].ToString();
                person.DateEnter = r[8].ToString();
                person.DateExit = r[9].ToString();
                personList.Add(person);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return personList;
        }
        #endregion Tower_Person

        #region Parking

        public Parking LoadParking(int ParkingID)
        {
            string SqlStr = "select * from tblParking where ParkingID=@ParkingID";
            Parking parking = new Parking();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ParkingID", ParkingID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                parking.ParkCode = r[1].ToString();
                parking.ParkSize = int.Parse(r[2].ToString());
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return parking;
        }

        public List<Parking> LoadParkingList(int ParkingID)
        {
            string SqlStr = "select * from tblParking where (ParkingIsDel=0) and ParkingID=@ParkingID";
            List<Parking> parkingList = new List<Parking>();
            Parking parking;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ParkingID", ParkingID);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                parking = new Parking();
                parking.ParkCode = r[1].ToString();
                parking.ParkSize = int.Parse(r[2].ToString());
                parkingList.Add(parking);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return parkingList;
        }



        public bool InsertParking(Parking parking1)
        {
            try
            {
                string SqlStr = "Insert into tblParking " +
                                  " (ParkingCode,ParkingSize,ParkingDesc)" +
                                  " VALUES (@ParkingCode,@ParkingSize,@ParkingDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Parking parking = new Parking();
                parking = parking1;
                cmd.Parameters.AddWithValue("@ParkingCode", parking.ParkCode);
                cmd.Parameters.AddWithValue("@ParkingSize", parking.ParkSize);
                cmd.Parameters.AddWithValue("@ParkingDesc", parking.ParkDesc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditParking(Parking parking1)
        {
            string SqlStr = "UPDATE tblParking " +
                                 " SET ParkingCode = @ParkingCode, ParkingSiz= @ParkingSiz,ParkingDesc=@ParkingDesc";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            Parking parking = new Parking();
            parking = parking1;
            cmd.Parameters.AddWithValue("@ParkingCode", parking.ParkCode);
            cmd.Parameters.AddWithValue("@ParkingSize", parking.ParkSize);
            cmd.Parameters.AddWithValue("@ParkingDesc", parking.ParkDesc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteParking(int ParkingID)
        {
            string SqlStr = "UPDATE tblParking SET ParkingIsDel =1 where ParkingID=@ParkingID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ParkingID", ParkingID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion Parking

        #region TowerInfo

        public TowerInfo LoadTowerInfo(int TowerInfoID)
        {
            string SqlStr = "select * from tblTowerInfo where TowerInfoID=@TowerInfoID";
            TowerInfo towerInfo = new TowerInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerInfoID", TowerInfoID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                towerInfo.TowerInfoID = int.Parse(r[0].ToString());
                towerInfo.InfoID = int.Parse(r[1].ToString());
                towerInfo.TowerInfoValue = r[2].ToString();
                towerInfo.TowerInfoDesc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return towerInfo;
        }


        public List<TowerInfo> LoadTowerInfoList(string TowerInfoValue)
        {
            string SqlStr = "select * from tblTowerInfo where (TowerIsDel=0) and TowerInfoValue=@TowerInfoValue";
            List<TowerInfo> towerInfoList = new List<TowerInfo>();
            TowerInfo towerInfo;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@TowerInfoValue", TowerInfoValue);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                towerInfo = new TowerInfo();
                towerInfo.TowerInfoID = int.Parse(r[0].ToString());
                towerInfo.InfoID = int.Parse(r[1].ToString());
                towerInfo.TowerInfoValue = r[2].ToString();
                towerInfo.TowerInfoDesc = r[3].ToString();
                towerInfoList.Add(towerInfo);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return towerInfoList;
        }

        public bool InsertTowerInfo(TowerInfo towerInfo1)
        {
            try
            {
                string SqlStr = "Insert into tblTowerInfo " +
                                  " (InfoID,TowerInfoValue,TowerInfoDesc)" +
                                  " VALUES (@InfoID,@TowerInfoValue,@TowerInfoDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                TowerInfo towerInfo = new TowerInfo();
                towerInfo = towerInfo1;
                cmd.Parameters.AddWithValue("@InfoID", towerInfo.InfoID);
                cmd.Parameters.AddWithValue("@TowerInfoValue", towerInfo.TowerInfoValue);
                cmd.Parameters.AddWithValue("@TowerInfoDesc", towerInfo.TowerInfoDesc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditTowerInfo(TowerInfo towerInfo1)
        {
            string SqlStr = "UPDATE tblTowerInfo " +
                                 " SET InfoID = @InfoID, TowerInfoValue = @TowerInfoValue, TowerInfoDesc=@TowerInfoDesc";
            TowerInfo towerInfo = new TowerInfo();
            towerInfo = towerInfo1;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@InfoID", towerInfo.InfoID);
            cmd.Parameters.AddWithValue("@TowerInfoValue", towerInfo.TowerInfoValue);
            cmd.Parameters.AddWithValue("@TowerInfoDesc", towerInfo.TowerInfoDesc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteTowerInfo(long InfoID)
        {
            string SqlStr = "UPDATE tblTowerInfo SET TowerIsDel =1 where InfoID=@InfoID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@InfoID", InfoID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion TowerInfo

        #region PersonsInfo

        public PersonsInfo LoadPersonInfo(int PersonsInfoID)
        {
            string SqlStr = "select * from tblPersonsInfo where PersonID=@PersonID";
            PersonsInfo personsInfo = new PersonsInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonID", PersonsInfoID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                personsInfo.PersonInfoID = int.Parse(r[1].ToString());
                personsInfo.PersonID = int.Parse(r[2].ToString());
                personsInfo.DetailInfoID = int.Parse(r[3].ToString());
                personsInfo.PersonInfoValue = r[4].ToString();
                personsInfo.PersonInfoDesc = r[5].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return personsInfo;
        }

        public List<PersonsInfo> LoadPersonsInfoList(string Name, string Family)
        {
            string SqlStr = "select * from tblPersonsInfo where (PersonIsDel=0) and Name=@Name and Family=@Family";
            List<PersonsInfo> personsInfoList = new List<PersonsInfo>();
            PersonsInfo personsInfo = new PersonsInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Family", Family);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                personsInfo = new PersonsInfo();
                personsInfo.PersonInfoID = int.Parse(r[1].ToString());
                personsInfo.PersonID = int.Parse(r[2].ToString());
                personsInfo.DetailInfoID = int.Parse(r[3].ToString());
                personsInfo.PersonInfoValue = r[4].ToString();
                personsInfo.PersonInfoDesc = r[5].ToString();
                personsInfoList.Add(personsInfo);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return personsInfoList;
        }

        public bool InsertPersonsInfo(PersonsInfo personsInfo1)
        {
            try
            {
                string SqlStr = "Insert into tblPersonsInfo " +
                                  " (PersonInfoID,PersonID,DetailInfoID,PersonInfoValue,PersonInfoDesc)" +
                                  " VALUES (@PersonInfoID,@PersonID,@DetailInfoID,@PersonInfoValue,@PersonInfoDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                PersonsInfo personsInfo = new PersonsInfo();
                personsInfo = personsInfo1;
                cmd.Parameters.AddWithValue("@PersonInfoID", personsInfo.PersonInfoID);
                cmd.Parameters.AddWithValue("@PersonID", personsInfo.PersonID);
                cmd.Parameters.AddWithValue("@DetailInfoID", personsInfo.DetailInfoID);
                cmd.Parameters.AddWithValue("@PersonInfoValue", personsInfo.PersonInfoValue);
                cmd.Parameters.AddWithValue("@PersonInfoDesc", personsInfo.PersonInfoDesc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditPersonsInfo(PersonsInfo personsInfo1)
        {
            string SqlStr = "UPDATE tblPersonsInfo " +
                                 " SET PersonID = @PersonID, DetailInfoID = @DetailInfoID, PersonInfoValue=@PersonInfoValue ,PersonInfoDesc=@PersonInfoDesc";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            PersonsInfo personsInfo = new PersonsInfo();
            personsInfo = personsInfo1;
            cmd.Parameters.AddWithValue("@PersonInfoID", personsInfo.PersonInfoID);
            cmd.Parameters.AddWithValue("@PersonID", personsInfo.PersonID);
            cmd.Parameters.AddWithValue("@DetailInfoID", personsInfo.DetailInfoID);
            cmd.Parameters.AddWithValue("@PersonInfoValue", personsInfo.PersonInfoValue);
            cmd.Parameters.AddWithValue("@PersonInfoDesc", personsInfo.PersonInfoDesc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeletePersonsInfo(int PersonsInfoID)
        {
            string SqlStr = "UPDATE tblPersonsInfo SET PersonIsDel =1 and PersonInfoID=@PersonInfoID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@PersonInfoID", PersonsInfoID);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion PersonsInfo

        #region   DetailInfo

        public DataTable LoadDetailInfoForGrid(Int64 BaseInfoID)
        {
            string SqlStr = "SELECT tblDetailInfo.DetailInfoTitle,tblBaseInfo.BaseInfoTitle,tblDetailInfo.DetailInfoDesc " +
            "FROM tblBaseInfo,tblDetailInfo " +
            " WHERE tblDetailInfo.BaseInfoID=@BaseInfoID and tblBaseInfo.BaseInfoID=tblDetailInfo.BaseInfoID ";
            //string SqlStr = "select * from tblDetailInfo WHERE BaseInfoID=@BaseInfoID";
            cn = CnnManager.Instance.GetConnection();
            cmd.Parameters.AddWithValue("@BaseInfoID", BaseInfoID);
            cmd = new OleDbCommand(SqlStr, cn);

            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable("tblDetailInfo");
            dt.Columns.Add("DetailInfoTitle", typeof(string));
            dt.Columns.Add("BaseInfoTitle", typeof(string));
            dt.Columns.Add("DetailInfoDesc", typeof(string));
            CnnManager.Instance.FreeConnection();
            //Da.Fill(dt);
            return dt;
        }
        public List<DetailInfo> LoadDetailInfoListWithBaseID(int baseInfoID)
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0) and BaseInfoID=@BaseInfoID ORDER BY DetailInfoTitle"; ;
            DetailInfo Detail = new DetailInfo();
            List<DetailInfo> DList = new List<DetailInfo>();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@BaseInfoID", baseInfoID);
            DataTable r = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(r);
            for (int co = 0; co < r.Rows.Count; co++)
            {
                Detail = new DetailInfo();
                Detail.DetailInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(0));
                Detail.DetailInfoTitle = r.Rows[co].ItemArray.GetValue(1).ToString();
                Detail.BaseInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(2));
                Detail.DetailInfoDesc = r.Rows[co].ItemArray.GetValue(3).ToString();
                DList.Add(Detail);
            }

            CnnManager.Instance.FreeConnection();
            return DList;
        }
        public DetailInfo LoadDetailInfoWithTitle(string DetailInfoTitle)
        {
            string SqlStr = "select * from tblDetailInfo where DetailInfoTitle=@DetailInfoTitle";
            DetailInfo detailInfo = new DetailInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailInfoTitle", DetailInfoTitle);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
                detailInfo.DetailInfoTitle = r[1].ToString();
                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
                detailInfo.DetailInfoDesc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return detailInfo;
        }

        public DetailInfo LoadDetailInfo(int DetailInfoID)
        {
            string SqlStr = "select * from tblDetailInfo where DetailInfoID=@DetailInfoID AND (IsDel=0)";
            DetailInfo detailInfo = new DetailInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailInfoID", DetailInfoID);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                detailInfo.DetailInfoID = int.Parse(r[0].ToString());
                detailInfo.DetailInfoTitle = r[1].ToString();
                detailInfo.BaseInfoID = int.Parse(r[2].ToString());
                detailInfo.DetailInfoDesc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return detailInfo;
        }
        

        public List<DetailInfo> LoadDetailInfoList()
        {
            string SqlStr = "select * from tblDetailInfo where (IsDel=0)";
            DetailInfo Detail = new DetailInfo();
            List<DetailInfo> DList = new List<DetailInfo>();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            DataTable r = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(r);
            for (int co = 0; co < r.Rows.Count; co++)
            {
                Detail = new DetailInfo();
                Detail.DetailInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(0));
                Detail.DetailInfoTitle = r.Rows[co].ItemArray.GetValue(1).ToString();
                Detail.BaseInfoID = Convert.ToInt32(r.Rows[co].ItemArray.GetValue(2));
                Detail.DetailInfoDesc = r.Rows[co].ItemArray.GetValue(3).ToString();
                DList.Add(Detail);
            }

            CnnManager.Instance.FreeConnection();
            return DList;
        }


        public bool InsertDetailInfo(DetailInfo detailInfo1)
        {
            try
            {
                string SqlStr = "Insert into tblDetailInfo " +
                                  " (DetailInfoTitle,BaseInfoID,DetailInfoDesc)" +
                                  " VALUES (@DetailInfoTitle,@BaseInfoID,@DetailInfoDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                DetailInfo detailInfo = new DetailInfo();
                detailInfo = detailInfo1;
                cmd.Parameters.AddWithValue("@DetailInfoTitle", detailInfo.DetailInfoTitle);
                cmd.Parameters.AddWithValue("@BaseInfoID", detailInfo.BaseInfoID);
                cmd.Parameters.AddWithValue("@DetailInfoDesc", detailInfo.DetailInfoDesc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditDetailInfo(DetailInfo DetailInfo)
        {
            string SqlStr = "UPDATE tblDetailInfo " +
                                 " SET DetailInfoTitle = @DetailInfoTitle, BaseInfoID = @BaseInfoID, DetailInfoDesc=@DetailInfoDesc ";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            DetailInfo detailInfo = new DetailInfo();
            detailInfo = DetailInfo;
            cmd.Parameters.AddWithValue("@DetailInfoTitle", detailInfo.DetailInfoTitle);
            cmd.Parameters.AddWithValue("@BaseInfoID", detailInfo.BaseInfoID);
            cmd.Parameters.AddWithValue("@DetailInfoDesc", detailInfo.DetailInfoDesc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteDetailInfo(int detailInfoID)
        {
            string SqlStr = "UPDATE tblDetailInfo SET IsDel=1 where DetailInfoID=@DetailInfoID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@DetailInfoID", detailInfoID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion  DetailInfo

        #region CarInfo

        public CarInfo LoadCarInfo(int CarInfoID)
        {
            string SqlStr = "select * from tblCarInfo where CarInfoID=@CarInfoID";
            CarInfo carInfo = new CarInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarInfoID", CarInfoID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                carInfo.CarInfoID = int.Parse(r[1].ToString());
                carInfo.InfoID = int.Parse(r[2].ToString());
                carInfo.CarInfoValue = r[3].ToString();
                carInfo.CarInfoDesc = r[4].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return carInfo;
        }

        public List<CarInfo> LoadCarInfoList(string CarInfoValue)
        {
            string SqlStr = "select * from tblCarInfo where (IsDel=0) and CarInfoValue=@CarInfoValue";
            List<CarInfo> carInfoList = new List<CarInfo>();
            CarInfo carInfo = new CarInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarInfoValue", CarInfoValue);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                carInfo = new CarInfo();
                carInfo.CarInfoID = int.Parse(r[0].ToString());
                carInfo.InfoID = int.Parse(r[1].ToString());
                carInfo.CarInfoValue = r[2].ToString();
                carInfo.CarInfoDesc = r[3].ToString();
                carInfoList.Add(carInfo);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return carInfoList;
        }

        public bool InsertCarInfo(CarInfo carInfo1)
        {
            try
            {
                string SqlStr = "Insert into tblCarInfo " +
                                  " (CarInfoID,InfoID,CarInfoValue,CarInfoDesc)" +
                                  " VALUES (@CarInfoID,@InfoID,@CarInfoValue,@CarInfoDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                CarInfo carInfo = new CarInfo();
                carInfo = carInfo1;
                cmd.Parameters.AddWithValue("@CarInfoID", carInfo.CarInfoID);
                cmd.Parameters.AddWithValue("@InfoID", carInfo.InfoID);
                cmd.Parameters.AddWithValue("@CarInfoValue", carInfo.CarInfoValue);
                cmd.Parameters.AddWithValue("@CarInfoDesc", carInfo.CarInfoDesc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditCarInfo(CarInfo carInfo1)
        {
            string SqlStr = "UPDATE tblCarInfo " +
                                 " SET CarInfoID = @CarInfoID, InfoID = @InfoID, CarInfoValue=@CarInfoValue ,CarInfoDesc=@CarInfoDesc";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            CarInfo carInfo = new CarInfo();
            carInfo = carInfo1;
            cmd.Parameters.AddWithValue("@CarInfoID", carInfo.CarInfoID);
            cmd.Parameters.AddWithValue("@InfoID", carInfo.InfoID);
            cmd.Parameters.AddWithValue("@CarInfoValue", carInfo.CarInfoValue);
            cmd.Parameters.AddWithValue("@CarInfoDesc", carInfo.CarInfoDesc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteCarInfo(int CarInfoID)
        {
            string SqlStr = "UPDATE tblCarInfo SET IsDel =1 where CarInfoID=@CarInfoID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@CarInfoID", CarInfoID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion CarInfo

        #region UnitInfo

        public UnitInfo LoadUnitInfo(int UnitInfoID)
        {
            string SqlStr = "select * from tblUnitInfo where UnitInfoID=@UnitInfoID AND (IsDel=0)";
            UnitInfo unitInfo = new UnitInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitInfoID", UnitInfoID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unitInfo.UnitInfoID = int.Parse(r[0].ToString());
                unitInfo.InfoID = int.Parse(r[1].ToString());
                unitInfo.UnitInfoValue = r[2].ToString();
                unitInfo.UnitInfoDesc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unitInfo;
        }

        //public UnitInfoList LoadUnitInfoList(string UnitInfoValue)
        //{
        //    string SqlStr = "select * from tblUnitInfo where (IsDel=0) ";
        //    UnitInfoList FList = new UnitInfoList();
        //    UnitInfo f = new UnitInfo();
        //    cn = CnnManager.Instance.GetConnection();
        //    cmd = new OleDbCommand(SqlStr, cn);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddWithValue("@UnitInfoValue", UnitInfoValue);
        //    OleDbDataReader r = cmd.ExecuteReader();
        //    while (r.Read())
        //    {
        //        f.UnitInfoID = int.Parse(r[1].ToString());
        //        f.InfoID = int.Parse(r[2].ToString());
        //        f.UnitInfoValue = r[3].ToString();
        //        f.UnitInfoDesc = r[4].ToString();
        //        FList.Add(f);
        //    }
        //    r.Close();
        //    CnnManager.Instance.FreeConnection();
        //    return FList;
        //}

        public List<UnitInfo> LoadUnitInfoList()
        {
            string SqlStr = "select * from tblUnitInfo where (IsDel=0)";
            List<UnitInfo> unitInfoList = new List<UnitInfo>();
            UnitInfo unitInfo = new UnitInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unitInfo = new UnitInfo();
                unitInfo.UnitInfoID = int.Parse(r[0].ToString());
                unitInfo.InfoID = int.Parse(r[1].ToString());
                unitInfo.UnitInfoValue = r[2].ToString();
                unitInfo.UnitInfoDesc = r[3].ToString();
                unitInfoList.Add(unitInfo);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unitInfoList;
        }

        public bool InsertUnitInfo(UnitInfo UnitInfo)
        {
            try
            {
                string SqlStr = "Insert into tblUnitInfo" +
                                  " (InfoID,UnitInfoValue,UnitInfoDesc)" +
                                  " VALUES (@InfoID,@UnitInfoValue,@UnitInfoDesc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                UnitInfo unitInfo = new UnitInfo();
                unitInfo = UnitInfo;
                //cmd.Parameters.AddWithValue("@UnitInfoID", unitInfo.UnitInfoID);
                cmd.Parameters.AddWithValue("@InfoID", unitInfo.InfoID);
                cmd.Parameters.AddWithValue("@UnitInfoValue", unitInfo.UnitInfoValue);
                cmd.Parameters.AddWithValue("@UnitInfoDesc", unitInfo.UnitInfoDesc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditUnitInfo(UnitInfo UnitInfo)
        {
            string SqlStr = "UPDATE tblUnitInfo " +
                                 " SET InfoID = @InfoID, vInfoValue=@UnitInfoValue ,UnitInfoDesc=@UnitInfoDesc";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            UnitInfo unitInfo = new UnitInfo();
            unitInfo = UnitInfo;
            cmd.Parameters.AddWithValue("@InfoID", unitInfo.InfoID);
            cmd.Parameters.AddWithValue("@UnitInfoValue", unitInfo.UnitInfoValue);
            cmd.Parameters.AddWithValue("@UnitInfoDesc", unitInfo.UnitInfoDesc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteUnitInfo(int UnitInfoID)
        {
            string SqlStr = "UPDATE tblUnitInfo SET IsDel=1 where UnitInfoID=@UnitInfoID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitInfoID", UnitInfoID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion UnitInfo

        #region BaseInfo

        public List<BaseInfo> LoadBaseInfoList()
        {
            string SqlStr = "select * from tblBaseInfo";
            List<BaseInfo> baseInfoList = new List<BaseInfo>();
            BaseInfo baseInfo = new BaseInfo();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                baseInfo = new BaseInfo();
                baseInfo.BaseInfoID = int.Parse(r[0].ToString());
                baseInfo.BaseInfoTitle = r[1].ToString();
                baseInfo.BaseInfoDesc = r[2].ToString();
                baseInfoList.Add(baseInfo);
            }

            CnnManager.Instance.FreeConnection();
            return baseInfoList;
        }

        public BaseInfo LoadBaseInfo(int baseInfoID)
        {
            string SqlStr = "select * from tblBaseInfo where BaseInfoID=@BaseInfoID";
            BaseInfo baseInfo = new BaseInfo();
            BaseInfo[] baseInfoList = new BaseInfo[4];
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@BaseInfoID", baseInfoID);
            OleDbDataReader r = cmd.ExecuteReader();
            int i = 0;
            if (r.Read())
            {
                baseInfo.BaseInfoID = int.Parse(r[0].ToString());
                baseInfo.BaseInfoTitle = r[1].ToString();
                baseInfo.BaseInfoDesc = r[2].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return baseInfo;
        }
        #endregion BaseInfo

        #region Person_Car

        public List<Person> LoadPersonWithCarID(int CarID)
        {
            string SqlStr = "select * from Person_Car where IsDel=0 and CarID=@CarID";
            Person_Car person_car = new Person_Car();
            List<Person_Car> person_carList = new List<Person_Car>();
            List<Person> personList = new List<Person>();
            Person person = new Person();
            cn = CnnManager.Instance.GetConnection();
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                person_car = new Person_Car();
                person_car.PersonID = int.Parse(r[0].ToString());
                person_carList.Add(person_car);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; person_carList.Count > i; i++)
            {
                person = new Person();
                person = LoadPerson(person_carList[i].PersonID);
                personList.Add(person);
            }
            return personList;
        }
        public List<Car> LoadCarsWithPersonID(int PersonID)
        {
            string SqlStr = "select * from Person_Car where PersonID=@PersonID";
            Person_Car person_car = new Person_Car();
            List<Person_Car> person_carList = new List<Person_Car>();
            Car car = new Car();
            List<Car> carList = new List<Car>();
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                person_car = new Person_Car();
                person_car.CarID = int.Parse(r[1].ToString());
                person_carList.Add(person_car);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; person_carList.Count > i; i++)
            {
                car = new Car();
                car = LoadCar(person_carList[i].CarID);
                carList.Add(car);
            }

            return carList;
        }

        #endregion Person_Car

        #region Unit_Car
        public DataTable LoadUnitWithCarIDForGridEX(Int64 UnitID, int CarID)
        {
            string SqlStr = "SELECT C.CarCode,C.CarModel,UC.UnitCode,UC.UnitNumber," +
                "FROM UnitCar AS UC INNER JOIN tblUnits AS U INNER JOIN tblCar AS C ON U.UnitID=UC.UnitID and C.CarCode=CarID" +
                " WHERE UnitID=@UnitID";
            cn = CnnManager.Instance.GetConnection();
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd = new OleDbCommand(SqlStr, cn);

            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            CnnManager.Instance.FreeConnection();
            Da.Fill(dt);
            return dt;
        }

        public List<Unit> LoadUnitWithCarID(int CarID)
        {

            string SqlStr = "select * from Unit_Car where IsDel=0 and CarID=@CarID";
            Unit_Car unit_car = new Unit_Car();
            List<Unit_Car> unit_carList = new List<Unit_Car>();
            List<Unit> unitList = new List<Unit>();
            Unit unit = new Unit();
            cn = CnnManager.Instance.GetConnection();
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_car = new Unit_Car();
                unit_car.UnitID = int.Parse(r[0].ToString());
                unit_carList.Add(unit_car);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; unit_carList.Count > i; i++)
            {
                unit = new Unit();
                unit = LoadUnit(unit_carList[i].UnitID);
                unitList.Add(unit);
            }
            return unitList;
        }
        public List<Car> LoadCarsWithUnitID(int UnitID)
        {
            string SqlStr = "select * from Unit_Car where UnitID=@UnitID";
            Unit_Car unit_car = new Unit_Car();
            List<Unit_Car> unit_carList = new List<Unit_Car>();
            Car car = new Car();
            List<Car> carList = new List<Car>();
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unit_car = new Unit_Car();
                unit_car.CarID = int.Parse(r[1].ToString());
                unit_carList.Add(unit_car);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; unit_carList.Count > i; i++)
            {
                car = new Car();
                carList.Add(car);
            }

            return carList;
        }

        #endregion Unit_Car

        #region Contor

        public Contor LoadContor(int ContorID)
        {
            string SqlStr = "select * from tblContor where (ContorIsDel=0) and ContorID=@ContorID";
            Contor contor = new Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                contor.ContorID = int.Parse(r[0].ToString());
                contor.ContorNum = int.Parse(r[1].ToString());
                contor.ContorValue = r[2].ToString();
                contor.Desc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return contor;
        }


        public List<Contor> LoadContorListWithContorTitle(string ContorValue)
        {
            string SqlStr = "select * from tblContor where (ContorIsDel=0) and ContorValue=@ContorValue";
            List<Contor> contorList = new List<Contor>();
            Contor contor = new Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorValue", ContorValue);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                contor = new Contor();
                contor.ContorID = int.Parse(r[0].ToString());
                contor.ContorNum = int.Parse(r[1].ToString());
                contor.ContorValue = r[2].ToString();
                contor.Desc = r[3].ToString();
                contorList.Add(contor);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return contorList;
        }
        public Contor LoadContorListWithContorNum(int ContorNum)
        {
            string SqlStr = "select * from tblContor where (ContorIsDel=0) and ContorNum=@ContorNum";
            List<Contor> contorList = new List<Contor>();
            Contor contor = new Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorNum", ContorNum);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                contor.ContorID = int.Parse(r[0].ToString());
                contor.ContorNum = int.Parse(r[1].ToString());
                contor.ContorValue = r[2].ToString();
                contor.Desc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return contor;
        }
        public List<Contor> LoadContorList()
        {
            string SqlStr = "select * from tblContor where (ContorIsDel=0) ";
            List<Contor> contorList = new List<Contor>();
            Contor contor;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                contor = new Contor();
                contor.ContorID = int.Parse(r[0].ToString());
                contor.ContorNum = int.Parse(r[1].ToString());
                contor.ContorValue = r[2].ToString();
                contor.Desc = r[3].ToString();
                contorList.Add(contor);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return contorList;
        }

        public bool InsertContor(Contor contor1)
        {
            try
            {

                string SqlStr = "Insert into tblContor " +
                                  " (ContorNum,ContorValue,Desc)" +
                                  " VALUES (@ContorNum,@ContorValue,@Desc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Contor contor = new Contor();
                contor = contor1;
                cmd.Parameters.AddWithValue("@ContorNum", contor.ContorNum);
                cmd.Parameters.AddWithValue("@ContorValue", contor.ContorValue);
                cmd.Parameters.AddWithValue("@Desc", contor.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditContor(Contor Contor)
        {
            string SqlStr = "UPDATE tblContor " +
                                 " SET ContorNum = @ContorNum, ContorValue = @ContorValue, Desc=@Desc ";
            Contor contor = new Contor();
            contor = Contor;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorNum", contor.ContorNum);
            cmd.Parameters.AddWithValue("@ContorValue", contor.ContorValue);
            cmd.Parameters.AddWithValue("@Desc", contor.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteContor(int ContorID)
        {
            string SqlStr = "UPDATE tblContor SET ContorIsDel =1 where ContorID=@ContorID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion Contor

        #region Unit_Contor
        public DataTable LoadUnit_ContorForGridEX(int UnitID, int ContorID)
        {
            string SqlStr = "SELECT U.UnitCode,U.UnitNumber,C.ContorNum,C.ContorValue," +
                            "FROM tblUnits AS U INNER JOIN tblContor AS C INNER JOIN Unit_Contor AS UC ON UC.UnitID=U.UnitID and UC.ContorID=C.ContorID" +
               "WHERE UnitID=@UnitID and ContorID=@ContorID";
            cn = CnnManager.Instance.GetConnection();
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            CnnManager.Instance.FreeConnection();
            Da.Fill(dt);
            return dt;
        }

        public Unit_Contor LoadUnit_Contor(int UnitID, int ContorID)
        {
            string SqlStr = "select * from Unit_Contor where (IsDel=0) AND UnitID=@UnitID,ContorID@ContorID ";
            Unit_Contor unit_contor = new Unit_Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_contor.UnitID = int.Parse(r[0].ToString());
                unit_contor.ContorID = int.Parse(r[1].ToString());
                unit_contor.Desc = r[2].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_contor;
        }
        public List<Unit_Contor> LoadUnit_ContorList()
        {
            string SqlStr = "select * from Unit_Contor where (IsDel=0) ";
            List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
            Unit_Contor unit_contor = new Unit_Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_contor.UnitID = int.Parse(r[0].ToString());
                unit_contor.ContorID = int.Parse(r[1].ToString());
                unit_contor.Desc = r[2].ToString();
                unit_contorList.Add(unit_contor);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_contorList;
        }
        public List<Unit_Contor> LoadUnit_ContorListForGrid()
        {
            string SqlStr = "select * from Unit_Contor where (IsDel=0) ";
            List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
            Unit_Contor unit_contor = new Unit_Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unit_contor.UnitID = int.Parse(r[0].ToString());
                unit_contor.ContorID = int.Parse(r[1].ToString());
                unit_contor.Desc = r[2].ToString();
                unit_contorList.Add(unit_contor);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unit_contorList;
        }
        //public List<Unit_Person> LoadUnit_PersonListWithPersonID()
        //{
        //    string SqlStr = "select * from Unit_Person,Person where Unit_Person.IsDel=0 and  Person.PersonID=Unit_Person.PersonID";
        //    List<Unit_Person> unit_personList = new List<Unit_Person>();
        //    Unit_Person unit_person;
        //    Person person;
        //    cn = CnnManager.Instance.GetConnection();
        //    cmd = new OleDbCommand(SqlStr, cn);
        //    OleDbDataReader r = cmd.ExecuteReader();
        //    while (r.Read())
        //    {
        //        unit_person = new Unit_Person();
        //        person = new Person();
        //        unit_person.UnitID = int.Parse(r[0].ToString());
        //        //unit_person.PersonID = int.Parse(r[1].ToString());
        //        unit_person.Relation = r[2].ToString();
        //        unit_person.Desc = r[3].ToString();
        //        person.Family =r[5].ToString();
        //        unit_personList.Add(unit_person);
        //    }
        //    r.Close();
        //    CnnManager.Instance.FreeConnection();
        //    return unit_personList;
        //}
        public List<Contor> LoadContorWithUnitID(int UnitID)
        {
            string SqlStr = "select * from Unit_Contor where UnitID=@UnitID AND IsDel=0";
            Unit_Contor unit_contor = new Unit_Contor();
            List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
            Contor contor = new Contor();
            List<Contor> contorList = new List<Contor>();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unit_contor = new Unit_Contor();
                unit_contor.UnitID = int.Parse(r[0].ToString());
                unit_contor.ContorID = int.Parse(r[1].ToString());
                unit_contor.Desc = r[2].ToString();
                unit_contorList.Add(unit_contor);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; unit_contorList.Count > i; i++)
            {
                contor = new Contor();
                contor = LoadContor(unit_contorList[i].ContorID);
                contorList.Add(contor);
            }

            return contorList;
        }

        public List<Unit> LoadUnitWithContorID(int ContorID)
        {
            string SqlStr = "select * from Unit_Contor where ContorID=@ContorID AND IsDel=0";
            Unit_Contor unitContor = new Unit_Contor();
            List<Unit_Contor> unitContorList = new List<Unit_Contor>();
            Unit unit = new Unit();
            List<Unit> unitList = new List<Unit>();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ContorID", ContorID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unitContor = new Unit_Contor();
                unitContor.UnitID = int.Parse(r[0].ToString());
                unitContorList.Add(unitContor);
            }
            CnnManager.Instance.FreeConnection();
            for (int i = 0; unitContorList.Count > i; i++)
            {
                unit = new Unit();
                unit = LoadUnit(unitContorList[i].UnitID);
                unitList.Add(unit);
            }

            return unitList;
        }
        public bool InsertUnit_Contor(Unit_Contor UnitContor)
        {
            try
            {
                string SqlStr = "Insert into Unit_Contor " +
                                  " (UnitID,ContorID,Desc)" +
                                  " VALUES (@UnitID,@ContorID,@Desc)";
                Unit_Contor unit_Contor = new Unit_Contor();
                unit_Contor = UnitContor;
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);

                cmd.Parameters.AddWithValue("@ContorID", unit_Contor.ContorID);
                cmd.Parameters.AddWithValue("@UnitID", unit_Contor.UnitID);
                cmd.Parameters.AddWithValue("@Desc", unit_Contor.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditUnit_Person(Unit_Contor UnitContor)
        {
            string SqlStr = "UPDATE Unit_Contor " +
                                 " SET ContorID = @ContorID, UnitID = @UnitID,Desc=@Desc ";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            Unit_Contor unit_Contor = new Unit_Contor();
            unit_Contor = UnitContor;
            cmd.Parameters.AddWithValue("@ContorID", unit_Contor.ContorID);
            cmd.Parameters.AddWithValue("@UnitID", unit_Contor.UnitID);
            cmd.Parameters.AddWithValue("@Desc", unit_Contor.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteUnit_Contor(int UnitID, int ContorID)
        {
            string SqlStr = "UPDATE Unit_Contor SET IsDel=1 where UnitID=@UnitID and ContorID=@ContorID";
            Unit_Contor unit_Contor = new Unit_Contor();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnitID", unit_Contor.UnitID);
            cmd.Parameters.AddWithValue("@ContorID", unit_Contor.ContorID);
            cmd.Parameters.AddWithValue("@Desc", unit_Contor.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion Unit_Contor

        #region IndependentSharj

        public IndependentSharj LoadIndependentSharj(int IndependentID)
        {
            string SqlStr = "select * from tblIndependentSharj where (IsDel=0) and IndependentID=@IndependentID";
            IndependentSharj independentsharj = new IndependentSharj();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IndependentID", IndependentID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                independentsharj.ID = int.Parse(r[0].ToString());
                independentsharj.IndependentID = int.Parse(r[1].ToString());
                independentsharj.Sharj = int.Parse(r[2].ToString());
                independentsharj.Desc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independentsharj;
        }


        public List<IndependentSharj> LoadIndependentSharjListWithSharj(int Sharj)
        {
            string SqlStr = "select * from tblContor where (IsDel=0) and Sharj=@Sharj";
            List<IndependentSharj> independentsharjList = new List<IndependentSharj>();
            IndependentSharj independentsharj = new IndependentSharj();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Sharj", Sharj);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                independentsharj = new IndependentSharj();
                independentsharj.ID = int.Parse(r[0].ToString());
                independentsharj.IndependentID = int.Parse(r[1].ToString());
                independentsharj.Sharj = int.Parse(r[2].ToString());
                independentsharj.Desc = r[3].ToString();
                independentsharjList.Add(independentsharj);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independentsharjList;
        }

        public List<IndependentSharj> LoadIndependentSharjList()
        {
            string SqlStr = "select * from tblIndependentSharj where (IsDel=0) ";
            List<IndependentSharj> independentsharjList = new List<IndependentSharj>();
            IndependentSharj independentsharj;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                independentsharj = new IndependentSharj();
                independentsharj.ID = int.Parse(r[0].ToString());
                independentsharj.IndependentID = int.Parse(r[1].ToString());
                independentsharj.Sharj = int.Parse(r[2].ToString());
                independentsharj.Desc = r[3].ToString();
                independentsharjList.Add(independentsharj);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return independentsharjList;
        }

        public bool InsertIndependentSharj(IndependentSharj independentsharj1)
        {
            try
            {
                string SqlStr = "Insert into tblIndependentSharj " +
                                  " (IndependentID,Sharj,Desc)" +
                                  " VALUES (@IndependentID,@Sharj,@Desc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                IndependentSharj independentsharj = new IndependentSharj();
                independentsharj = independentsharj1;
                cmd.Parameters.AddWithValue("@IndependentID", independentsharj.IndependentID);
                cmd.Parameters.AddWithValue("@Sharj", independentsharj.Sharj);
                cmd.Parameters.AddWithValue("@Desc", independentsharj.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditIndependentSharj(IndependentSharj IndependentSharj)
        {
            string SqlStr = "UPDATE [tblIndependentSharj].[dbo] " +
                                 " SET IndependentID = @IndependentID, Sharj = @Sharj, Desc=@Desc ";
            IndependentSharj independentsharj = new IndependentSharj();
            independentsharj = IndependentSharj;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@IndependentID", independentsharj.IndependentID);
            cmd.Parameters.AddWithValue("@Sharj", independentsharj.Sharj);
            cmd.Parameters.AddWithValue("@Desc", independentsharj.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeletendependentSharj(int ID)
        {
            string SqlStr = "UPDATE tblIndependentSharj SET IsDel =1 where ID=@ID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion ucIndependentSharj

        #region Unforeseen

        public Unforeseen LoadUnforeseen(int UnforeseenID)
        {
            string SqlStr = "select * from tblUnforeseen where (IsDel=0) and UnforeseenID=@UnforeseenID";
            Unforeseen unforeseen = new Unforeseen();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@UnforeseenID", UnforeseenID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                unforeseen.ID = int.Parse(r[0].ToString());
                unforeseen.Title = r[1].ToString();
                unforeseen.Sharj = int.Parse(r[2].ToString());
                unforeseen.Desc = r[3].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unforeseen;
        }


        public List<Unforeseen> LoadUnforeseenListWithSharj(int Sharj)
        {
            string SqlStr = "select * from tblUnforeseen where (IsDel=0) and Sharj=@Sharj";
            List<Unforeseen> unforeseenList = new List<Unforeseen>();
            Unforeseen unforeseen = new Unforeseen();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Sharj", Sharj);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unforeseen = new Unforeseen();
                unforeseen.ID = int.Parse(r[0].ToString());
                unforeseen.Title = r[1].ToString();
                unforeseen.Sharj = int.Parse(r[2].ToString());
                unforeseen.Desc = r[3].ToString();
                unforeseenList.Add(unforeseen);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unforeseenList;
        }

        public List<Unforeseen> LoadUnforeseenList()
        {
            string SqlStr = "select * from tblUnforeseen where (IsDel=0) ";
            List<Unforeseen> unforeseenList = new List<Unforeseen>();
            Unforeseen unforeseen;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                unforeseen = new Unforeseen();
                unforeseen.ID = int.Parse(r[0].ToString());
                unforeseen.Title = r[1].ToString();
                unforeseen.Sharj = int.Parse(r[2].ToString());
                unforeseen.Desc = r[3].ToString();
                unforeseenList.Add(unforeseen);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return unforeseenList;
        }

        public bool InsertUnforeseen(Unforeseen Unforeseen)
        {
            try
            {
                string SqlStr = "Insert into tblUnforeseen " +
                                  " (Title,Sharj,Desc)" +
                                  " VALUES (@Title,@Sharj,@Desc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Unforeseen unforeseen = new Unforeseen();
                unforeseen = Unforeseen;
                cmd.Parameters.AddWithValue("@Title", unforeseen.Title);
                cmd.Parameters.AddWithValue("@Sharj", unforeseen.Sharj);
                cmd.Parameters.AddWithValue("@Desc", unforeseen.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditUnforeseen(Unforeseen Unforeseen)
        {
            string SqlStr = "UPDATE tblUnforeseen " +
                                 " SET Title = @Title, Sharj = @Sharj, Desc=@Desc ";
            Unforeseen unforeseen = new Unforeseen();
            unforeseen = Unforeseen;
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Title", unforeseen.Title);
            cmd.Parameters.AddWithValue("@Sharj", unforeseen.Sharj);
            cmd.Parameters.AddWithValue("@Desc", unforeseen.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteUnforeseen(int ID)
        {
            string SqlStr = "UPDATE tblUnforeseen SET IsDel =1 where ID=@ID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }
        #endregion Unforeseen

        #region Fiche

        public Fiche LoadFiche(int FicheID)
        {
            string SqlStr = "select * from tblFiche where FicheIsDel=0 and FicheID=@FicheID";
            Fiche fiche = new Fiche();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FicheID", FicheID);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                fiche.FicheID = int.Parse(r[0].ToString());
                fiche.TypeContor = r[1].ToString();
                fiche.Title = r[2].ToString();
                fiche.Cost = int.Parse(r[3].ToString());
                fiche.FromDate = r[4].ToString();
                fiche.UntillDate = r[5].ToString();
                fiche.Desc = r[6].ToString();

            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return fiche;
        }

        public Fiche LoadFicheWithTitle(string Title)
        {
            string SqlStr = "select * from tblFiche where FicheIsDel=0 and Title=@Title";
            Fiche fiche = new Fiche();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@Title", Title);
            OleDbDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                fiche.FicheID = int.Parse(r[0].ToString());
                fiche.TypeContor = r[1].ToString();
                fiche.Title = r[2].ToString();
                fiche.Cost = int.Parse(r[3].ToString());
                fiche.FromDate = r[4].ToString();
                fiche.UntillDate = r[5].ToString();
                fiche.Desc = r[6].ToString();
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return fiche;
        }

        public List<Fiche> LoadFicheList()
        {
            string SqlStr = "select * from tblFiche where (FicheIsDel=0)";
            List<Fiche> ficheList = new List<Fiche>();
            Fiche fiche = new Fiche();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                fiche = new Fiche();
                fiche.FicheID = int.Parse(r[0].ToString());
                fiche.TypeContor = r[1].ToString();
                fiche.Title = r[2].ToString();
                fiche.Cost = int.Parse(r[3].ToString());
                fiche.FromDate = r[4].ToString();
                fiche.UntillDate = r[5].ToString();
                fiche.Desc = r[6].ToString();
                ficheList.Add(fiche);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return ficheList;
        }

        public List<Fiche> LoadFicheListWithDate(string FromDate, string UntillDate)
        {
            string SqlStr = "select * from tblFiche where (FicheIsDel=0) and FromDate=@FromDate and UntillDate=@UntillDate";
            List<Fiche> ficheList = new List<Fiche>();
            Fiche fiche = new Fiche();
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", UntillDate);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                fiche = new Fiche();
                fiche.FicheID = int.Parse(r[0].ToString());
                fiche.TypeContor = r[1].ToString();
                fiche.Title = r[2].ToString();
                fiche.Cost = int.Parse(r[3].ToString());
                fiche.FromDate = r[4].ToString();
                fiche.UntillDate = r[5].ToString();
                fiche.Desc = r[6].ToString();
                ficheList.Add(fiche);
            }
            r.Close();
            CnnManager.Instance.FreeConnection();
            return ficheList;
        }


        public bool InsertFiche(Fiche Fiche)
        {
            try
            {
                string SqlStr = "Insert into tblFiche " +
                                  " (TypeContor,Title,Cost,FromDatee,UntillDate,Desc)" +
                                  " VALUES (TypeContor,@Title,@Cost,@FromDate,@UntillDate,@Desc)";
                cn = CnnManager.Instance.GetConnection();
                cmd = new OleDbCommand(SqlStr, cn);
                Fiche fiche = new Fiche();
                fiche = Fiche;
                cmd.Parameters.AddWithValue("@TypeContor", fiche.TypeContor);
                cmd.Parameters.AddWithValue("@Title", fiche.Title);
                cmd.Parameters.AddWithValue("@Cost", fiche.Cost);
                cmd.Parameters.AddWithValue("@FromDate", fiche.FromDate);
                cmd.Parameters.AddWithValue("@UntillDate", fiche.UntillDate);
                cmd.Parameters.AddWithValue("@Desc", fiche.Desc);
                cmd.ExecuteNonQuery();
                CnnManager.Instance.FreeConnection();
                return true;
            }
            catch { return false; }
        }

        public void EditFiche(Fiche Fiche)
        {
            string SqlStr = "UPDATE tblFiche " +
                                 " SET TypeContor=@TypeContor,Title = @Title, Cost = @Cost, FromDate=@FromDate ,Desc=@Desc";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            Fiche fiche = new Fiche();
            fiche = Fiche;
            cmd.Parameters.AddWithValue("@TypeContor", fiche.TypeContor);
            cmd.Parameters.AddWithValue("@Title", fiche.Title);
            cmd.Parameters.AddWithValue("@Cost", fiche.Cost);
            cmd.Parameters.AddWithValue("@FromDate", fiche.FromDate);
            cmd.Parameters.AddWithValue("@UntillDate", fiche.UntillDate);
            cmd.Parameters.AddWithValue("@Desc", fiche.Desc);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        public void DeleteFiche(int FicheID)
        {
            string SqlStr = "UPDATE tblFiche SET FicheIsDel =1 where FicheID=@FicheID";
            cn = CnnManager.Instance.GetConnection();
            cmd = new OleDbCommand(SqlStr, cn);
            cmd.Parameters.AddWithValue("@FicheID", FicheID);
            cmd.ExecuteNonQuery();
            CnnManager.Instance.FreeConnection();
        }

        #endregion Fiche

    }
}
