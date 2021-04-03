
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace BTMS1
{
    public partial class main : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1LF5S1M;Initial Catalog=BTMS1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();


        public main()
        {
            InitializeComponent();
            displaystation();
            displayemployee();
            displaybusdetails();
            displayroutecreator();
            displayticket();


        }

        public void displaystation()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("select * from stations", con);
            int i = 0;
            cmd = new SqlCommand("select * from stations", con);

            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            addstationdgv.Rows.Clear();
            while (dr.Read())
            {
                i = i + 1;
                addstationdgv.Rows.Add(i.ToString(), dr["stationcode"].ToString(), dr["stationname"].ToString(), dr["stationaddress"].ToString(), dr["routeid"].ToString());
            }
            dr.Close();
            con.Close();


        }

        public void displayemployee()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTB", con);
            int i = 0;
            cmd = new SqlCommand("select * from EmployeeTB", con);

            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            addemployeedgv.Rows.Clear();
            while (dr.Read())
            {
                i = i + 1;
                addemployeedgv.Rows.Add(i.ToString(), dr["employeeid"].ToString(), dr["employeename"].ToString(), dr["role"].ToString(), dr["employeeaddress"].ToString(), dr["employeephoneno"].ToString(), dr["fathersname"].ToString(), dr["mothersname"].ToString(), dr["citizenshipno"].ToString());
            }
            dr.Close();
            con.Close();


        }


        public void displaybusdetails()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("select * from busdetails", con);
            int i = 0;
            cmd = new SqlCommand("select * from busdetails", con);

            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            busdetailsdgv.Rows.Clear();
            while (dr.Read())
            {
                i = i + 1;
                busdetailsdgv.Rows.Add(i.ToString(), dr["busno"].ToString(), dr["busname"].ToString(), dr["chooseroute"].ToString(), dr["bustype"].ToString(), dr["noofseats"].ToString(), dr["Model"].ToString(), dr["Driver"].ToString(), dr["conductor"].ToString());
            }
            dr.Close();
            con.Close();


        }





         public void displayroutecreator()
         {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from busoute", con);
             int i = 0;
             cmd = new SqlCommand("select * from busoute", con);

             DataTable dt = new DataTable();
             SqlDataReader dr = cmd.ExecuteReader();
            brcdgv.Rows.Clear();
             while (dr.Read())
             {
                 i = i + 1;
                brcdgv.Rows.Add(i.ToString(), dr["routeid"].ToString(), dr["choosestation"].ToString(), dr["distancefromsource"].ToString(), dr["arrivaltime"].ToString(), dr["departuretime"].ToString());
             }
             dr.Close();
             con.Close();


         }
        



        public void displayticket()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("select * from ticketcreator", con);
            int i = 0;
            cmd = new SqlCommand("select * from ticketcreator", con);

            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            searchticketdgv.Rows.Clear();
            while (dr.Read())
            {
               i = i + 1;
               searchticketdgv.Rows.Add(i.ToString(), dr["ticketno"].ToString(), dr["busno"].ToString(), dr["sourcestation"].ToString(), dr["destinationstation"].ToString(), dr["distancefromsource"].ToString(), dr["totalfarecost"].ToString(), dr["issueddate"].ToString(), dr["departuredate"].ToString(), dr["departuretime"].ToString(), dr["arrivaltime"].ToString(), dr["name"].ToString(), dr["age"].ToString(), dr["gender"].ToString(), dr["address"].ToString(), dr["phoneno"].ToString());
            }
            dr.Close();
            con.Close();


        }


        private void txtBus_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_Load(object sender, EventArgs e)
        {
         
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        private void searchticketbtn_Click(object sender, EventArgs e)
        {

        }

        private bool IsValid()
        {
            if (passengernametxtbox.Text == string.Empty)
            {
                MessageBox.Show("passenger name cannot be empty.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

       

        private void addstationbtn_Click(object sender, EventArgs e)
        {


            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from stations where stationcode='" + stationcodetxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into stations values('" + stationcodetxtbox.Text + "','" + stationnametxtbox.Text + "','" + stationaddresstxtbox.Text + "',  '" + routeidtxtbox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    displaystation();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update stations set stationcode='" + stationcodetxtbox.Text + "',stationname='" + stationnametxtbox.Text + "',stationaddress='" + stationaddresstxtbox.Text + "', routeid='" + routeidtxtbox.Text + "' where stationcode='" + stationcodetxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Sucessfully");
            displaystation();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from stations where stationcode='" + stationcodetxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Sucessfully");
            displaystation();
        }


        private void addstationdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (addstationdgv.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    refresh();
                }
                else
                {

                    stationcodetxtbox.Text = addstationdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    stationnametxtbox.Text = addstationdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    stationaddresstxtbox.Text = addstationdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    routeidtxtbox.Text = addstationdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }
        }


        public void refresh()
        {
            stationcodetxtbox.Text = "";
            stationnametxtbox.Text = "";
            stationaddresstxtbox.Text = "";
            routeidtxtbox.Text = "";
        }



        private void addemployeebtn_Click(object sender, EventArgs e)
        {


            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from EmployeeTB where employeeid='" + employeeidtxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into EmployeeTB values('" + employeeidtxtbox.Text + "','" + employeenametxtbox.Text + "','" + rolecomboBox.Text + "',  '" + employeeaddresstxtbox.Text + "','" + employeephonenotxtbox.Text + "',  '" + employeefatherstxtbox.Text + "',  '" + employeemothersnametxtbox.Text + "',  '" + cno.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    displayemployee();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update EmployeeTB set employeeid='" + employeeidtxtbox.Text + "',employeename='" + employeenametxtbox.Text + "',role='" + rolecomboBox.Text + "', employeeaddress='" + employeeaddresstxtbox.Text + "',employeephoneno='" + employeephonenotxtbox.Text + "',fathersname='" + employeefatherstxtbox.Text + "', mothersname='" + employeemothersnametxtbox.Text + "',citizenshipno='" + cno.Text + "' where employeeid='" + employeeidtxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Sucessfully");
            displayemployee();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from EmployeeTB where employeeid='" + employeeidtxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Sucessfully");
            displayemployee();
        }





        public void refreshemployee()
        {
            employeeidtxtbox.Text = "";
            employeenametxtbox.Text = "";
            rolecomboBox.Text = "";
            employeeaddresstxtbox.Text = "";
            employeephonenotxtbox.Text = "";
            employeefatherstxtbox.Text = "";
            employeemothersnametxtbox.Text = "";
            cno.Text = "";
        }

        private void addemployeedgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (addemployeedgv.Rows[e.RowIndex].Cells[1].Value == null || addemployeedgv.CurrentRow.Index == -1)
                {
                    refreshemployee();
                }
                else
                {

                    employeeidtxtbox.Text = addemployeedgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    employeenametxtbox.Text = addemployeedgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    rolecomboBox.Text = addemployeedgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    employeeaddresstxtbox.Text = addemployeedgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    employeephonenotxtbox.Text = addemployeedgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                    employeefatherstxtbox.Text = addemployeedgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                    employeemothersnametxtbox.Text = addemployeedgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                    cno.Text = addemployeedgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }
        }

        /*

        private void addbd_Click(object sender, EventArgs e)
        {

            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from busdetails where busno='" + busnotxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into busdetails values('" + busnotxtbox.Text + "','" + busnametxtbox.Text + "','" + chooseroutecomboBox.Text + "',  '" + bustypecomboBox.Text + "','" + noofseatstxtbox.Text + "',  '" + busmodeltxtbox.Text + "',  '" + drivercomboBox.Text + "',  '" + conductorcomboBox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    //displaybusdetails();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }
        }

        private void updatebd_Click(object sender, EventArgs e)
        {

            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update busdetails set busno='" + busnotxtbox.Text + "',busname='" + busnametxtbox.Text + "', chooseroute='" + chooseroutecomboBox.Text + "', bustype='" + bustypecomboBox.Text + "', noofseats='" + noofseatstxtbox.Text + "',Model='" + busmodeltxtbox.Text + "', driver='" + drivercomboBox.Text + "',conductor='" + conductorcomboBox.Text + "' where busno='" + busnotxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Sucessfully");
            //displaybusdetails();

        }

        private void deletebd_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from busdetails where busno='" + busnotxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Sucessfully");
           // displaybusdetails();
        }


        public void refreshbusdetails()
        {
            busnotxtbox.Text = "";
            busnametxtbox.Text = "";
            chooseroutecomboBox.Text = "";
            bustypecomboBox.Text = "";
            noofseatstxtbox.Text = "";
            busmodeltxtbox.Text = "";
            drivercomboBox.Text = "";
            conductorcomboBox.Text = "";
        }

        private void busdetailsdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (busdetailsdgv.Rows[e.RowIndex].Cells[1].Value == null || busdetailsdgv.CurrentRow.Index == -1)
                {
                    refreshbusdetails();
                }
                else
                {

                    busnotxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    busnametxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    chooseroutecomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    bustypecomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    noofseatstxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                    busmodeltxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                    drivercomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                    conductorcomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }
        }





        private void addroutebtn_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from Bus Route where busno='" + busnotxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Bus Route values('" + enterrouteidtxtbox.Text + "','" + choosestationcomboBox.Text + "','" + distancefromsourcetxtbox.Text + "',  '" + arrivaltimetxtbox.Text + "','" + departuretimetxtbox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    displayroutecreator();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }
        }

        public void refreshroutecreator()
        {
            enterrouteidtxtbox.Text = "";
            choosestationcomboBox.Text = "";
            distancefromsourcetxtbox.Text = "";
            arrivaltimetxtbox.Text = "";
            departuretimetxtbox.Text = "";
           
        }

        private void brcdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (brcdgv.Rows[e.RowIndex].Cells[1].Value == null || brcdgv.CurrentRow.Index == -1)
                {
                    refreshroutecreator();
                }
                else
                {

                    enterrouteidtxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    choosestationcomboBox.Text = brcdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    distancefromsourcetxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    arrivaltimetxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    departuretimetxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                   
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }
        }
        */


       




        public void refreshticket()
        {
            ticketnotxtbox.Text = "";
            busnocomboBox.Text = "";
            sourcestationcomboBox.Text = "";
            destinationstationcombobox.Text = "";
            distancefromsourcetxtbox.Text = "";
            totalfarecosttxtbox.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker4.Text = "";
            dateTimePicker3.Text = "";
            passengernametxtbox.Text = "";
            passengeragetxtbox.Text = "";
            passengergendercomboBox.Text = "";
            passengeraddresstxtbox.Text = "";
            passengerphonenumber.Text = "";

        }

       

        private void printticketbtn_Click_2(object sender, EventArgs e)
        {

            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from ticketcreator where ticketno='" + ticketnotxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into ticketcreator values('" + ticketnotxtbox.Text + "','" + busnocomboBox.Text + "','" + sourcestationcomboBox.Text + "','" + destinationstationcombobox.Text + "','" + distancefromsourcetxtbox.Text + "','" + totalfarecosttxtbox.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker4.Text + "','" + dateTimePicker3.Text + "','" + passengernametxtbox.Text + "','" + passengeragetxtbox.Text + "','" + passengergendercomboBox.Text + "','" + passengeraddresstxtbox.Text + "','" + passengerphonenumber.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    displayticket();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }

        }




        private void searchticketdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (searchticketdgv.Rows[e.RowIndex].Cells[1].Value == null || searchticketdgv.CurrentRow.Index == -1)
                {
                    refreshticket();
                }
                else
                {
                    ticketnotxtbox.Text = searchticketdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    busnocomboBox.Text = searchticketdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sourcestationcomboBox.Text = searchticketdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    destinationstationcombobox.Text = searchticketdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    distancefromsourcetxtbox.Text = searchticketdgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                    totalfarecosttxtbox.Text = searchticketdgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                    dateTimePicker1.Text = searchticketdgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                    dateTimePicker2.Text = searchticketdgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                    dateTimePicker4.Text = searchticketdgv.Rows[e.RowIndex].Cells[9].Value.ToString();
                    dateTimePicker3.Text = searchticketdgv.Rows[e.RowIndex].Cells[10].Value.ToString();
                    passengernametxtbox.Text = searchticketdgv.Rows[e.RowIndex].Cells[11].Value.ToString();
                    passengeragetxtbox.Text = searchticketdgv.Rows[e.RowIndex].Cells[12].Value.ToString();
                    passengergendercomboBox.Text = searchticketdgv.Rows[e.RowIndex].Cells[13].Value.ToString();
                    passengeraddresstxtbox.Text = searchticketdgv.Rows[e.RowIndex].Cells[14].Value.ToString();
                    passengerphonenumber.Text = searchticketdgv.Rows[e.RowIndex].Cells[15].Value.ToString();
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }
        }


        public void refreshbusdetails()
        {
            busnotxtbox.Text = "";
            busnametxtbox.Text = "";
            chooseroutecomboBox.Text = "";
            bustypecomboBox.Text = "";
            noofseatstxtbox.Text = "";
            busmodeltxtbox.Text = "";
            drivercomboBox.Text = "";
            conductorcomboBox.Text = "";
        }

        private void addbd_Click(object sender, EventArgs e)
        {
           

            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from busdetails where busno='" + busnotxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into busdetails values('" + busnotxtbox.Text + "','" + busnametxtbox.Text + "','" + chooseroutecomboBox.Text + "',  '" + bustypecomboBox.Text + "','" + noofseatstxtbox.Text + "',  '" + busmodeltxtbox.Text + "',  '" + drivercomboBox.Text + "',  '" + conductorcomboBox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    displaybusdetails();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }
            displaybusdetails();
        }

       

       

        private void updatebd_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update busdetails set busno='" + busnotxtbox.Text + "',busname='" + busnametxtbox.Text + "', chooseroute='" + chooseroutecomboBox.Text + "', bustype='" + bustypecomboBox.Text + "', noofseats='" + noofseatstxtbox.Text + "',Model='" + busmodeltxtbox.Text + "', Driver='" + drivercomboBox.Text + "',conductor='" + conductorcomboBox.Text + "' where busno='" + busnotxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Sucessfully");
            displaybusdetails();
        }

        private void deletebd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from busdetails where busno='" + busnotxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Sucessfully");
            displaybusdetails();
        }
        

        private void Busdetailsdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (busdetailsdgv.Rows[e.RowIndex].Cells[1].Value == null || busdetailsdgv.CurrentRow.Index == -1)
                {
                    refreshbusdetails();

                }
                else
                {
                    busnotxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    busnametxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    chooseroutecomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    bustypecomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    noofseatstxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                    busmodeltxtbox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                    drivercomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[7].Value.ToString();
                    conductorcomboBox.Text = busdetailsdgv.Rows[e.RowIndex].Cells[8].Value.ToString();
                    displaybusdetails();
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }

        }

        public void refreshbusroutecreator()
        {
            enterrouteidtxtbox.Text = "";
            choosestationcomboBox.Text = "";
            distancefromsourcetxtbox.Text = "";
            arrivaltimetxtbox.Text = "";
            departuretimetxtbox.Text = "";

        }

        private void addroutebtn_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from busoute where routeid='" + enterrouteidtxtbox.Text + "'", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Data Already Exists");

                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into busoute values('" + enterrouteidtxtbox.Text + "','" + choosestationcomboBox.Text + "','" + distancefromsourcetxtbox.Text + "',  '" + arrivaltimetxtbox.Text + "','" + departuretimetxtbox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Sucessfully");
                    displayroutecreator();


                }

            }
            catch
            {
                MessageBox.Show("Error in Inserting data");
            }

        }

        private void updateroutebtn_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update busoute set routeid='" + routeidtxtbox.Text + "',choosestation='" + choosestationcomboBox.Text + "',distancefromsource='" + distancefromsourcetxtbox.Text + "', arrivaltime='" + arrivaltimetxtbox.Text + "',departuretime='" + departuretimetxtbox.Text + "' where routeid='" + routeidtxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record updated Sucessfully");
            displayroutecreator();
        }

        private void deleteroutebtn_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " delete from busoute where routeid='" + routeidtxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Sucessfully");
            displayroutecreator();
        }

        

        private void brcdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (brcdgv.Rows[e.RowIndex].Cells[1].Value == null || brcdgv.CurrentRow.Index == -1)
                {
                    refreshbusroutecreator();
                }
                else
                {

                    enterrouteidtxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    choosestationcomboBox.Text = brcdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    distancefromsourcetxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                    arrivaltimetxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                    departuretimetxtbox.Text = brcdgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                    displayroutecreator();
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Enter proper record");
            }
        }
    }
} 
