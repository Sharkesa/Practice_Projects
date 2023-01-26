using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RezervacijuSistema
{
    class XMLHelper
    {
        internal static DataSet ConvertXMLToDataSet(string filePath)
        {
            if (!File.Exists(filePath))
                return new DataSet();

            DataTable hallTable = new DataTable("Halls");
            DataTable hallGroupTable = new DataTable("HallGroups");
            DataTable SeatTable = new DataTable("SeatsTable");

            DataColumn hallPrimaryKey = new DataColumn("hallid");
            hallPrimaryKey.DataType = typeof(Int32);
            hallPrimaryKey.AutoIncrement = true;

            DataColumn hallGroupPrimaryKey = new DataColumn("hallgroupid");
            hallGroupPrimaryKey.DataType = typeof(Int32);
            hallGroupPrimaryKey.AutoIncrement = true;

            DataColumn seatPrimaryKey = new DataColumn("seatid");
            seatPrimaryKey.DataType = typeof(String);
            seatPrimaryKey.AutoIncrement = true;

            hallTable.Columns.Add(hallPrimaryKey);
            hallTable.Columns.Add("hallname", typeof(String));

            hallGroupTable.Columns.Add(hallGroupPrimaryKey);
            hallGroupTable.Columns.Add("hallid", typeof(Int32));
            hallGroupTable.Columns.Add("hallgroupname", typeof(String));
            hallGroupTable.Columns.Add("az", typeof(Int32));

            SeatTable.Columns.Add("hallid", typeof(Int32));
            SeatTable.Columns.Add("hallgroupid", typeof(Int32));
            SeatTable.Columns.Add(seatPrimaryKey);
            SeatTable.Columns.Add("seatrow", typeof(Int32));
            SeatTable.Columns.Add("seatrowletter", typeof(string));
            SeatTable.Columns.Add("seatnumber", typeof(Int32));
            SeatTable.Columns.Add("seatnumberletter", typeof(string));
            SeatTable.Columns.Add("color", typeof(String));
            SeatTable.Columns.Add("price", typeof(decimal));


            using (XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.ReadToFollowing("Hall"))
                {
                    reader.ReadToFollowing("HallID");
                    int hallID = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("Name");
                    string hallName = reader.ReadElementContentAsString();

                    hallTable.Rows.Add(hallID, hallName);
                }
            }

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.ReadToFollowing("HallGroup"))
                {
                    reader.ReadToFollowing("HallID");
                    int hallID = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("HallGroupID");
                    int hallGroupID = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("Name");
                    string hallGroupName = reader.ReadElementContentAsString();
                    reader.ReadToFollowing("AZ");
                    int AZ = reader.ReadElementContentAsInt();

                    hallGroupTable.Rows.Add(hallGroupID, hallID, hallGroupName, AZ);
                }
            }

            using (XmlReader reader = XmlReader.Create(filePath))
            {
                reader.ReadToFollowing("HallID");
                int hallID = reader.ReadElementContentAsInt();

                while (reader.ReadToFollowing("HallSeat"))
                {

                    reader.ReadToFollowing("HallGroupID");
                    int hallGroupID = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("ShowSeatID");
                    int showSeatID = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("Color");
                    string seatColor = reader.ReadElementContentAsString();
                    reader.ReadToFollowing("Price");
                    decimal seatPrice = reader.ReadElementContentAsDecimal();
                    reader.ReadToFollowing("SeatRow");
                    int seatRow = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("SeatRowLetter");
                    string seatRowLetter = reader.ReadElementContentAsString();
                    reader.ReadToFollowing("SeatNumber");
                    int seatNumber = reader.ReadElementContentAsInt();
                    reader.ReadToFollowing("SeatNumberLetter");
                    string seatNumberLetter = reader.ReadElementContentAsString();

                    SeatTable.Rows.Add(hallID, hallGroupID, showSeatID, seatRow, seatRowLetter, seatNumber, seatNumberLetter, seatColor, seatPrice);
                }
            }

            DataSet HallDetailsTables = new DataSet();

            HallDetailsTables.Tables.Add(hallTable);
            HallDetailsTables.Tables.Add(hallGroupTable);
            HallDetailsTables.Tables.Add(SeatTable);

            return HallDetailsTables;
        }
    }
}
