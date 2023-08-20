﻿using BusinessLogicLayer;
using Microsoft.Reporting.WinForms;
using PresentationLayer.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {

            DataSet ds = HoaDonBL.GetInstance.InHoaDon(ucBanSanPham.SOHD_Report);
            ReportDataSource dataSource = new ReportDataSource("DataSet_Report", ds.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = HoaDonBL.GetInstance.InHoaDon(ucBanSanPham.SOHD_Report);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource dataSource = new ReportDataSource("DataSet_Report", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.");
            }

        }
    }
}
