using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing.Drawing2D;

namespace CRUDFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public void ArredondaCantosdoForm()
        {

            GraphicsPath PastaGrafica = new GraphicsPath();
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, this.Size.Width, this.Size.Height));

                  
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, 10, 10));
            PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

           
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, 1, 12, 13));
            PastaGrafica.AddPie(this.Width - 24, 1, 24, 26, 270, 90);

           
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, this.Height - 10, 10, 10));
            PastaGrafica.AddPie(1, this.Height - 20, 20, 20, 90, 90);

           
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, this.Height - 13, 13, 13));
            PastaGrafica.AddPie(this.Width - 24, this.Height - 26, 24, 26, 0, 90);

            PastaGrafica.SetMarkers();
            this.Region = new Region(PastaGrafica);
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadData();
            ArredondaCantosdoForm();
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=BDpets.db;Version=3;New=False;Compress=true;");
        }

        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from BDpets";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }


        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
           
            string txtQuery = "insert into BDpets(ID,Nome,Celular,Email,Endereco,RG,CPF,NomePet,Raca,Idade)Values('" + txt_ID.Text + "','" + txt_NomeCli.Text + "','" + txt_Celular.Text + "','" + txt_Email.Text + "','" + txt_Endereco.Text + "','" + txt_RG.Text + "','" + txt_CPF.Text + "','" + txt_NomePet.Text + "','" + txt_Raca.Text + "','" + txt_Idade.Text + "')";
            ExecuteQuery(txtQuery);
            LoadData();
            txt_ID.Text = string.Empty;
            txt_NomeCli.Text = string.Empty;
            txt_Celular.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Endereco.Text = string.Empty;
            txt_RG.Text = string.Empty;
            txt_CPF.Text = string.Empty;
            txt_NomePet.Text = string.Empty;
            txt_Raca.Text = string.Empty;
            txt_Idade.Text = string.Empty;
            
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            String txtQuery = "delete from BDpets where ID= '" + txt_ID.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();
            txt_ID.Text = string.Empty;
            txt_NomeCli.Text = string.Empty;
            txt_Celular.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Endereco.Text = string.Empty;
            txt_RG.Text = string.Empty;
            txt_CPF.Text = string.Empty;
            txt_NomePet.Text = string.Empty;
            txt_Raca.Text = string.Empty;
            txt_Idade.Text = string.Empty;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            
            string txtQuery = "update BDpets set (Nome,Celular,Email,Endereco,RG,CPF,NomePet,Raca,Idade)= ('" + txt_NomeCli.Text + "','" + txt_Celular.Text + "','" + txt_Email.Text + "','" + txt_Endereco.Text + "','" + txt_RG.Text + "','" + txt_CPF.Text + "','" + txt_NomePet.Text + "','" + txt_Raca.Text + "','" + txt_Idade.Text + "') where ID= '" + txt_ID.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();
            txt_ID.Text = string.Empty;
            txt_NomeCli.Text = string.Empty;
            txt_Celular.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Endereco.Text = string.Empty;
            txt_RG.Text = string.Empty;
            txt_CPF.Text = string.Empty;
            txt_NomePet.Text = string.Empty;
            txt_Raca.Text = string.Empty;
            txt_Idade.Text = string.Empty;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGrindView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            txt_ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_NomeCli.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_Celular.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_Email.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_Endereco.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txt_RG.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txt_CPF.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txt_NomePet.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txt_Raca.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txt_Idade.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();


        }
        

        Point ArrastarCursor;
        Point ArrastarForm;
        bool Arrastando;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Arrastando = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Arrastando = true;
            ArrastarCursor = Cursor.Position;
            ArrastarForm = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Arrastando == true)
            {
                Point diferenca = Point.Subtract(Cursor.Position, new Size(ArrastarCursor));
                this.Location = Point.Add(ArrastarForm, new Size(diferenca));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Arrastando = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Arrastando = true;
            ArrastarCursor = Cursor.Position;
            ArrastarForm = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Arrastando == true)
            {
                Point diferenca = Point.Subtract(Cursor.Position, new Size(ArrastarCursor));
                this.Location = Point.Add(ArrastarForm, new Size(diferenca));
            }
        }

        private void txt_Nome_MouseUp(object sender, MouseEventArgs e)
        {
            Arrastando = false;
        }

        private void txt_Nome_MouseDown(object sender, MouseEventArgs e)
        {
            Arrastando = true;
            ArrastarCursor = Cursor.Position;
            ArrastarForm = this.Location;
        }

        private void txt_Nome_MouseMove(object sender, MouseEventArgs e)
        {
            if (Arrastando == true)
            {
                Point diferenca = Point.Subtract(Cursor.Position, new Size(ArrastarCursor));
                this.Location = Point.Add(ArrastarForm, new Size(diferenca));
            }
        }

        //Bagulhinhos que eu cliquei pra abrir o codigo sem querer. :/  

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }
        private void txt_Idade_OnValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}