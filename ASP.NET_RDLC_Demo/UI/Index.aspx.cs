using ASP.NET_RDLC_Demo.ReportDataSets;
using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ASP.NET_RDLC_Demo.UI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLoadReport_Click(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/EmployeeDetails.rdlc");
            Employees employees = GetData();
            ReportDataSource dataSource = new ReportDataSource("Employee", employees.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
        }

        private Employees GetData()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = "SELECT * FROM Employee WHERE country=@Country";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Country", txtCountry.Text);

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    using (Employees employees = new Employees())
                    {
                        da.Fill(employees, "Emp");
                        return employees;
                    }
                }
            }
        }
    }
}