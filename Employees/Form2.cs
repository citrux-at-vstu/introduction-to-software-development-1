using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employees
{
    public partial class Form2 : Form
    {
        public DataTable dt;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int tot = 0;
            int men = 0;
            int women = 0;
            int pens = 0;
            int menp = 0;
            int womenp = 0;
            double toPens = 0;
            double midAge = 0;

            DateTime now = dateTimePicker1.Value;

            // Статистика по работникам
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (dr["id_person"].ToString() == "") continue;

                    if (dr["gender"].ToString() == "М")
                        men++;
                    else
                        women++;
                    DateTime toPens1;
                    DateTime born = DateTime.Parse(dr["birthdate"].ToString());
                    if (dr["gender"].ToString() == "М")
                    {
                        toPens1 = born.AddYears(60);
                        if (toPens1 < now)
                            menp++;
                    }
                    else
                    {
                        toPens1 = born.AddYears(55);
                        if (toPens1 < now)
                            womenp++;
                    }
                    if (toPens1 < now) pens++;
                    toPens += (toPens1 - now).TotalDays / 365;
                    midAge += (now - born).TotalDays / 365;
                    tot++;
                }
                catch { }
            }
            if (tot > 0)
            {
                toPens = toPens / tot;
                midAge = midAge / tot;
            }

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 60;

            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Всего сотрудников";
            dataGridView1.Rows[0].Cells[1].Value = tot.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[1].Cells[0].Value = "Мужчин";
            dataGridView1.Rows[1].Cells[1].Value = men.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[2].Cells[0].Value = "Женщин";
            dataGridView1.Rows[2].Cells[1].Value = women.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[3].Cells[0].Value = "Пенсионеров";
            dataGridView1.Rows[3].Cells[1].Value = pens.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[4].Cells[0].Value = "Пенсионеров мужчин";
            dataGridView1.Rows[4].Cells[1].Value = menp.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[5].Cells[0].Value = "Пенсионеров женщин";
            dataGridView1.Rows[5].Cells[1].Value = womenp.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[6].Cells[0].Value = "Средний возраст";
            dataGridView1.Rows[6].Cells[1].Value = midAge.ToString();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[7].Cells[0].Value = "До пенсии лет (ср.)";
            dataGridView1.Rows[7].Cells[1].Value = toPens.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int tot = 0;
            int men = 0;
            int women = 0;
            int pens = 0;
            int menp = 0;
            int womenp = 0;
            double toPens = 0;
            double midAge = 0;

            DateTime now = dateTimePicker1.Value;

            // Статистика по работникам
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (dr["id_person"].ToString() == "") continue;

                    if (dr["gender"].ToString() == "М")
                        men++;
                    else
                        women++;
                    DateTime toPens1;
                    DateTime born = DateTime.Parse(dr["birthdate"].ToString());
                    if (dr["gender"].ToString() == "М")
                    {
                        toPens1 = born.AddYears(60);
                        if (toPens1 < now)
                            menp++;
                    }
                    else
                    {
                        toPens1 = born.AddYears(55);
                        if (toPens1 < now)
                            womenp++;
                    }
                    if (toPens1 < now) pens++;
                    toPens += (toPens1 - now).TotalDays / 365;
                    midAge += (now - born).TotalDays / 365;
                    tot++;
                }
                catch { }
            }
            if (tot > 0)
            {
                toPens = toPens / tot;
                midAge = midAge / tot;
            }

            dataGridView1.Rows[0].Cells[0].Value = "Всего сотрудников";
            dataGridView1.Rows[0].Cells[1].Value = tot.ToString();
            dataGridView1.Rows[1].Cells[0].Value = "Мужчин";
            dataGridView1.Rows[1].Cells[1].Value = men.ToString();
            dataGridView1.Rows[2].Cells[0].Value = "Женщин";
            dataGridView1.Rows[2].Cells[1].Value = women.ToString();
            dataGridView1.Rows[3].Cells[0].Value = "Пенсионеров";
            dataGridView1.Rows[3].Cells[1].Value = pens.ToString();
            dataGridView1.Rows[4].Cells[0].Value = "Пенсионеров мужчин";
            dataGridView1.Rows[4].Cells[1].Value = menp.ToString();
            dataGridView1.Rows[5].Cells[0].Value = "Пенсионеров женщин";
            dataGridView1.Rows[5].Cells[1].Value = menp.ToString();
            dataGridView1.Rows[6].Cells[0].Value = "Средний возраст";
            dataGridView1.Rows[6].Cells[1].Value = midAge.ToString();
            dataGridView1.Rows[7].Cells[0].Value = "До пенсии лет (ср.)";
            dataGridView1.Rows[7].Cells[1].Value = toPens.ToString();

        }

    }
}
