using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MunicipalityApp.Repositories;

namespace MunicipalityApp
{
    public partial class ProgressGraphForm : Form
    {
        public ProgressGraphForm()
        {
            InitializeComponent();
            LoadProgressChart(); // Load the progress chart when the form is initialized
        }
        //------------------------------End of constructor--------------------------------//

        // Load and configure the progress chart with data
        private void LoadProgressChart()
        {
            // Configure chart area
            var chartArea = new ChartArea("ProgressChartArea");
            progressChart.ChartAreas.Clear(); // Clear any existing chart areas
            progressChart.ChartAreas.Add(chartArea); // Add the new chart area

            // Configure series for the chart
            var progressSeries = new Series("Progress")
            {
                ChartType = SeriesChartType.Bar, // Use a bar chart for progress
                XValueType = ChartValueType.String, // X-axis will represent service types (strings)
                YValueType = ChartValueType.Int32 // Y-axis will represent progress percentage (int)
            };
            progressChart.Series.Clear(); // Clear any existing series
            progressChart.Series.Add(progressSeries); // Add the new series

            // Load data into the chart
            var serviceRequests = ServiceRequestRepository.GetServiceRequests(); // Get all service requests
            foreach (var request in serviceRequests)
            {
                progressSeries.Points.AddXY(request.ServiceType, request.Progress); // Add each request's progress to the chart
            }

            // Set chart titles
            progressChart.Titles.Clear(); // Clear any existing titles
            progressChart.Titles.Add("Service Request Progress"); // Set the chart title
            progressChart.Titles[0].Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold); // Set the title font

            // Configure axes
            chartArea.AxisX.Title = "Service Requests"; // X-axis title
            chartArea.AxisY.Title = "Progress (%)"; // Y-axis title
            chartArea.AxisY.Maximum = 100; // Set Y-axis max value to 100
            chartArea.AxisY.Minimum = 0; // Set Y-axis min value to 0
        }
        //------------------------------End of method--------------------------------//
    }
    //-----------------------------End of class-------------------------------------//
}
//----------------------------------End of File-------------------------------------//
