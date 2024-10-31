using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etat_civile
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        ADO d = new ADO();

        void Statistique()
        {
            d.cmd.CommandText = "select count(*) from Homme";
            d.cmd.Connection = d.cnx;
            lblHomme.Text = ((int)d.cmd.ExecuteScalar()).ToString();
            d.cmd.CommandText = "select count(*) from Femme";
            d.cmd.Connection = d.cnx;
            lblFemme.Text = ((int)d.cmd.ExecuteScalar()).ToString();
            d.cmd.CommandText = "select count(*) from Mariage";
            d.cmd.Connection = d.cnx;
            lblMariage.Text = ((int)d.cmd.ExecuteScalar()).ToString();
            d.cmd.CommandText = "select count(*) from Divorce";
            d.cmd.Connection = d.cnx;
            lblDivorce.Text = ((int)d.cmd.ExecuteScalar()).ToString();
            d.cmd.CommandText = "select count(*) from Deces";
            d.cmd.Connection = d.cnx;
            lblRIP.Text = ((int)d.cmd.ExecuteScalar()).ToString();
            d.cmd.CommandText = "select count(*) from Officiers";
            d.cmd.Connection = d.cnx;
            lblOfficier.Text = ((int)d.cmd.ExecuteScalar()).ToString();
            int total = 0;
            d.cmd.CommandText = "select count(*) from Homme";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from Femme";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from DeclarationNaissance";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from Mariage";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from Divorce";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from Deces";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from Declarant";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            d.cmd.CommandText = "select count(*) from Officiers";
            d.cmd.Connection = d.cnx;
            total += (int)d.cmd.ExecuteScalar();
            lblTotalEnregistrement.Text = total.ToString();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            d.Connecter();
            Statistique();
            d.cmd.CommandText = "select Value from Statistique where Type = 'Mariage' order by Mois ";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            DataTable dtMariage = new DataTable();
            dtMariage.Load(d.dr);
            d.dr.Close();
            DataTable dtDivorce = new DataTable();
            d.cmd.CommandText = "select Value from Statistique where Type = 'Divorce' order by Mois ";
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            dtDivorce.Load(d.dr);
            d.dr.Close();
            cartesianChart1.Series = new SeriesCollection
            {

                new LineSeries
                {

                    Values = new ChartValues<ObservablePoint>
                    {
            
                        new ObservablePoint(0,int.Parse(dtMariage.Rows[0][0].ToString())),
                        new ObservablePoint(1,int.Parse(dtMariage.Rows[4][0].ToString())),
                        new ObservablePoint(2,int.Parse(dtMariage.Rows[5][0].ToString())),
                        new ObservablePoint(3,int.Parse(dtMariage.Rows[6][0].ToString())),
                        new ObservablePoint(4,int.Parse(dtMariage.Rows[7][0].ToString())),
                        new ObservablePoint(5,int.Parse(dtMariage.Rows[8][0].ToString())),
                        new ObservablePoint(6,int.Parse(dtMariage.Rows[9][0].ToString())),
                        new ObservablePoint(7,int.Parse(dtMariage.Rows[10][0].ToString())),
                        new ObservablePoint(8,int.Parse(dtMariage.Rows[11][0].ToString())),
                        new ObservablePoint(9,int.Parse(dtMariage.Rows[1][0].ToString())),
                        new ObservablePoint(10,int.Parse(dtMariage.Rows[2][0].ToString())),
                        new ObservablePoint(11,int.Parse(dtMariage.Rows[3][0].ToString())),
                    },
                    Title = "Mariage",
                    PointForeground = System.Windows.Media.Brushes.Orchid,
                    Stroke = System.Windows.Media.Brushes.White,
                    PointGeometrySize = 13
                },
                new LineSeries
                {
                    
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,int.Parse(dtDivorce.Rows[0][0].ToString())),
                        new ObservablePoint(1,int.Parse(dtDivorce.Rows[4][0].ToString())),
                        new ObservablePoint(2,int.Parse(dtDivorce.Rows[5][0].ToString())),
                        new ObservablePoint(3,int.Parse(dtDivorce.Rows[6][0].ToString())),
                        new ObservablePoint(4,int.Parse(dtDivorce.Rows[7][0].ToString())),
                        new ObservablePoint(5,int.Parse(dtDivorce.Rows[8][0].ToString())),
                        new ObservablePoint(6,int.Parse(dtDivorce.Rows[9][0].ToString())),
                        new ObservablePoint(7,int.Parse(dtDivorce.Rows[10][0].ToString())),
                        new ObservablePoint(8,int.Parse(dtDivorce.Rows[11][0].ToString())),
                        new ObservablePoint(9,int.Parse(dtDivorce.Rows[1][0].ToString())),
                        new ObservablePoint(10,int.Parse(dtDivorce.Rows[2][0].ToString())),
                        new ObservablePoint(11,int.Parse(dtDivorce.Rows[3][0].ToString())),
                    },
                    Title = "Divorce",
                    PointGeometrySize = 13,
                    PointForeground = System.Windows.Media.Brushes.DarkCyan,
                    Stroke = System.Windows.Media.Brushes.Gray,
                }
                
            };
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Mois",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Le nombre de femmes divorcées et le nombre de femmes mariées",
                LabelFormatter = value => value.ToString("")
            });
            //guna2CirclePictureBox3.Image = global::Etat_civile.Properties.Resources.image_processing20191028_31344_11uhdiz;
            //guna2PictureBox1.Image = global::Etat_civile.Properties.Resources.ring;
            //PieCHart();
        }
        //void PieCHart()
        //{
        //    Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
        //    SeriesCollection seriesCollection = new SeriesCollection();
        //    //double[] Values = { 0.56, 0.66, 0.01, 0.43, 0.58 };
        //    for (int i = 0; i < 2; i++)
        //    {
        //        PieSeries pieSeries = new PieSeries
        //        {
        //            Title = "Femme",
        //            Values = new ChartValues<double> { 45 },
        //            DataLabels = true,
        //            LabelPoint = labelPoint
        //        };
        //        seriesCollection.Add(pieSeries);
        //    }
        //}
    }
}
