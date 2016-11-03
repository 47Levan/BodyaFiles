using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;

public unsafe struct HDR_HEADER
{
    /*
    **  Common HDR header structure that is passed around
	**  for all functions to use.  This encapsulates all
	**  information for HDR headers from Version 1 to 5.
	**  this structure can be expanded in the future as
	**  new data is added to the header.  I've also left in
	**  a number of items which are planned for the HDR
	**  version 5 files of the near future.  This can always
	**  be changed since nobody should yet be using these extra
	**  fields.  
    */
    internal fixed byte name[24];
    public int start_time;
    public int end_time;
    int time_recording_start;   // time HDR started recording
    int bytes_id_section;       // bytes in ID section
    int blocks_id_section;      // blocks in ID section
    int total_blocks;           // total blocks in file
    int version;                // HDR version number 
    int size_of_hdrid;			// length of an HDR ID
    public int start_analog;			// start of ANALOG HDR IDs
    public int end_analog;			// end of ANALOG HDR IDs
    public int start_point;			// start of POINT HDR IDs
    public int end_point;				// end of POINT HDR IDs
    public int start_count;			// start oc COUNT HDR IDs
    public int end_count;				// end of COUNT HDR IDs
    public int start_limit;			// start of LIMIT HDR IDs
    public int end_limit;               // end of LIMIT HDR IDs
    int scanner_base_rate;      // scanner base rate
    int vfymom;             // scada verify timestamps
    int rtnet_verify;           // rtnet verify timestamp
    int rtgen_verify;           // rtgen verify timestamp
    int stgen_verify;           // stgen verify timestamp
    int scadamom;               // scadamom verify timestamp
    int rtnet_definition;
    int rtgen_definition;
    int stgen_definition;

    /*
	** *NOTE* - All the following fields apply to version 5 file
	*/

    /*
    ** Customer specific version number
	** - fill to be -1 for files with version 1,2,3,4
	*/
    int extra_data_version;


    /*
	**  Customer specific bytes
    **  fill to be 0 if not applied(for version 1,2,3,4)
    */
    int num_bytes_analog_extra;
    int num_bytes_point_extra;
    int num_bytes_count_extra;
    int num_bytes_limit_extra;

    /*
	** customer specific header bytes
	*/
    int num_custom_header_bytes;

    /*
    **  fill to the normal value if version 1, 2, 3, 4
    **  substation = 8 bytes
    **  device-type = 14 bytes
    **  device = 6
    **  name string(analog, point, count, limit) = 4
	**  byte values obtained by reading the header for version 5
    **  
    */
    int num_bytes_substn_key;		// size of ID_SUBSTN identifier  
    int num_bytes_devtyp_key;		// size of ID_DEVTYP identifier  
    int num_bytes_device_key;		// size of ID_DEVICE identifier  
    int num_bytes_analog_key;		// size of ID_ANALOG identifier 
    int num_bytes_point_key;		// size of ID_POINT identifier 
    int num_bytes_count_key;		// size of ID_COUNT identifier 
    int num_bytes_limit_key;        // size of ID_LIMIT identifier 

    /*
    **  fill the following fields to be -1 if not applied (1,2,3,4)
    **  else fill to be the offset from the beginning of the id_section
    **  to the beginning of the data reord(point or count or limit)
    **  the offset for analog should be 0 from the beginning of 
    **  the id_section
    */
    int analog_id_offset;		// offset in ID map to ANALOG definition    
    int point_id_offset;		// offset in ID map to POINT definition     
    int count_id_offset;       // offset in ID map to COUNT definition 
    int limit_id_offset;        // offset in ID map to LIMIT definition 
    fixed byte reserve[220];            //header reserved
    fixed byte hdextradata[100];		//header extradata

};


