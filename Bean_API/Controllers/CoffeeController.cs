using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bean_API.Modules;
using MySql.Data.MySqlClient;

namespace Bean_API.Controllers
{
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        // Form1_Chart_all_Select // 차트그래프 전체 원두 셀렉
        [Route("Form1_Chart_all_Select")]
        [HttpGet]
        public ActionResult<ArrayList> Form1_Chart_all_Select()
        {
            Console.WriteLine("select : Form1_Chart_all_Select");

            DataBase db = new DataBase();
            //string sql = "select book_number, availability, title, author, publisher from book_info;";
            MySqlDataReader sdr = db.P_Reader("Form1_Chart_all_Select");
            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }


        // Form1_Chart_all_Select // 차트그래프 전체 원두 셀렉
        [Route("Form1_Chart_Roasting_select")]
        [HttpGet]
        public ActionResult<ArrayList> Form1_Chart_Roasting_select()
        {
            Console.WriteLine("select : Form1_Chart_Roasting_select");

            DataBase db = new DataBase();
            //string sql = "select book_number, availability, title, author, publisher from book_info;";
            MySqlDataReader sdr = db.P_Reader("Form1_Chart_Roasting_select");
            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }
        
        [Route("Form1_Chart_Product_select")]
        [HttpGet]
        public ActionResult<ArrayList> Form1_Chart_Product_select()
        {
            Console.WriteLine("select : Form1_Chart_Product_select");

            DataBase db = new DataBase();
            //string sql = "select book_number, availability, title, author, publisher from book_info;";
            MySqlDataReader sdr = db.P_Reader("Form1_Chart_Product_select");
            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        [Route("Form1_Chart_Bean_select")]
        [HttpGet]
        public ActionResult<ArrayList> Form1_Chart_Bean_select()
        {
            Console.WriteLine("select : Form1_Chart_Bean_select");

            DataBase db = new DataBase();
            //string sql = "select book_number, availability, title, author, publisher from book_info;";
            MySqlDataReader sdr = db.P_Reader("Form1_Chart_Bean_select");
            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }
    }
}
