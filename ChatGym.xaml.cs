using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GYMorginalcopy
{
    /// <summary>
    /// Interaction logic for ChatGym.xaml
    /// </summary>
    public partial class ChatGym : Window
    {
        public ChatGym()
        {
            InitializeComponent();
            piechart();
            doughunt();
        }

        public void piechart()
        {
            Pointlable = chartPoint => string.Format("{0} ({1:p})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }
        public void doughunt()
        {
            seriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title="Chrome",
                    Values=new ChartValues<ObservableValue>{new ObservableValue(8)},
                    DataLabels=true,
                },
                 new PieSeries
                {
                    Title="Chrome",
                    Values=new ChartValues<ObservableValue>{new ObservableValue(8)},
                    DataLabels=true,
                },
                  new PieSeries
                {
                    Title="Chrome",
                    Values=new ChartValues<ObservableValue>{new ObservableValue(8)},
                    DataLabels=true,
                },
                   new PieSeries
                {
                    Title="Chrome",
                    Values=new ChartValues<ObservableValue>{new ObservableValue(8)},
                    DataLabels=true,
                },
            };
            DataContext = this;
        }

        public Func<ChartPoint, string> Pointlable { get; set; }
        public SeriesCollection seriesCollection { get; set; }
        private void PieChart_Loaded(object sender, LiveCharts.ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartPoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