namespace Hdr_Analyzer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonDir_Click(object sender, EventArgs e)
        {
            unsafe
            {
                HDR_HEADER header;
                DateTime dt = new DateTime(1970, 1, 1);
                DateTime dt1 = new DateTime();
                IntPtr ptr = new IntPtr(&header);
                FileStream fs;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(openFileDialog.FileName);
                    textBoxDir.Text = fi.DirectoryName;

                    string[] files = System.IO.Directory.GetFiles(fi.DirectoryName, "*.dat");
                    dataGridView.Rows.Clear();
                    dataGridView.Rows.Add(files.Length);
                    for (int i = 0; i < files.Length; i++)
                    {
                        fi = new System.IO.FileInfo(files[i]);

                        dataGridView.Rows[i].Cells[0].Value = fi.Name;

                        fs = null;

                        try
                        {

                            fs = new System.IO.FileStream(files[i], System.IO.FileMode.Open);
                            byte[] bytes = new byte[sizeof(HDR_HEADER)];
                            fs.Read(bytes, 0, sizeof(HDR_HEADER));
                            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, ptr, sizeof(HDR_HEADER));

                            dt1 = dt.AddSeconds(header.start_time);
                            dt1 = dt1.ToLocalTime();
                            dataGridView.Rows[i].Cells[1].Value = dt1.ToString();

                            dt1 = dt.AddSeconds(header.end_time);
                            dt1 = dt1.ToLocalTime();
                            dataGridView.Rows[i].Cells[2].Value = dt1.ToString();

                            dataGridView.Rows[i].Cells[3].Value = header.end_analog - header.start_analog + 1;
                            dataGridView.Rows[i].Cells[4].Value = header.end_point - header.start_point + 1;
                            dataGridView.Rows[i].Cells[5].Value = header.end_count - header.start_count + 1;
                            dataGridView.Rows[i].Cells[6].Value = header.end_limit - header.start_limit + 1;

                            dataGridView.Rows[i].Cells[7].Value = "Change...";
                            dataGridView.Rows[i].Cells[8].Value = "Save...";
                            dataGridView.Rows[i].Cells[9].Value = "Save...";
                        }
                        catch
                        {
                            MessageBox.Show("Can not read the file: " + fi.Name);
                        }

                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            unsafe
            {
                #region ColumnIndex=7    

                if (e.ColumnIndex == 7)
                {
                    HDR_HEADER header;
                    string S = "";
                    IntPtr ptr = new IntPtr(&header);
                    System.IO.FileStream fs = null;
                    try
                    {
                        fs =
                            new System.IO.FileStream(
                                textBoxDir.Text + "\\" + dataGridView.Rows[e.RowIndex].Cells[0].Value,
                                System.IO.FileMode.Open);
                        byte[] bytes = new byte[sizeof(HDR_HEADER)];
                        fs.Read(bytes, 0, sizeof(HDR_HEADER));
                        System.Runtime.InteropServices.Marshal.Copy(bytes, 0, ptr, sizeof(HDR_HEADER));
                        fs.Close();
                        fs = null;
                        try
                        {
                            S = "Analogs count";
                            header.end_analog = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value) +
                                                header.start_analog - 1;

                            S = "Points count";
                            header.start_point = header.end_analog + 1;
                            header.end_point = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[4].Value) +
                                               header.start_point - 1;

                            S = "Counters count";
                            header.start_count = header.end_point + 1;
                            header.end_count = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[5].Value) +
                                               header.start_count - 1;

                            S = "Limits count";
                            header.start_limit = header.end_count + 1;
                            header.end_limit = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[6].Value) +
                                               header.start_limit - 1;
                        }
                        catch
                        {
                            MessageBox.Show(S + " value is not integer type. Please correct the value!");
                        }
                        try
                        {
                            fs =
                                new System.IO.FileStream(
                                    textBoxDir.Text + "\\" + dataGridView.Rows[e.RowIndex].Cells[0].Value,
                                    System.IO.FileMode.Open);
                            IntPtr ptr1 = new IntPtr(&header);
                            System.Runtime.InteropServices.Marshal.Copy(ptr1, bytes, 0, sizeof(HDR_HEADER));
                            fs.Write(bytes, 0, sizeof(HDR_HEADER));
                            fs.Close();
                            fs = null;
                        }
                        catch
                        {
                            if (fs != null)
                            {
                                fs.Close();
                            }
                            MessageBox.Show("Can not write file.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Can not read the file.");
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }

                #endregion

                #region ColumnIndex=8    

                if (e.ColumnIndex == 8)
                {
                    SaveFileDialog dialog = new SaveFileDialog
                    {
                        Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                        FilterIndex = 2,
                        RestoreDirectory = true
                    };
                    HDR_HEADER header;
                    byte[] bytes = new byte[sizeof(HDR_HEADER)];
                    IntPtr ptr = new IntPtr(&header);

                    using (Stream fs = new FileStream(textBoxDir.Text + "\\"
                                                      + dataGridView.Rows[e.RowIndex].Cells[0].Value, FileMode.Open))
                    {
                        fs.Read(bytes, 0, sizeof(HDR_HEADER));
                        Marshal.Copy(bytes, 0, ptr, sizeof(HDR_HEADER));
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            using (Stream stream = dialog.OpenFile())
                            {
                                byte name = *header.name;
                                byte[] buffer = Encoding.UTF8.GetBytes(name.ToString());
                                stream.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }


                }

                #endregion
                #region ColumnIndex=9    
                if (e.ColumnIndex == 9)
                {
                    SaveFileDialog dialog = new SaveFileDialog
                    {
                        Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                        FilterIndex = 2,
                        RestoreDirectory = true
                    };
                    HDR_HEADER header;
                    byte[] bytes = new byte[sizeof(HDR_HEADER)];
                    IntPtr ptr = new IntPtr(&header);

                    using (Stream fs = new FileStream(textBoxDir.Text + "\\"
                        + dataGridView.Rows[e.RowIndex].Cells[0].Value, FileMode.Open))
                    {
                        fs.Read(bytes, 0, sizeof(HDR_HEADER));
                        Marshal.Copy(bytes, 0, ptr, sizeof(HDR_HEADER));
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            string data = serializer.Serialize(header);
                            using (Stream stream = new FileStream(dialog.FileName
                                , FileMode.OpenOrCreate))
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes(data);
                                stream.Write(buffer, 0, buffer.Length);
                                Process.Start("notepad.exe", dialog.FileName);
                            }
                        }
                    }
                }
                #endregion
            }
        }
    }
}
