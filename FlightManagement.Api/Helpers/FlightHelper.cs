using FlightManagement.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FlightManagement.Api.Models;
using System.Web.Http;

namespace FlightManagement.Api.Helpers
{
    public class FlightHelper
    {
        public static User CheckLogin(string username, string password)
        {
            var result = new User();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@UserName", SqlDbType = SqlDbType.NVarChar, Value = username });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Value = password });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.SelectOne });
                var dt = DbProvider.GetDataTable("UserCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    result.Type = dt.Rows[0]["Type"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static bool FlightInsert(Flights flights)
        {
            var result = false;
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@FlightNo", SqlDbType = SqlDbType.NVarChar, Value = flights.FlightNo });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@StartDate", SqlDbType = SqlDbType.Date, Value = flights.StartDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@EndDate", SqlDbType = SqlDbType.Date, Value = flights.EndDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@PassCapacity", SqlDbType = SqlDbType.Int, Value = flights.PassCapacity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@DepartCity", SqlDbType = SqlDbType.NVarChar, Value = flights.DepartCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@ArrivalCity", SqlDbType = SqlDbType.NVarChar, Value = flights.ArrivalCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.Insert });
                var output = DbProvider.ExecuteNonQuery("FlightCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (output > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }


        public static bool FlightUpdate(Flights flights)
        {
            var result = false;
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.BigInt, Value = flights.ID });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@FlightNo", SqlDbType = SqlDbType.NVarChar, Value = flights.FlightNo });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@StartDate", SqlDbType = SqlDbType.Date, Value = flights.StartDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@EndDate", SqlDbType = SqlDbType.Date, Value = flights.EndDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@PassCapacity", SqlDbType = SqlDbType.Int, Value = flights.PassCapacity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@DepartCity", SqlDbType = SqlDbType.NVarChar, Value = flights.DepartCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@ArrivalCity", SqlDbType = SqlDbType.NVarChar, Value = flights.ArrivalCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.Update });
                var output = DbProvider.ExecuteNonQuery("FlightCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (output > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static bool FlightDelete(string ID)
        {
            var result = false;
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.BigInt, Value = Convert.ToInt64(ID) });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.Delete });
                var output = DbProvider.ExecuteNonQuery("FlightCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (output > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static List<Flights> FlightSelectAll()
        {
            DataTable dt = null;
            List<Flights> result = new List<Flights>();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.SelectAll });
                dt = DbProvider.GetDataTable("FlightCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = new Flights();
                        row.ID = dt.Rows[i].Field<Int64>("ID");
                        row.FlightNo = dt.Rows[i].Field<string>("FlightNo");
                        row.StartDate = dt.Rows[i].Field<string>("StartDate");
                        row.EndDate = dt.Rows[i].Field<string>("EndDate");
                        row.PassCapacity = dt.Rows[i].Field<int>("PassCapacity");
                        row.DepartCity = dt.Rows[i].Field<string>("DepartCity");
                        row.ArrivalCity = dt.Rows[i].Field<string>("ArrivalCity");
                        row.Status = dt.Rows[i].Field<string>("Status");
                        result.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static Flights FlightSelectOne(string ID)
        {
            DataTable dt = new DataTable();
            var result = new Flights();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.BigInt, Value = Convert.ToInt64(ID) });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.SelectOne });
                dt = DbProvider.GetDataTable("FlightCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.ID = dt.Rows[0].Field<Int64>("ID");
                    result.FlightNo = dt.Rows[0].Field<string>("FlightNo");
                    result.StartDate = dt.Rows[0].Field<string>("StartDate");
                    result.EndDate = dt.Rows[0].Field<string>("EndDate");
                    result.PassCapacity = dt.Rows[0].Field<int>("PassCapacity");
                    result.DepartCity = dt.Rows[0].Field<string>("DepartCity");
                    result.ArrivalCity = dt.Rows[0].Field<string>("ArrivalCity");
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static bool BookingInsert(Passenger passenger)
        {
            var result = false;
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BookID", SqlDbType = SqlDbType.NVarChar, Value = passenger.BookID });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@FlightID", SqlDbType = SqlDbType.BigInt, Value = passenger.FlightID });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@PassName", SqlDbType = SqlDbType.NVarChar, Value = passenger.PessName });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BDate", SqlDbType = SqlDbType.NVarChar, Value = passenger.BDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BArrivalCity", SqlDbType = SqlDbType.NVarChar, Value = passenger.BArrivalCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BDepartCity", SqlDbType = SqlDbType.NVarChar, Value = passenger.BDepartCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = passenger.UserID });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.NVarChar, Value = passenger.Status });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.Insert });
                var output = DbProvider.ExecuteNonQuery("BookingCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (output > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static bool BookingUpdate(Passenger passenger)
        {
            var result = false;
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BookID", SqlDbType = SqlDbType.NVarChar, Value = passenger.BookID });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@FID", SqlDbType = SqlDbType.BigInt, Value = passenger.FlightID });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@PassName", SqlDbType = SqlDbType.NVarChar, Value = passenger.PessName });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BDate", SqlDbType = SqlDbType.NVarChar, Value = passenger.BDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BArrivalCity", SqlDbType = SqlDbType.NVarChar, Value = passenger.BArrivalCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BDepartCity", SqlDbType = SqlDbType.NVarChar, Value = passenger.BDepartCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.Update });
                var output = DbProvider.ExecuteNonQuery("BookingCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (output > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static bool BookingDelete(string ID)
        {
            var result = false;
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.BigInt, Value = Convert.ToInt64(ID) });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.Delete });
                var output = DbProvider.ExecuteNonQuery("BookingCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (output > 0)
                    result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static List<Passenger> BookingSelectAll(string UserID)
        {
            DataTable dt = new DataTable();
            List<Passenger> result = new List<Passenger>();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Convert.ToInt64(UserID) });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.SelectAll });
                dt = DbProvider.GetDataTable("BookingCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = new Passenger();
                        row.ID = dt.Rows[i].Field<Int64>("ID");
                        row.BookID = dt.Rows[i].Field<string>("BookID");
                        row.FlightID = dt.Rows[i].Field<Int64>("FlightID");
                        row.UserID = dt.Rows[i].Field<Int32>("UserID").ToString();
                        row.PessName = dt.Rows[i].Field<string>("PassengerName");
                        row.BDate = dt.Rows[i].Field<string>("BDate");
                        row.BArrivalCity = dt.Rows[i].Field<string>("BArrivalCity");
                        row.BDepartCity = dt.Rows[i].Field<string>("BDepartCity");
                        result.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        //public static DataTable BookingSelectOne(string )
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        var lstSqlParameter = new List<SqlParameter>();
        //        lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.SelectAll });
        //        dt = DbProvider.GetDataTable("BookingCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return dt;
        //}

        public static List<Flights> FlightsAvailability(string StartDate, string EndDate, int NoOfPassenger)
        {
            DataTable dt = new DataTable();
            var result = new List<Flights>();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@Startdate", SqlDbType = SqlDbType.NVarChar, Value = StartDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@Enddate", SqlDbType = SqlDbType.NVarChar, Value = EndDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@NoPass", SqlDbType = SqlDbType.Int, Value = NoOfPassenger });
                dt = DbProvider.GetDataTable("FlightsAvailability", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = new Flights();
                        row.ID = dt.Rows[i].Field<Int64>("ID");
                        row.StartDate = dt.Rows[i].Field<string>("StartDate");
                        row.EndDate = dt.Rows[i].Field<string>("EndDate");
                        row.PassCapacity = dt.Rows[i].Field<int>("PassCapacity");
                        row.DepartCity = dt.Rows[i].Field<string>("DepartCity");
                        row.ArrivalCity = dt.Rows[i].Field<string>("ArrivalCity");
                        row.Status= dt.Rows[i].Field<string>("Status");
                        row.FlightNo = dt.Rows[i].Field<string>("FlightNo");
                        result.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static List<Passenger> BookingFilter(string PassName, string BDate, string BArrivalCity, string BDepartCity, string FlightNo, int UserID)
        {
            DataTable dt = new DataTable();
            var result = new List<Passenger>();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@PassName", SqlDbType = SqlDbType.NVarChar, Value = PassName });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BDate", SqlDbType = SqlDbType.NVarChar, Value = BDate });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BArrivalCity", SqlDbType = SqlDbType.NVarChar, Value = BArrivalCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@BDepartCity", SqlDbType = SqlDbType.NVarChar, Value = BDepartCity });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@FlightNo", SqlDbType = SqlDbType.NVarChar, Value = FlightNo });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID });
                dt = DbProvider.GetDataTable("BookingFilter", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = new Passenger();
                        row.ID = dt.Rows[i].Field<Int64>("ID");
                        row.PessName = dt.Rows[i].Field<string>("PassengerName");
                        row.BDate = dt.Rows[i].Field<string>("BDate");
                        row.BArrivalCity = dt.Rows[i].Field<string>("BArrivalCity");
                        row.BDepartCity = dt.Rows[i].Field<string>("BDepartCity");
                        row.FlightNo = dt.Rows[i].Field<string>("FlightNo");
                        result.Add(row);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static List<Passenger> BookingWaitingAll()
        {
            DataTable dt = new DataTable();
            List<Passenger> result = new List<Passenger>();
            try
            {
                var lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.NVarChar, Value = "WaitList" });
                lstSqlParameter.Add(new SqlParameter() { ParameterName = "@CRUDMode", SqlDbType = SqlDbType.Int, Value = CRUDEnum.SelectOne });
                dt = DbProvider.GetDataTable("BookingCRUD", CommandType.StoredProcedure, ref lstSqlParameter);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = new Passenger();
                        row.ID = dt.Rows[i].Field<Int64>("ID");
                        row.BookID = dt.Rows[i].Field<string>("BookID");
                        row.FlightID = dt.Rows[i].Field<Int64>("FlightID");
                        row.UserID = dt.Rows[i].Field<Int32>("UserID").ToString();
                        row.PessName = dt.Rows[i].Field<string>("PassengerName");
                        row.BDate = dt.Rows[i].Field<string>("BDate");
                        row.BArrivalCity = dt.Rows[i].Field<string>("BArrivalCity");
                        row.BDepartCity = dt.Rows[i].Field<string>("BDepartCity");
                        row.FlightNo = dt.Rows[i].Field<string>("FlightNo");
                        result.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}