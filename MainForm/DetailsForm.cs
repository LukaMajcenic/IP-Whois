using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using FsCheck;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MainForm
{
    public partial class DetailsForm : Form
    {
        private IP_Repostirory _IP_Repostirory = new IP_Repostirory();
        private IP ipObject = new IP();
        private MainForm mainformObject = new MainForm();

        public DetailsForm(IP i, MainForm mf)
        {
            InitializeComponent();
            ipObject = i;
            mainformObject = mf;
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            this.Text = ipObject.ip + " Details";

            if (ipObject.country_flag.Length == 30)
                pictureBoxFlag.Load(ipObject.country_flag);
            else
                pictureBoxFlag.Load("https://i.dlpng.com/static/png/6722565_preview.png");

            InitializeInfo();
            InitializeMap();
        }

        private void InitializeMap()
        {
            WorldMap.Overlays.Clear();

            WorldMap.MapProvider = GMapProviders.GoogleMap;

            //General configuration of map
            WorldMap.DragButton = MouseButtons.Left;
            WorldMap.ShowCenter = false;

            //Overlay which is then put on top of map
            GMapOverlay markersOverlay = new GMapOverlay();

            //Making of secondary points and markers
            foreach (var v in _IP_Repostirory.GetIPMainForm())
            {
                if (v.ip != ipObject.ip)
                {
                    IP SecondaryObject = _IP_Repostirory.GetIPDetails(v.ip);

                    if (SecondaryObject.latitude.ToString() != "NO DATA")
                    {
                        PointLatLng pointSecondary = new PointLatLng(Convert.ToDouble(SecondaryObject.latitude), Convert.ToDouble(SecondaryObject.longitude));
                        GMapMarker markerSecondary = new GMarkerGoogle(pointSecondary, Properties.Resources.markerWhite);

                        //Adding marker to overlay
                        markersOverlay.Markers.Add(markerSecondary);
                    }
                }
            }

            //Making of main point and marker
            PointLatLng point = new PointLatLng(Convert.ToDouble(ipObject.latitude), Convert.ToDouble(ipObject.longitude));
            WorldMap.Position = point;
            GMapMarker marker = new GMarkerGoogle(point, Properties.Resources.markerBlue);

            //Adding marker to overlay
            markersOverlay.Markers.Add(marker);

            //Adding overlay to map
            WorldMap.Overlays.Add(markersOverlay);
        }

        public void InitializeInfo()
        {
            switch (ipObject.type)
            {
                case "IPv4":
                    textBoxIPv6.BackColor = Color.FromArgb(0, 120, 215);
                    textBoxIPv6.ForeColor = Color.FromArgb(0, 102, 204);

                    textBoxIPv6next.BackColor = Color.FromArgb(0, 120, 215);
                    textBoxIPv6next.ForeColor = Color.FromArgb(0, 102, 204);
                    break;
                case "IPv6":
                    textBoxIPv4.BackColor = Color.FromArgb(0, 120, 215);
                    textBoxIPv4.ForeColor = Color.FromArgb(0, 102, 204);

                    textBoxIPv4next.BackColor = Color.FromArgb(0, 120, 215);
                    textBoxIPv4next.ForeColor = Color.FromArgb(0, 102, 204);
                    break;
                default:
                    break;
            }

            textBoxIP.Text = ipObject.ip;
            textBoxContinent2.Text = ipObject.continent;
            textBoxCountry2.Text = ipObject.country;
            textBoxRegion2.Text = ipObject.region;
            textBoxCity2.Text = ipObject.city;
            textBoxLatitude2.Text = Convert.ToString(ipObject.latitude);
            textBoxLongitude2.Text = Convert.ToString(ipObject.longitude);
            textBoxAsn2.Text = ipObject.asn;
            textBoxOrg2.Text = ipObject.org;
            textBoxIsp2.Text = ipObject.isp;
            textBoxCurrency2.Text = ipObject.currency;
            textBoxIso2.Text = ipObject.country_code;

            textBoxIPnext.Text = ipObject.ip;
            textBoxCountryCapital2.Text = ipObject.country_capital;
            textBoxCountryPhone2.Text = ipObject.country_phone;
            textBoxCountryNeighbours2.Text = ipObject.country_neighbours;
            textBoxTimezone2.Text = ipObject.timezone;
            textBoxTimezoneName2.Text = ipObject.timezone_name;
            textBoxGMT2.Text = ipObject.timezone_gmt;
            textBoxGMToff2.Text = ipObject.timezone_gmtOffset;
            textBoxDSToff2.Text = ipObject.timezone_dstOffset;
            textBoxPlural2.Text = ipObject.currency_plural;
            textBoxRates2.Text = Convert.ToString(ipObject.currency_rates);
            textBoxContinentCode2.Text = ipObject.continent_code;
            textBoxCurrencyCode2.Text = ipObject.currency_code;
            textBoxSymbol2.Text = ipObject.currency_symbol;
        }

        public void UpdateObjectInfo()
        {
            ipObject.continent = textBoxContinent2.Text;
            ipObject.country = textBoxCountry2.Text;
            ipObject.region = textBoxRegion2.Text;
            ipObject.city = textBoxCity2.Text;
            ipObject.latitude = Convert.ToDecimal(textBoxLatitude2.Text.Replace('.',','));
            ipObject.longitude = Convert.ToDecimal(textBoxLongitude2.Text.Replace('.', ','));
            ipObject.asn = textBoxAsn2.Text;
            ipObject.org = textBoxOrg2.Text;
            ipObject.isp = textBoxIsp2.Text;
            ipObject.currency = textBoxCurrency2.Text;
            ipObject.country_code = textBoxIso2.Text;

            ipObject.country_capital = textBoxCountryCapital2.Text;
            ipObject.country_phone = textBoxCountryPhone2.Text;
            ipObject.country_neighbours = textBoxCountryNeighbours2.Text;
            ipObject.timezone = textBoxTimezone2.Text;
            ipObject.timezone_name = textBoxTimezoneName2.Text;
            ipObject.timezone_gmt = textBoxGMT2.Text;
            ipObject.timezone_gmtOffset = textBoxGMToff2.Text;
            ipObject.timezone_dstOffset = textBoxDSToff2.Text;
            ipObject.currency_plural = textBoxPlural2.Text;
            ipObject.currency_rates = Convert.ToDecimal(textBoxRates2.Text);
            ipObject.continent_code = textBoxContinentCode2.Text;
            ipObject.currency_code = textBoxCurrencyCode2.Text;
            ipObject.currency_symbol = textBoxSymbol2.Text;

            //Looping through object attributes and changing ' to '' if attribute is string
            foreach (PropertyInfo prop in ipObject.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (type == typeof(string))
                {
                    prop.SetValue(ipObject, prop.GetValue(ipObject, null).ToString().Replace("'", "''"));
                }
            }
        }

        private void SetReadOnly(bool yayORnay)
        {
            textBoxContinent2.ReadOnly = yayORnay;
            textBoxCountry2.ReadOnly = yayORnay;
            textBoxRegion2.ReadOnly = yayORnay;
            textBoxCity2.ReadOnly = yayORnay;
            textBoxLatitude2.ReadOnly = yayORnay;
            textBoxLongitude2.ReadOnly = yayORnay;
            textBoxAsn2.ReadOnly = yayORnay;
            textBoxOrg2.ReadOnly = yayORnay;
            textBoxIsp2.ReadOnly = yayORnay;
            textBoxCurrency2.ReadOnly = yayORnay;
            textBoxIso2.ReadOnly = yayORnay;

            textBoxCountryCapital2.ReadOnly = yayORnay;
            textBoxCountryPhone2.ReadOnly = yayORnay;
            textBoxCountryNeighbours2.ReadOnly = yayORnay;
            textBoxTimezone2.ReadOnly = yayORnay;
            textBoxTimezoneName2.ReadOnly = yayORnay;
            textBoxGMT2.ReadOnly = yayORnay;
            textBoxGMToff2.ReadOnly = yayORnay;
            textBoxDSToff2.ReadOnly = yayORnay;
            textBoxPlural2.ReadOnly = yayORnay;
            textBoxRates2.ReadOnly = yayORnay;
            textBoxContinentCode2.ReadOnly = yayORnay;
            textBoxCurrencyCode2.ReadOnly = yayORnay;
            textBoxSymbol2.ReadOnly = yayORnay;

            buttonEdit.Visible = yayORnay;
            buttonCancel.Visible = !yayORnay;
            buttonSave.Visible = !yayORnay;

            buttonEditnext.Visible = yayORnay;
            buttonCancelnext.Visible = !yayORnay;
            buttonSavenext.Visible = !yayORnay;
        }

        private void SetBorderStyle(BorderStyle borderStyle = BorderStyle.FixedSingle)
        {
            void ChangeControls(TableLayoutPanel tableLayoutPanel)
            {
                foreach (var control in tableLayoutPanel.Controls)
                {
                    var textBox = control as TextBox;
                    if (textBox != null)
                    {
                        if (textBox.Name.Contains('2'))
                        {
                            textBox.BorderStyle = borderStyle;
                        }
                    }
                }
            }
            ChangeControls(this.tableLayoutPanel1);
            ChangeControls(this.tableLayoutPanel2);

            textBoxContinentCode2.BorderStyle = borderStyle;
            textBoxCurrencyCode2.BorderStyle = borderStyle;
            textBoxSymbol2.BorderStyle = borderStyle;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
            SetBorderStyle();          
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            InitializeInfo();

            SetReadOnly(true);
            SetBorderStyle(BorderStyle.None);           
        }

        private bool LatLonCheck(string StringForCheck, string LatOrLon)
        {
            bool Valid = false;

            StringForCheck = StringForCheck.Replace(".", ",");
            if (double.TryParse(StringForCheck, out _) == true)
            {
                Valid = true;
            }

            if (Valid == true)
            {
                int Upper, Lower;
                switch(LatOrLon)
                {
                    case "Lat":
                        Upper = 90;
                        Lower = -90;
                        break;
                    case "Lon":
                        Upper = 180;
                        Lower = -180;
                        break;
                    default:
                        Upper = 181;
                        Lower = -181;
                        break;
                }

                double DoubleString = Convert.ToDouble(StringForCheck);
                if (DoubleString > Upper || DoubleString < Lower)
                {
                    Valid = false;
                }
            }
            return Valid;
        }

        private void InputEmpty() 
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                var textBox = control as TextBox;
                if (textBox != null)
                {
                    textBox.Text = textBox.Text.Trim();
                    textBox.Text = Regex.Replace(textBox.Text, @"\s+", " ");
                    if(textBox.Text == "")
                    {
                        if(textBox.Name == "textBoxLatitude2" || textBox.Name == "textBoxLongitude2" )
                        {
                            textBox.Text = "0";
                        }
                        else
                        {
                            textBox.Text = "NO DATA";
                        }
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            InputEmpty();
            if (LatLonCheck(textBoxLatitude2.Text, "Lat") && LatLonCheck(textBoxLongitude2.Text, "Lon"))
            {
                string PreviousLat = ipObject.latitude.ToString();
                string PreviousLon = ipObject.longitude.ToString();
                
                UpdateObjectInfo();
                _IP_Repostirory.UpdateIP(ipObject);
                mainformObject.dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(mainformObject.TextBoxSearch.Text,
                    mainformObject.checkBoxIPv4.Checked, mainformObject.checkBoxIPv6.Checked, mainformObject.GetCountriesFromComboBox(), mainformObject.comboBox.Text,
                    mainformObject.radioButtonAscending.Checked);
                mainformObject.PopulateCountriesComboBox();

                SetReadOnly(true);
                SetBorderStyle(BorderStyle.None);

                textBoxLatitude2.Text = textBoxLatitude2.Text.Replace('.', ',');
                textBoxLongitude2.Text = textBoxLongitude2.Text.Replace('.', ',');

                if (PreviousLat != ipObject.latitude.ToString() || PreviousLon != ipObject.longitude.ToString())
                {
                    InitializeMap();
                }
            }
            else
            {
                string message = "Invalid ";
                if (LatLonCheck(textBoxLatitude2.Text, "Lat") == false && LatLonCheck(textBoxLongitude2.Text, "Lon") == false)
                    message += "latitude and longitude";
                else if (LatLonCheck(textBoxLatitude2.Text, "Lat") == false)
                    message += "latitude";
                else if (LatLonCheck(textBoxLongitude2.Text, "Lon") == false)
                    message += "longitude";
                MessageBox.Show(message);
            }
        }

        private void tabControlDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(buttonEdit.Visible == false)
            {
                InitializeInfo();

                SetReadOnly(true);
                SetBorderStyle(BorderStyle.None);

                buttonEdit.Visible = true;
                buttonCancel.Visible = false;
                buttonSave.Visible = false;

                buttonEditnext.Visible = true;
                buttonCancelnext.Visible = false;
                buttonSavenext.Visible = false;
            }            
        }

        private void buttonEditnext_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
            SetBorderStyle();
        }

        private void buttonCancelnext_Click(object sender, EventArgs e)
        {
            InitializeInfo();

            SetReadOnly(true);
            SetBorderStyle(BorderStyle.None);

            textBoxCurrency2.Text = textBoxCurrency2.Text.Replace('.', ',');
        }

        private bool CurrencyCheck(string CurrencyForCheck)
        {
            bool Valid = false;

            CurrencyForCheck = CurrencyForCheck.Replace(".", ",");
            if (double.TryParse(CurrencyForCheck, out _) == true)
            {
                Valid = true;
            }

            return Valid;
        }

        private void buttonSavenext_Click(object sender, EventArgs e)
        {
            InputEmpty();
            if (CurrencyCheck(textBoxRates2.Text) == true)
            {
                UpdateObjectInfo();
                _IP_Repostirory.UpdateIP(ipObject);
                mainformObject.dataGridViewIP.DataSource = _IP_Repostirory.SearchAndSort(mainformObject.TextBoxSearch.Text,
                    mainformObject.checkBoxIPv4.Checked, mainformObject.checkBoxIPv6.Checked, mainformObject.GetCountriesFromComboBox(), mainformObject.comboBox.Text,
                    mainformObject.radioButtonAscending.Checked);
                mainformObject.PopulateCountriesComboBox();

                SetReadOnly(true);
                SetBorderStyle(BorderStyle.None);

                textBoxRates2.Text = textBoxRates2.Text.Replace('.', ',');
            }
            else
            {
                MessageBox.Show("Invalid currency rates");
            }   
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            WorldMap.Zoom++;
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            WorldMap.Zoom--;
        }
    }
}
